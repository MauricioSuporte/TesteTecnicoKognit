namespace UserWalletAPI.DTOs
{
    public class UserRequest
    {
        public required string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public required string Cpf { get; set; }
    }

}
