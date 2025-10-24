namespace ProjetoGusmaoFinal.Models
{
    public class Users(string Password, string CPF)
    {
        public int Id { get; set; }
        public required Roles Role { get; set; }
        public required int RoleID { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string Password;
        public string CPF;

        public void SetPassword(string Password)
        {
            _Password = Password;
        }
        public void GetPassword()
        {

        }
        public void SetCPF()
        {

        }
        public void GetCPF()
        {

        }
    }
}
