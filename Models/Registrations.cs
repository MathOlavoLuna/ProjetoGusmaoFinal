namespace ProjetoGusmaoFinal.Models
{
    public class Registrations
    {
        public int Id { get; set; }
        public required string CPF { get; set; }
        public required string ClassName { get; set; }
        public Users User { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
