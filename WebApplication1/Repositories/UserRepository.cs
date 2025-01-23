using UserWalletAPI.Data;
using UserWalletAPI.Interfaces.Repositories;
using UserWalletAPI.Models;

namespace UserWalletAPI.Repositories
{
    public class UserRepository(AppDbContext context) : IUserRepository
    {
        private readonly AppDbContext _context = context;

        public User CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}
