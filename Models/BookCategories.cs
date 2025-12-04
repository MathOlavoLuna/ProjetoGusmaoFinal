namespace ProjetoGusmaoFinal.Models
{
    public class BookCategories
    {
        public int Id { get; set; } 
        public Books Book { get; set; }
        public int BookId { get; set; }
        public Categories Category { get; set; }
        public int CategoryId { get; set; }
    }
}
