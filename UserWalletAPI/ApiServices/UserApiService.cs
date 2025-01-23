using UserWalletAPI.DTOs;
using UserWalletAPI.Interfaces.ApiServices;
using UserWalletAPI.Interfaces.Services;
using UserWalletAPI.Models;

namespace UserWalletAPI.ApiServices
{
    public class UserApiService(IUserService userService) : IUserApiService
    {
        private readonly IUserService _userService = userService;

        public UserResponse CreateUser(UserRequest userRequest)
        {
            var user = new User
            {
                Nome = userRequest.Nome,
                Nascimento = userRequest.Nascimento,
                Cpf = userRequest.Cpf
            };

            var createdUser = _userService.CreateUser(user);

            var userResponse = new UserResponse
            {
                Id = createdUser.Id,
                Nome = createdUser.Nome,
                Nascimento = createdUser.Nascimento,
                Cpf = createdUser.Cpf
            };

            return userResponse;
        }
    }
}
