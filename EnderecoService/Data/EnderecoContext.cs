using EnderecoService.Models;
using Microsoft.EntityFrameworkCore;

namespace EnderecoService.Data
{
    public class EnderecoContext : DbContext
    {
        public EnderecoContext(DbContextOptions<EnderecoContext> options) : base(options)
        {
        }

        public DbSet<EnderecoModel> Endereco { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
