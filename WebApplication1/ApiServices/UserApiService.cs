using UserWalletAPI.Interfaces.ApiServices;
using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Models;

namespace UserWalletAPI.ApiServices
{
    public class UserApiService(IUserService userService) : IUserApiService
    {
        private readonly IUserService _userService = userService;

        public User CreateUser(User user)
        {
            return _userService.CreateUser(user);
        }

        public User? GetUserById(int id)
        {
            return _userService.GetUserById(id);
        }

        public List<User> GetAllUsers()
        {
            return _userService.GetAllUsers();
        }
    }
}
