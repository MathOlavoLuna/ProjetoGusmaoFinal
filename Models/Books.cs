namespace ProjetoGusmaoFinal.Models
{
    public class Books
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public string Url{ get; set; }
        public Publisher Publisher { get; set; } 
        public int PublisherId{ get; set; }
        public required List<BookCategories> BookCategories { get; set; }

    }
}
