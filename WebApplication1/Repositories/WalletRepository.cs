using UserWalletAPI.Data;
using UserWalletAPI.Interfaces.Repositories;
using UserWalletAPI.Models;

namespace UserWalletAPI.Repositories
{
    public class WalletRepository(AppDbContext context) : IWalletRepository
    {
        private readonly AppDbContext _context = context;

        public Wallet CreateWallet(Wallet wallet)
        {
            _context.Wallets.Add(wallet);
            _context.SaveChanges();
            return wallet;
        }

        public IEnumerable<Wallet> GetWalletsByUser(int userId)
        {
            return _context.Wallets.Where(w => w.UserId == userId).ToList();
        }
    }
}
