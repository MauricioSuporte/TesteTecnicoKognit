using Microsoft.EntityFrameworkCore;
using UserWalletAPI.Models;

namespace UserWalletAPI.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
    }
}
