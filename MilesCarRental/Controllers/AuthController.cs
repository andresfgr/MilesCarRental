using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MilesCarRental.EntityModels;
using MilesCarRental.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace BoxMachineInventaryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new();
        private readonly IConfiguration _configuration;
        private readonly IUser _user;

        public AuthController(IConfiguration configuration, IUser user)
        {
            _configuration = configuration;
            _user = user;
        }

        /// <summary>
        /// Obtiene el nombre del usuario autenticado.
        /// </summary>
        /// <returns>El nombre del usuario autenticado.</returns>
        [HttpGet, Authorize]
        public ActionResult<string> GetMe()
        {
            var userName = _user.GetMyName();
            return Ok(userName);
        }

        /// <summary>
        /// Inicia sesión de usuario y genera un token de acceso.
        /// </summary>
        /// <param name="request">Datos de inicio de sesión del usuario.</param>
        /// <returns>Resultado de la operación de inicio de sesión.</returns>
        [HttpPost("login")]
        public ActionResult<Result> Login(UserDto request)
        {
            // Registro temporal del usuario
            CreatePasswordHash("1234", out byte[] passwordHash, out byte[] passwordSalt);

            user.Username = "customer";
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            // Fin del registro temporal

            if (user.Username != request.Username)
            {
                return Ok(new Result { Message = "User not found." });
            }

            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                return Ok(new Result { Message = "Wrong password." });
            }

            string token = CreateToken(user);

            var refreshToken = GenerateRefreshToken();
            SetRefreshToken(refreshToken);

            return Ok(new Result { IsAuthorized = true, Message = token });
        }

        /// <summary>
        /// Refresca el token de acceso utilizando el token de actualización.
        /// </summary>
        /// <returns>El nuevo token de acceso generado.</returns>
        [HttpPost("refresh-token")]
        public ActionResult<string> RefreshToken()
        {
            var refreshToken = Request.Cookies["refreshToken"];

            if (!user.RefreshToken.Equals(refreshToken))
            {
                return Unauthorized("Invalid Refresh Token.");
            }
            else if (user.TokenExpires < DateTime.Now)
            {
                return Unauthorized("Token expired.");
            }

            string token = CreateToken(user);
            var newRefreshToken = GenerateRefreshToken();
            SetRefreshToken(newRefreshToken);

            return Ok(token);
        }

        private static RefreshToken GenerateRefreshToken()
        {
            var refreshToken = new RefreshToken
            {
                Token = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                Expires = DateTime.Now.AddDays(7),
                Created = DateTime.Now
            };

            return refreshToken;
        }

        private void SetRefreshToken(RefreshToken newRefreshToken)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = newRefreshToken.Expires
            };

            Response.Cookies.Append("refreshToken", newRefreshToken.Token, cookieOptions);

            user.RefreshToken = newRefreshToken.Token;
            user.TokenCreated = newRefreshToken.Created;
            user.TokenExpires = newRefreshToken.Expires;
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new()
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, "Admin")
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512();
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }

        private static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using var hmac = new HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }
}
