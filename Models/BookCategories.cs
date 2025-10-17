namespace ProjetoGusmaoFinal.Models
{
    public class BookCategories
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Books> Books { get; set; }
    }
}
