using MilesCarRental.Interfaces;
using System.Security.Claims;

namespace MilesCarRental.Services
{
    /// <summary>
    /// Servicio para la gestión de usuarios.
    /// </summary>
    public class UserService : IUser
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Constructor de la clase UserService.
        /// </summary>
        /// <param name="httpContextAccessor">Accesor para el contexto HTTP.</param>
        public UserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Obtiene el nombre del usuario autenticado.
        /// </summary>
        /// <returns>Nombre del usuario autenticado o cadena vacía si no se encuentra.</returns>
        public string GetMyName()
        {
            var result = string.Empty;
            if (_httpContextAccessor.HttpContext != null)
            {
                result = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }
    }
}

