namespace MilesCarRental.EntityModels
{
    /// <summary>
    /// Clase que representa el resultado de una operación.
    /// </summary>
    public class Result
    {
        /// <summary>
        /// Indica si la operación ha sido autorizada.
        /// </summary>
        public bool IsAuthorized { get; set; }

        /// <summary>
        /// Mensaje relacionado con el resultado de la operación.
        /// </summary>
        public string Message { get; set; } = string.Empty;
    }
}

