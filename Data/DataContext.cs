using Microsoft.EntityFrameworkCore;
using ProjetoGusmaoFinal.Models;
namespace ProjetoGusmaoFinal.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)//no Model creating definimos relação e caracteristicas de campos, tipo NOT NULL ou coisa do tipo;
        {
                
        }
    }
}
