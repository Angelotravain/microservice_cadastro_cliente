using ClienteService.Models;
using Microsoft.EntityFrameworkCore;

namespace ClienteService.Data
{
    public class ClienteContexto : DbContext
    {
        public ClienteContexto(DbContextOptions<ClienteContexto> options) : base(options)
        {
        }

        public DbSet<ClienteModel> Cliente { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
