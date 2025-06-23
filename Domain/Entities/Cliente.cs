using System;
using ApiCrudClientes.Domain.ValueObjects;

namespace ApiCrudClientes.Domain.Entities
{
    // Representa um cliente do sistema
    public class Cliente
    {
        // Identificador único do cliente
        public Guid Id { get; set; }
        // Nome do cliente
        public string Nome { get; set; } = string.Empty;
        // Email do cliente
        public string Email { get; set; } = string.Empty;
        // Telefone do cliente (opcional)
        public string? Telefone { get; set; }
        // Endereço do cliente
        public Endereco Endereco { get; set; } = null!;
    }
}