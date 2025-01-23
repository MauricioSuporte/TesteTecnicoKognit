using UserWalletAPI.Models;

namespace UserWalletAPI.Interfaces.Repositories
{
    public interface IWalletRepository
    {
        Wallet CreateWallet(Wallet wallet);
        IEnumerable<Wallet> GetWalletsByUser(int userId);
    }
}
