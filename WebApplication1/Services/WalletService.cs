using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Models;

namespace UserWalletAPI.Services
{
    public class WalletService : IWalletService
    {
        private readonly List<Wallet> _wallets = [];

        public Wallet CreateWallet(Wallet wallet)
        {
            wallet.Id = _wallets.Count + 1;
            wallet.UltimaAtualizacao = DateTime.Now;
            _wallets.Add(wallet);
            return wallet;
        }

        public Wallet? GetWalletById(int id)
        {
            return _wallets.FirstOrDefault(w => w.Id == id);
        }

        public List<Wallet> GetAllWallets()
        {
            return _wallets;
        }

        public List<Wallet> GetWalletsByUserId(int userId)
        {
            return _wallets.Where(w => w.UserId == userId).ToList();
        }
    }
}
