using Microsoft.EntityFrameworkCore;
using ProjetoGusmaoFinal.Models;
namespace ProjetoGusmaoFinal.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Users> Users { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<BookCategories> BookCategories { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Registrations> Registrations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//no Model creating definimos relação e caracteristicas de campos, tipo NOT NULL ou coisa do tipo;
        {
            modelBuilder.Entity<Users>().HasIndex(u => u.Email).IsUnique();
            modelBuilder.Entity<Roles>().HasMany<Users>().WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleID);

            modelBuilder.Entity<BookCategories>().HasMany<Books>().WithMany(b => b.BookCategories); //Para fazermos many-to-many temos que ter uma List<> do tipo de dados.

        }
    }
}
