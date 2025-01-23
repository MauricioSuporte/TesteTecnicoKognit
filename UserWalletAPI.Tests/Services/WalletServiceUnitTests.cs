using Moq;
using UserWalletAPI.Interfaces.Repositories;
using UserWalletAPI.Models;
using UserWalletAPI.Services;

namespace UserWalletAPI.UnitTests.Services
{
    public class WalletServiceUnitTests
    {
        private readonly Mock<IWalletRepository> _mockWalletRepository;
        private readonly Mock<IUserRepository> _mockUserRepository;
        private readonly WalletService _walletService;

        public WalletServiceUnitTests()
        {
            _mockWalletRepository = new Mock<IWalletRepository>();
            _mockUserRepository = new Mock<IUserRepository>();
            _walletService = new WalletService(_mockWalletRepository.Object, _mockUserRepository.Object);
        }

        [Fact]
        public void GivenUserDoesNotExist_WhenCreateWallet_ThenReturnNull()
        {
            // Arrange
            _mockUserRepository.Setup(repo => repo.UserExists(It.IsAny<int>())).Returns(false);
            var wallet = new Wallet { UserId = 1, ValorAtual = 100.0m, Banco = "Banco XYZ" };

            // Act
            var result = _walletService.CreateWallet(wallet);

            // Assert
            Assert.Null(result);
            _mockUserRepository.Verify(repo => repo.UserExists(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GivenUserExists_WhenCreateWallet_ThenReturnWallet()
        {
            // Arrange
            _mockUserRepository.Setup(repo => repo.UserExists(It.IsAny<int>())).Returns(true);
            var wallet = new Wallet { UserId = 1, ValorAtual = 100.0m, Banco = "Banco XYZ" };
            _mockWalletRepository.Setup(repo => repo.CreateWallet(It.IsAny<Wallet>())).Returns(wallet);

            // Act
            var result = _walletService.CreateWallet(wallet);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(wallet.UserId, result.UserId);
            Assert.Equal(wallet.ValorAtual, result.ValorAtual);
            Assert.Equal(wallet.Banco, result.Banco);
            _mockUserRepository.Verify(repo => repo.UserExists(It.IsAny<int>()), Times.Once);
            _mockWalletRepository.Verify(repo => repo.CreateWallet(It.IsAny<Wallet>()), Times.Once);
        }

        [Fact]
        public void GivenUserHasWallets_WhenGetWalletsByUser_ThenReturnWallets()
        {
            // Arrange
            var walletList = new List<Wallet>
            {
                new() { Id = 1, UserId = 1, ValorAtual = 200.0m, Banco = "Banco A" },
                new() { Id = 2, UserId = 1, ValorAtual = 150.0m, Banco = "Banco B" }
            };
            _mockWalletRepository.Setup(repo => repo.GetWalletsByUser(It.IsAny<int>())).Returns(walletList);

            // Act
            var result = _walletService.GetWalletsByUser(1);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            _mockWalletRepository.Verify(repo => repo.GetWalletsByUser(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GivenUserHasNoWallets_WhenGetWalletsByUser_ThenReturnEmptyList()
        {
            // Arrange
            _mockWalletRepository.Setup(repo => repo.GetWalletsByUser(It.IsAny<int>())).Returns([]);

            // Act
            var result = _walletService.GetWalletsByUser(1);

            // Assert
            Assert.Empty(result);
            _mockWalletRepository.Verify(repo => repo.GetWalletsByUser(It.IsAny<int>()), Times.Once);
        }
    }
}
