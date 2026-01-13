using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGusmaoFinal.Models
{
    public class Users
    {
        public int Id { get; set; }
        public Roles? Role { get; set; }
        public int RoleID { get; set; } = 7;

        [Column("Name")]
        public string Name { get; set; } = string.Empty;
        [Column("Email")]
        public string Email { get; set; } = string.Empty;
        [Column("Password")]
        public string Password { get; set; } = string.Empty;
        [Column("CPF")]
        public string CPF { get; set; } = string.Empty;
        public List<News>? News { get; set; }
    }
}
