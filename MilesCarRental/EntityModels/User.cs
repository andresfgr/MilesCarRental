namespace MilesCarRental.EntityModels
{
    /// <summary>
    /// Clase que representa un usuario.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Hash de la contraseña del usuario.
        /// </summary>
        public byte[] PasswordHash { get; set; }

        /// <summary>
        /// Salt de la contraseña del usuario.
        /// </summary>
        public byte[] PasswordSalt { get; set; }

        /// <summary>
        /// Token de refresco para la autenticación.
        /// </summary>
        public string RefreshToken { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de creación del token de acceso.
        /// </summary>
        public DateTime TokenCreated { get; set; }

        /// <summary>
        /// Fecha de expiración del token de acceso.
        /// </summary>
        public DateTime TokenExpires { get; set; }
    }
}

