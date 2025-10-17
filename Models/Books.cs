namespace ProjetoGusmaoFinal.Models
{
    public class Books
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Url{ get; set; }
        public int Publisher{ get; set; }
        public required List<BookCategories> BookCategories { get; set; }

    }
}
