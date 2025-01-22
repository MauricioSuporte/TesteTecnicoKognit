using UserWalletAPI.Models;

namespace UserWalletAPI.Interfaces.ApiServices
{
    public interface IUserApiService
    {
        User CreateUser(User user);
        User? GetUserById(int id);
        List<User> GetAllUsers();
    }
}
