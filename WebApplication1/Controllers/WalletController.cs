using Microsoft.AspNetCore.Mvc;
using UserWalletAPI.Interfaces.ApiServices;
using UserWalletAPI.Models;

namespace UserWalletAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController(IWalletApiService walletApiService) : ControllerBase
    {
        private readonly IWalletApiService _walletApiService = walletApiService;

        [HttpPost]
        public IActionResult CreateWallet([FromBody] Wallet wallet)
        {
            var createdWallet = _walletApiService.CreateWallet(wallet);
            return CreatedAtAction(nameof(GetWallet), new { id = createdWallet.Id }, createdWallet);
        }

        [HttpGet("{id}")]
        public IActionResult GetWallet(int id)
        {
            var wallet = _walletApiService.GetWalletById(id);
            return wallet is null ? NotFound() : Ok(wallet);
        }

        [HttpGet]
        public IActionResult GetAllWallets()
        {
            return Ok(_walletApiService.GetAllWallets());
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetWalletsByUserId(int userId)
        {
            return Ok(_walletApiService.GetWalletsByUserId(userId));
        }
    }
}
