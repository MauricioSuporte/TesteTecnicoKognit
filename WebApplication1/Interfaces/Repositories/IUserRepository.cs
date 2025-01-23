using UserWalletAPI.Models;

namespace UserWalletAPI.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User CreateUser(User user);
        User? GetUserById(int id);
        List<User> GetAllUsers();
    }
}
