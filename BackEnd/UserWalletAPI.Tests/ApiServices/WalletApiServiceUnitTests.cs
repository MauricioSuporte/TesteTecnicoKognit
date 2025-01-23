using Moq;
using UserWalletAPI.DTOs;
using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Models;
using UserWalletAPI.ApiServices;

namespace UserWalletAPI.UnitTests.ApiServices
{
    public class WalletApiServiceUnitTests
    {
        private readonly Mock<IWalletService> _mockWalletService;
        private readonly WalletApiService _walletApiService;

        public WalletApiServiceUnitTests()
        {
            _mockWalletService = new Mock<IWalletService>();
            _walletApiService = new WalletApiService(_mockWalletService.Object);
        }

        [Fact]
        public void GivenValidWalletRequest_WhenCreateWallet_ThenReturnWalletResponse()
        {
            // Arrange
            var walletRequest = new WalletRequest
            {
                UserId = 1,
                ValorAtual = 100.0m,
                Banco = "Banco XYZ"
            };

            var wallet = new Wallet
            {
                Id = 1,
                UserId = 1,
                ValorAtual = 100.0m,
                Banco = "Banco XYZ",
                UltimaAtualizacao = DateTime.Now
            };

            var walletResponse = new WalletResponse
            {
                Id = wallet.Id,
                UserId = wallet.UserId,
                ValorAtual = wallet.ValorAtual,
                Banco = wallet.Banco,
                UltimaAtualizacao = wallet.UltimaAtualizacao
            };

            _mockWalletService.Setup(service => service.CreateWallet(It.IsAny<Wallet>())).Returns(wallet);

            // Act
            var result = _walletApiService.CreateWallet(walletRequest);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(walletResponse.Id, result.Id);
            Assert.Equal(walletResponse.UserId, result.UserId);
            Assert.Equal(walletResponse.ValorAtual, result.ValorAtual);
            Assert.Equal(walletResponse.Banco, result.Banco);
            Assert.Equal(walletResponse.UltimaAtualizacao, result.UltimaAtualizacao);
            _mockWalletService.Verify(service => service.CreateWallet(It.IsAny<Wallet>()), Times.Once);
        }

        [Fact]
        public void GivenInvalidWalletRequest_WhenCreateWallet_ThenReturnNull()
        {
            // Arrange
            var walletRequest = new WalletRequest
            {
                UserId = 1,
                ValorAtual = 100.0m,
                Banco = "Banco XYZ"
            };

            _mockWalletService.Setup(service => service.CreateWallet(It.IsAny<Wallet>())).Returns((Wallet?)null);

            // Act
            var result = _walletApiService.CreateWallet(walletRequest);

            // Assert
            Assert.Null(result);
            _mockWalletService.Verify(service => service.CreateWallet(It.IsAny<Wallet>()), Times.Once);
        }

        [Fact]
        public void GivenUserHasWallets_WhenGetWalletsByUser_ThenReturnWallets()
        {
            // Arrange
            var walletList = new List<Wallet>
            {
                new() { Id = 1, UserId = 1, ValorAtual = 200.0m, Banco = "Banco A", UltimaAtualizacao = DateTime.Now },
                new() { Id = 2, UserId = 1, ValorAtual = 150.0m, Banco = "Banco B", UltimaAtualizacao = DateTime.Now }
            };

            _mockWalletService.Setup(service => service.GetWalletsByUser(It.IsAny<int>())).Returns(walletList);

            // Act
            var result = _walletApiService.GetWalletsByUser(1);

            // Assert
            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
            _mockWalletService.Verify(service => service.GetWalletsByUser(It.IsAny<int>()), Times.Once);
        }

        [Fact]
        public void GivenUserHasNoWallets_WhenGetWalletsByUser_ThenReturnEmptyList()
        {
            // Arrange
            _mockWalletService.Setup(service => service.GetWalletsByUser(It.IsAny<int>())).Returns([]);

            // Act
            var result = _walletApiService.GetWalletsByUser(1);

            // Assert
            Assert.Empty(result);
            _mockWalletService.Verify(service => service.GetWalletsByUser(It.IsAny<int>()), Times.Once);
        }
    }
}
