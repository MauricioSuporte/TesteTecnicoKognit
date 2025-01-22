using UserWalletAPI.Models;

namespace UserWalletAPI.Interfaces.ApiServices
{
    public interface IWalletApiService
    {
        Wallet CreateWallet(Wallet wallet);
        Wallet? GetWalletById(int id);
        List<Wallet> GetAllWallets();
        List<Wallet> GetWalletsByUserId(int userId);
    }
}
