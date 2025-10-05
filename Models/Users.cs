namespace ProjetoGusmaoFinal.Models
{
    public class Users
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        private required string Password { get; set; }
        private required string CPF { get; set; }
    }
}
