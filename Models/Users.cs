using System.ComponentModel.DataAnnotations;

namespace ProjetoGusmaoFinal.Models
{
    public class Users()
    {
        public int Id { get; set; }
        public Roles Role { get; set; } = new Roles();
        public int RoleID { get; set; } = 0;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public List<News> News { get; set; } = [];
    }
}
