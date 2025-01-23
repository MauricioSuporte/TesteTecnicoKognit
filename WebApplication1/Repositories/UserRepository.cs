using UserWalletAPI.Data;
using UserWalletAPI.Interfaces.Repositories;
using UserWalletAPI.Models;
using Microsoft.EntityFrameworkCore;

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

        public User? GetUserById(int id)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(u => u.Id == id);
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.AsNoTracking().ToList();
        }
    }
}
