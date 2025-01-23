namespace UserWalletAPI.DTOs
{
    public class WalletRequest
    {
        public int UserId { get; set; }
        public decimal ValorAtual { get; set; }
        public required string Banco { get; set; }
    }

}
