using UserWalletAPI.DTOs;
using UserWalletAPI.Interfaces.ApiServices;
using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Models;

namespace UserWalletAPI.ApiServices
{
    public class WalletApiService(IWalletService walletService) : IWalletApiService
    {
        private readonly IWalletService _walletService = walletService;

        public WalletResponse CreateWallet(WalletRequest walletRequest)
        {
            var wallet = new Wallet
            {
                UserId = walletRequest.UserId,
                ValorAtual = walletRequest.ValorAtual,
                Banco = walletRequest.Banco,
                UltimaAtualizacao = DateTime.Now
            };

            var createdWallet = _walletService.CreateWallet(wallet);

            var walletResponse = new WalletResponse
            {
                Id = createdWallet.Id,
                UserId = createdWallet.UserId,
                ValorAtual = createdWallet.ValorAtual,
                Banco = createdWallet.Banco,
                UltimaAtualizacao = createdWallet.UltimaAtualizacao
            };

            return walletResponse;
        }

        public IEnumerable<WalletResponse> GetWalletsByUser(int userId)
        {
            var wallets = _walletService.GetWalletsByUser(userId);

            return wallets.Select(wallet => new WalletResponse
            {
                Id = wallet.Id,
                UserId = wallet.UserId,
                ValorAtual = wallet.ValorAtual,
                Banco = wallet.Banco,
                UltimaAtualizacao = wallet.UltimaAtualizacao
            });
        }
    }
}
