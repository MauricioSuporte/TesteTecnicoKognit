using UserWalletAPI.Interfaces.Repositories;
using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Models;

namespace UserWalletAPI.Services
{
    public class WalletService(IWalletRepository walletRepository, IUserRepository userRepository) : IWalletService
    {
        private readonly IWalletRepository _walletRepository = walletRepository;
        private readonly IUserRepository _userRepository = userRepository;

        public Wallet? CreateWallet(Wallet wallet)
        {
            var userExists = _userRepository.UserExists(wallet.UserId);

            if (!userExists)
            {
                return null;
            }

            return _walletRepository.CreateWallet(wallet);
        }

        public IEnumerable<Wallet> GetWalletsByUser(int userId)
        {
            return _walletRepository.GetWalletsByUser(userId);
        }
    }
}