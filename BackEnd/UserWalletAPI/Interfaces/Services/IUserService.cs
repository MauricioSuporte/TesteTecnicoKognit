using UserWalletAPI.Models;

namespace UserWalletAPI.Interfaces.Services
{
    public interface IUserService
    {
        User CreateUser(User user);
    }
}
