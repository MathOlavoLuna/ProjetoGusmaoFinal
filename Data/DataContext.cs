// Data/DataContext.cs
using Microsoft.EntityFrameworkCore;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> Options) : base(Options)
        {
        }

        // DbSets
        public DbSet<Users> Users { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BookCategories> BookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder ModelBuilder)
        {
            base.OnModelCreating(ModelBuilder);

            // Configuração Users
            ModelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.Role)
                    .WithMany()
                    .HasForeignKey(e => e.RoleID)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração Roles
            ModelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            // Configuração News
            ModelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.User)
                    .WithMany()
                    .HasForeignKey(e => e.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configuração Books
            ModelBuilder.Entity<Books>(entity =>
            {
                entity.ToTable("books");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.Publisher)
                    .WithMany(p => p.Books)
                    .HasForeignKey(e => e.PublisherId)
                    .OnDelete(DeleteBehavior.Restrict);

                // Configuração para BLOB (PDF)
                entity.Property(e => e.PdfFile)
                    .HasColumnType("LONGBLOB"); // Para MySQL/MariaDB
            });

            // Configuração Publisher
            ModelBuilder.Entity<Publisher>(entity =>
            {
                entity.ToTable("publishers");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            // Configuração Category
            ModelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("categories");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
            });

            // Configuração BookCategories (Many-to-Many)
            ModelBuilder.Entity<BookCategories>(entity =>
            {
                entity.ToTable("book_categories");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(e => e.Book)
                    .WithMany(b => b.BookCategories)
                    .HasForeignKey(e => e.BookId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Category)
                    .WithMany(c => c.BookCategories)
                    .HasForeignKey(e => e.CategoryId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Índice único para evitar duplicação
                entity.HasIndex(e => new { e.BookId, e.CategoryId })
                    .IsUnique();
            });
        }
    }
}