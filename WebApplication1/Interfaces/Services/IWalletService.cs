using UserWalletAPI.Models;

namespace UserWalletAPI.Interfaces.Services
{
    public interface IWalletService
    {
        Wallet? CreateWallet(Wallet wallet);
        IEnumerable<Wallet> GetWalletsByUser(int userId);
    }
}
