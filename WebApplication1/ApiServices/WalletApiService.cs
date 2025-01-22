using UserWalletAPI.Interfaces.ApiServices;
using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Models;

namespace UserWalletAPI.ApiServices
{
    public class WalletApiService(IWalletService walletService) : IWalletApiService
    {
        private readonly IWalletService _walletService = walletService;

        public Wallet CreateWallet(Wallet wallet)
        {
            return _walletService.CreateWallet(wallet);
        }

        public Wallet? GetWalletById(int id)
        {
            return _walletService.GetWalletById(id);
        }

        public List<Wallet> GetAllWallets()
        {
            return _walletService.GetAllWallets();
        }

        public List<Wallet> GetWalletsByUserId(int userId)
        {
            return _walletService.GetWalletsByUserId(userId);
        }
    }
}
