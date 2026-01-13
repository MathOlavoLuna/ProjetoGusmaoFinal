// Models/Books.cs
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoGusmaoFinal.Models
{
    [Table("books")]
    public class Books
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }
        public byte[]? PdfFile { get; set; }

        [StringLength(100)]
        public string? PdfFileName { get; set; } 

        [StringLength(50)]
        public string? PdfContentType { get; set; } 

        public long? PdfFileSize { get; set; } 

        [StringLength(500)]
        public string? CoverImageUrl { get; set; }

        [StringLength(500)]
        public string? AmazonUrl { get; set; }

        [StringLength(20)]
        public string? ISBN { get; set; }

        public DateTime CreatedAt { get; set; }

        public int PublisherId { get; set; }

        [ForeignKey("PublisherId")]
        public virtual Publisher? Publisher { get; set; }

        public virtual ICollection<BookCategories> BookCategories { get; set; } = new List<BookCategories>();
    }
}