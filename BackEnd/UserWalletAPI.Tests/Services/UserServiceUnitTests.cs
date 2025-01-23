using Moq;
using UserWalletAPI.Interfaces.Repositories;
using UserWalletAPI.Models;
using UserWalletAPI.Services;

namespace UserWalletAPI.UnitTests.Services
{
    public class UserServiceUnitTests
    {
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly UserService _userService;

        public UserServiceUnitTests()
        {
            _mockUserRepository = new Mock<IUserRepository>();
            _userService = new UserService(_mockUserRepository.Object);
        }

        [Fact]
        public void GivenValidUser_WhenCreateUser_ThenReturnUser()
        {
            // Arrange
            var user = new User
            {
                Id = 1,
                Nome = "John Doe",
                Nascimento = new DateTime(1990, 1, 1),
                Cpf = "12345678900"
            };

            _mockUserRepository.Setup(repo => repo.CreateUser(It.IsAny<User>())).Returns(user);

            // Act
            var result = _userService.CreateUser(user);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Id, result.Id);
            Assert.Equal(user.Nome, result.Nome);
            Assert.Equal(user.Nascimento, result.Nascimento);
            Assert.Equal(user.Cpf, result.Cpf);
            _mockUserRepository.Verify(repo => repo.CreateUser(It.IsAny<User>()), Times.Once);
        }
    }
}
