using Microsoft.EntityFrameworkCore;
namespace ProjetoGusmaoFinal.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {

    }
}
