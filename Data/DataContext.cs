using Microsoft.EntityFrameworkCore;
using ProjetoGusmaoFinal.Models;

namespace ProjetoGusmaoFinal.Data
{
    public class DataContext : DbContext
    {
        // Use construtor tradicional
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookCategories> BookCategories { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Registrations> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.HasIndex(u => u.CPF).IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("Name") // Garanta que o nome da coluna está correto
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Password)
                    .IsRequired();

                entity.Property(e => e.CPF)
                    .IsRequired()
                    .HasMaxLength(14);
            });
        }
    }
}