using System.Collections.Generic;
using MilesCarRental.EntityModels;

namespace MilesCarRental.Interfaces
{
    /// <summary>
    /// Interfaz para la gestión de vehículos.
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Obtiene una lista de vehículos disponibles según los criterios de búsqueda de ubicación.
        /// </summary>
        /// <param name="criteria">Criterios de búsqueda de ubicación.</param>
        /// <returns>Lista de vehículos disponibles.</returns>
        List<Vehicle> GetVehiclesByLocation(SearchCriteria criteria);
    }
}
