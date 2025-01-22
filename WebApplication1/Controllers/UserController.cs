using Microsoft.AspNetCore.Mvc;
using UserWalletAPI.Interfaces.ApiServices;
using UserWalletAPI.Models;

namespace UserWalletAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController(IUserApiService userApiService) : ControllerBase
    {
        private readonly IUserApiService _userApiService = userApiService;

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            var createdUser = _userApiService.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userApiService.GetUserById(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_userApiService.GetAllUsers());
        }
    }
}
