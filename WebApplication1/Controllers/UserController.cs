using Microsoft.AspNetCore.Mvc;
using UserWalletAPI.Models;

namespace UserWalletAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private static readonly List<User> Users = [];

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            user.Id = Users.Count + 1;
            Users.Add(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(Users);
        }
    }
}
