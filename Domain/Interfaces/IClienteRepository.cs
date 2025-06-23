using ApiCrudClientes.Domain.Entities;

namespace ApiCrudClientes.Domain.Interfaces
{
    // Contrato para operações de acesso a dados de clientes
    public interface IClienteRepository
    {
        // Retorna todos os clientes
        Task<IEnumerable<Cliente>> GetAllAsync();
        // Busca um cliente pelo ID
        Task<Cliente?> GetByIdAsync(Guid id);
        // Busca um cliente pelo e-mail
        Task<Cliente?> GetByEmailAsync(string email);
        // Adiciona um novo cliente
        Task<Cliente> AddAsync(Cliente cliente);
        // Atualiza um cliente existente
        Task<Cliente> UpdateAsync(Cliente cliente);
        // Remove um cliente pelo ID
        Task<bool> DeleteAsync(Guid id);
    }
}