using Microsoft.AspNetCore.Mvc;
using UserWalletAPI.Models;

namespace UserWalletAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WalletController : ControllerBase
    {
        private static readonly List<Wallet> Wallets = [];

        [HttpPost]
        public IActionResult CreateWallet([FromBody] Wallet wallet)
        {
            wallet.Id = Wallets.Count + 1;
            wallet.UltimaAtualizacao = DateTime.Now;
            Wallets.Add(wallet);
            return CreatedAtAction(nameof(GetWallet), new { id = wallet.Id }, wallet);
        }

        [HttpGet("{id}")]
        public IActionResult GetWallet(int id)
        {
            var wallet = Wallets.FirstOrDefault(w => w.Id == id);
            return wallet is null ? NotFound() : Ok(wallet);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetWalletsByUserId(int userId)
        {
            var userWallets = Wallets.Where(w => w.UserId == userId).ToList();
            return Ok(userWallets);
        }
    }
}
