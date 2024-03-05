using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MilesCarRental.EntityModels;
using MilesCarRental.Interfaces;

namespace BoxMachineInventary.Controllers
{
    /// <summary>
    /// Controlador para la gestión de vehículos.
    /// </summary>
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicle _vehicle;

        /// <summary>
        /// Constructor de la clase VehicleController.
        /// </summary>
        /// <param name="vehicle">Servicio de vehículos.</param>
        public VehicleController(IVehicle vehicle)
        {
            _vehicle = vehicle;
        }

        /// <summary>
        /// Obtiene una lista de vehículos disponibles según los criterios de búsqueda.
        /// </summary>
        /// <param name="criteria">Criterios de búsqueda de vehículos.</param>
        /// <returns>Lista de vehículos disponibles.</returns>
        [HttpGet]
        public IActionResult GetVehicles([FromQuery] SearchCriteria criteria)
        {
            var availableVehicles = _vehicle.GetVehiclesByLocation(criteria);

            return Ok(availableVehicles);
        }
    }
}

