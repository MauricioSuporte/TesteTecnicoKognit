using Moq;
using UserWalletAPI.ApiServices;
using UserWalletAPI.DTOs;
using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Models;

namespace UserWalletAPI.UnitTests.ApiServices
{
    public class UserApiServiceUnitTests
    {
        private readonly Mock<IUserService> _mockUserService;
        private readonly UserApiService _userApiService;

        public UserApiServiceUnitTests()
        {
            _mockUserService = new Mock<IUserService>();
            _userApiService = new UserApiService(_mockUserService.Object);
        }

        [Fact]
        public void GivenValidUserRequest_WhenCreateUser_ThenReturnUserResponse()
        {
            // Arrange
            var userRequest = new UserRequest
            {
                Nome = "John Doe",
                Nascimento = new DateTime(1990, 1, 1),
                Cpf = "12345678900"
            };

            var user = new User
            {
                Id = 1,
                Nome = "John Doe",
                Nascimento = new DateTime(1990, 1, 1),
                Cpf = "12345678900"
            };

            var userResponse = new UserResponse
            {
                Id = 1,
                Nome = "John Doe",
                Nascimento = new DateTime(1990, 1, 1),
                Cpf = "12345678900"
            };

            _mockUserService.Setup(service => service.CreateUser(It.IsAny<User>())).Returns(user);

            // Act
            var result = _userApiService.CreateUser(userRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userResponse.Id, result.Id);
            Assert.Equal(userResponse.Nome, result.Nome);
            Assert.Equal(userResponse.Nascimento, result.Nascimento);
            Assert.Equal(userResponse.Cpf, result.Cpf);
            _mockUserService.Verify(service => service.CreateUser(It.IsAny<User>()), Times.Once);
        }
    }
}
