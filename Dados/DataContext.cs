using Microsoft.EntityFrameworkCore;
using MoreResults.API.Model;

namespace MoreResults.API.Dados
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<UsuarioDto> Usuarios { get; set; }
    }
}
