using UserWalletAPI.Models;

namespace UserWalletAPI.Interfaces.Services
{
    public interface IWalletService
    {
        Wallet CreateWallet(Wallet wallet);
        Wallet? GetWalletById(int id);
        List<Wallet> GetAllWallets();
        List<Wallet> GetWalletsByUserId(int userId);
    }
}
