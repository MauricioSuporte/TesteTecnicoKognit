using Microsoft.AspNetCore.Mvc;
using UserWalletAPI.DTOs;
using UserWalletAPI.Interfaces.ApiServices;

namespace UserWalletAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserApiService userApiService) : ControllerBase
    {
        private readonly IUserApiService _userApiService = userApiService;

        [HttpPost]
        public IActionResult CreateUser([FromBody] UserRequest userRequest)
        {
            var userResponse = _userApiService.CreateUser(userRequest);

            return CreatedAtAction(nameof(CreateUser), new { id = userResponse.Id }, userResponse);
        }
    }
}
