namespace ProjetoGusmaoFinal.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public Users Users { get; set; }
        public int UserId { get; set; }
    }
}
