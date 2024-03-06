using MilesCarRental.EntityModels;
using MilesCarRental.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MilesCarRental.Controllers;

namespace MilesCarRental.Tests
{
    public class VehicleControllerTests
    {
        [Fact]
        public void GetVehicles_ReturnsOkResult_WithListOfVehicles()
        {
            // Arrange
            var mockVehicleService = new Mock<IVehicle>();
            var searchCriteria = new SearchCriteria();
            var expectedVehicles = new List<Vehicle>
            {
                new Vehicle { Id = 1, Model = "Toyota", Year = 2022 },
                new Vehicle { Id = 2, Model = "Honda", Year = 2021 }
            };
            mockVehicleService.Setup(service => service.GetVehiclesByLocation(searchCriteria)).Returns(expectedVehicles);
            var controller = new VehicleController(mockVehicleService.Object);

            // Act
            var result = controller.GetVehicles(searchCriteria);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var actualVehicles = Assert.IsAssignableFrom<IEnumerable<Vehicle>>(okResult.Value);
            Assert.Equal(expectedVehicles, actualVehicles);
        }

        [Fact]
        public void GetVehicles_ReturnsOkResult_WithListOfAvailableVehicles()
        {
            // Arrange
            var mockVehicleService = new Mock<IVehicle>();
            var expectedVehicles = new List<Vehicle> { new Vehicle(), new Vehicle() }; // Sample data
            mockVehicleService.Setup(x => x.GetVehiclesByLocation(It.IsAny<SearchCriteria>())).Returns(expectedVehicles);
            var controller = new VehicleController(mockVehicleService.Object);

            // Act
            var result = controller.GetVehicles(new SearchCriteria());

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var vehicles = Assert.IsAssignableFrom<IEnumerable<Vehicle>>(okResult.Value);
            Assert.Equal(expectedVehicles.Count, vehicles.Count());
        }

        [Fact]
        public void GetVehicles_ReturnsUnauthorizedResult_WhenUserIsNotAuthenticated()
        {
            // Arrange
            var mockVehicleService = new Mock<IVehicle>();
            var controller = new VehicleController(mockVehicleService.Object)
            {
                ControllerContext = new ControllerContext() // Simulate unauthenticated request
            };

            // Act
            var result = controller.GetVehicles(new SearchCriteria());

            // Assert
            Assert.IsType<UnauthorizedResult>(result);
        }
    }
}