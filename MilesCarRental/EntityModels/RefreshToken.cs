namespace MilesCarRental.EntityModels
{
    /// <summary>
    /// Clase que representa un token de refresco para autenticación.
    /// </summary>
    public class RefreshToken
    {
        /// <summary>
        /// Token de refresco.
        /// </summary>
        public string Token { get; set; } = string.Empty;

        /// <summary>
        /// Fecha de creación del token.
        /// </summary>
        public DateTime Created { get; set; } = DateTime.Now;

        /// <summary>
        /// Fecha de expiración del token.
        /// </summary>
        public DateTime Expires { get; set; }
    }
}

