using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MilesCarRental.Controllers;
using MilesCarRental.EntityModels;
using MilesCarRental.Interfaces;
using Moq;

namespace MilesCarRental.Tests
{
    public class AuthControllerTests
    {
        [Fact]
        public void GetMe_ReturnsOkResult_WithUserName()
        {
            // Arrange
            var mockUserService = new Mock<IUser>();
            mockUserService.Setup(x => x.GetMyName()).Returns("TestUser");
            var mockConfiguration = new Mock<IConfiguration>();
            var controller = new AuthController(mockConfiguration.Object, mockUserService.Object);

            // Act
            var result = controller.GetMe();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal("TestUser", okResult.Value);
        }

        [Fact]
        public void Login_ReturnsOkResult_WithToken_WhenValidCredentialsProvided()
        {
            // Arrange
            var mockUserService = new Mock<IUser>();
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.Setup(x => x.GetSection("AppSettings:Token").Value).Returns("test_secret_key");
            var controller = new AuthController(mockConfiguration.Object, mockUserService.Object);
            var userDto = new UserDto { Username = "customer", Password = "1234" };

            // Act
            var result = controller.Login(userDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var loginResult = Assert.IsType<Result>(okResult.Value);
            Assert.True(loginResult.IsAuthorized);
            Assert.NotEmpty((string)loginResult.Message);
        }

        [Fact]
        public void Login_ReturnsOkResult_WithUserNotFoundMessage_WhenInvalidUsernameProvided()
        {
            // Arrange
            var mockUserService = new Mock<IUser>();
            var mockConfiguration = new Mock<IConfiguration>();
            var controller = new AuthController(mockConfiguration.Object, mockUserService.Object);
            var userDto = new UserDto { Username = "invalid_user", Password = "1234" };

            // Act
            var result = controller.Login(userDto);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var loginResult = Assert.IsType<Result>(okResult.Value);
            Assert.False(loginResult.IsAuthorized);
            Assert.Equal("User not found.", loginResult.Message);
        }
    }
}
