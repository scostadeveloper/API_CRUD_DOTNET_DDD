using ApiCrudClientes.Domain.Entities;
using ApiCrudClientes.Domain.Interfaces;
using ApiCrudClientes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudClientes.Infrastructure.Repositories
{
    // Implementação do repositório de clientes usando Entity Framework Core
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        // Construtor recebe o contexto do banco
        public ClienteRepository(AppDbContext context)
        {
            _context = context;
        }

        // Retorna todos os clientes
        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Clientes.ToListAsync();
        }

        // Busca um cliente pelo ID
        public async Task<Cliente?> GetByIdAsync(Guid id)
        {
            return await _context.Clientes.FindAsync(id);
        }

        // Busca um cliente pelo e-mail
        public async Task<Cliente?> GetByEmailAsync(string email)
        {
            return await _context.Clientes.FirstOrDefaultAsync(c => c.Email == email);
        }

        // Adiciona um novo cliente
        public async Task<Cliente> AddAsync(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        // Atualiza um cliente existente
        public async Task<Cliente> UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        // Remove um cliente pelo ID
        public async Task<bool> DeleteAsync(Guid id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
                return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}