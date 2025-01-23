using UserWalletAPI.Interfaces.Repositories;
using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Models;

namespace UserWalletAPI.Services
{
    public class WalletService(IWalletRepository walletRepository) : IWalletService
    {
        private readonly IWalletRepository _walletRepository = walletRepository;

        public Wallet CreateWallet(Wallet wallet)
        {
            return _walletRepository.CreateWallet(wallet);
        }

        public IEnumerable<Wallet> GetWalletsByUser(int userId)
        {
            return _walletRepository.GetWalletsByUser(userId);
        }
    }
}
