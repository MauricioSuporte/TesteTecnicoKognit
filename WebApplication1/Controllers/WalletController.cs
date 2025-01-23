using Microsoft.AspNetCore.Mvc;
using UserWalletAPI.DTOs;
using UserWalletAPI.Interfaces.ApiServices;

namespace UserWalletAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController(IWalletApiService walletApiService) : ControllerBase
    {
        private readonly IWalletApiService _walletApiService = walletApiService;

        [HttpPost]
        public IActionResult CreateWallet([FromBody] WalletRequest walletRequest)
        {
            var walletResponse = _walletApiService.CreateWallet(walletRequest);
            return CreatedAtAction(nameof(CreateWallet), new { id = walletResponse.Id }, walletResponse);
        }

        [HttpGet("{userId}")]
        public IActionResult GetWalletsByUser(int userId)
        {
            var walletsResponse = _walletApiService.GetWalletsByUser(userId);

            return Ok(walletsResponse);
        }
    }
}
