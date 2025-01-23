namespace UserWalletAPI.DTOs
{
    public class WalletResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public decimal ValorAtual { get; set; }
        public required string Banco { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
    }
}
