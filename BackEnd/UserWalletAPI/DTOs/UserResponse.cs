namespace UserWalletAPI.DTOs
{
    public class UserResponse
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public required string Cpf { get; set; }
    }
}
