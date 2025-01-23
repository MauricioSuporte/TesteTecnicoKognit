using UserWalletAPI.Interfaces.Repositories;
using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Models;

namespace UserWalletAPI.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public User CreateUser(User user)
        {
            return _userRepository.CreateUser(user);
        }

        public User? GetUserById(int id)
        {
            return _userRepository.GetUserById(id);
        }

        public List<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
    }
}
