using ApiCrudClientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudClientes.Infrastructure.Data
{
    // Responsável por gerenciar o acesso ao banco de dados
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Representa a tabela de clientes
        public DbSet<Cliente> Clientes => Set<Cliente>();

        // Configura o mapeamento do value object Endereco como owned type
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
                .OwnsOne(c => c.Endereco);
        }
    }
}