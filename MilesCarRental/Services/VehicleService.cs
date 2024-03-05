using MilesCarRental.EntityModels;
using MilesCarRental.Interfaces;

namespace MilesCarRental.Services
{
    /// <summary>
    /// Servicio para la gestión de vehículos.
    /// </summary>
    public class VehicleService : IVehicle
    {
        private readonly List<Vehicle> _vehicles;

        /// <summary>
        /// Constructor de la clase VehicleService.
        /// </summary>
        /// <param name="httpContextAccessor">Accesor para el contexto HTTP.</param>
        public VehicleService(IHttpContextAccessor httpContextAccessor)
        {
            // Simulación de datos
            string[] locationsReturn1 = { "barranquilla", "medellin", "bogota" };
            string[] locationsReturn2 = { "bogota" };

            _vehicles = new List<Vehicle>
            {
                new Vehicle { Id = 1, Plate = "BCD012", Brand = "Toyota", Model = "Corolla", Year = 2022, Color = "Blanco", Location = "barranquilla", LocationReturn = locationsReturn1 },
                new Vehicle { Id = 2, Plate = "KDY789", Brand = "Honda", Model = "Civic", Year = 2023, Color = "Azul", Location = "medellin", LocationReturn = locationsReturn1 },
                new Vehicle { Id = 3, Plate = "OAD036", Brand = "Ford", Model = "Mustang", Year = 2020, Color = "Negro", Location = "bogota", LocationReturn = locationsReturn1 },
                new Vehicle { Id = 4, Plate = "UJT746", Brand = "Honda", Model = "Civic", Year = 2021, Color = "Blanco", Location = "bogota", LocationReturn = locationsReturn2 },
                new Vehicle { Id = 5, Plate = "KAS446", Brand = "Mazda", Model = "3", Year = 2023, Color = "Negro", Location = "bogota", LocationReturn = locationsReturn1 },
                new Vehicle { Id = 6, Plate = "XYZ123", Brand = "Chevrolet", Model = "Spark", Year = 2022, Color = "Rojo", Location = "cartagena", LocationReturn = locationsReturn2 },
                new Vehicle { Id = 7, Plate = "OPQ456", Brand = "Volkswagen", Model = "Golf", Year = 2021, Color = "Gris", Location = "bogota", LocationReturn = locationsReturn2 },
                new Vehicle { Id = 8, Plate = "LMN789", Brand = "Toyota", Model = "Yaris", Year = 2020, Color = "Plateado", Location = "medellin", LocationReturn = locationsReturn2 },
                new Vehicle { Id = 9, Plate = "RST012", Brand = "Nissan", Model = "Sentra", Year = 2022, Color = "Blanco", Location = "barranquilla", LocationReturn = locationsReturn1 },
                new Vehicle { Id = 10, Plate = "ABC987", Brand = "Ford", Model = "Fiesta", Year = 2023, Color = "Verde", Location = "medellin", LocationReturn = locationsReturn2 }
            };
        }

        /// <summary>
        /// Obtiene una lista de vehículos disponibles según los criterios de búsqueda.
        /// </summary>
        /// <param name="criteria">Criterios de búsqueda.</param>
        /// <returns>Lista de vehículos disponibles.</returns>
        /// <exception cref="ArgumentNullException">Se lanza si los criterios de búsqueda son nulos.</exception>
        /// <exception cref="ArgumentException">Se lanza si las ubicaciones de recogida o entrega son nulas o vacías.</exception>
        public List<Vehicle> GetVehiclesByLocation(SearchCriteria criteria)
        {
            if (criteria == null)
            {
                throw new ArgumentNullException(nameof(criteria), "Search criteria cannot be null.");
            }

            string pickupLocation = criteria.PickupLocation;
            string dropoffLocation = criteria.DropoffLocation;

            if (string.IsNullOrWhiteSpace(pickupLocation) || string.IsNullOrWhiteSpace(dropoffLocation))
            {
                throw new ArgumentException("Pickup and dropoff locations cannot be null or empty.");
            }

            var matchingVehicles = _vehicles.Where(x => x.Location == pickupLocation.ToLower() && x.LocationReturn.Contains(dropoffLocation.ToLower())).ToList();
             
            return matchingVehicles.ToList();
        }
    }
}

