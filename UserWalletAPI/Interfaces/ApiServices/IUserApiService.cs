using UserWalletAPI.DTOs;

namespace UserWalletAPI.Interfaces.ApiServices
{
    public interface IUserApiService
    {
        UserResponse CreateUser(UserRequest userRequest);
    }
}
