namespace MilesCarRental.EntityModels
{
    /// <summary>
    /// Clase que representa un vehículo.
    /// </summary>
    public class Vehicle
    {
        /// <summary>
        /// Identificador único del vehículo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Placa del vehículo.
        /// </summary>
        public string? Plate { get; set; }

        /// <summary>
        /// Marca del vehículo.
        /// </summary>
        public string? Brand { get; set; }

        /// <summary>
        /// Modelo del vehículo.
        /// </summary>
        public string? Model { get; set; }

        /// <summary>
        /// Año de fabricación del vehículo.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Color del vehículo.
        /// </summary>
        public string? Color { get; set; }

        /// <summary>
        /// Ubicación actual del vehículo.
        /// </summary>
        public string? Location { get; set; }

        /// <summary>
        /// Ubicaciones a las que puede retornar el vehículo.
        /// </summary>
        public string[]? LocationReturn { get; set; }
    }
}

