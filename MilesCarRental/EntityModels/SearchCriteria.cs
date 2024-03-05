namespace MilesCarRental.EntityModels
{
    /// <summary>
    /// Clase que representa los criterios de búsqueda para vehículos.
    /// </summary>
    public class SearchCriteria
    {
        /// <summary>
        /// Ubicación de recogida del vehículo.
        /// </summary>
        public string? PickupLocation { get; set; }

        /// <summary>
        /// Ubicación de devolución del vehículo.
        /// </summary>
        public string? DropoffLocation { get; set; }
    }
}

