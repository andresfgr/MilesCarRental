namespace MilesCarRental.EntityModels
{
    /// <summary>
    /// Clase que representa los datos de un usuario para iniciar sesión.
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Nombre de usuario.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Contraseña del usuario.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
