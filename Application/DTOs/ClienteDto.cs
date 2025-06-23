namespace ApiCrudClientes.Application.DTOs
{
    // Objeto para transferir dados do cliente entre as camadas
    public class ClienteDto
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
        public EnderecoDto Endereco { get; set; } = null!;
    }

    // Objeto para transferir dados do endereço
    public class EnderecoDto
    {
        // Rua do endereço
        public string Rua { get; set; } = string.Empty;
        // Número do endereço
        public string Numero { get; set; } = string.Empty;
        // Cidade do endereço
        public string Cidade { get; set; } = string.Empty;
        // Estado do endereço
        public string Estado { get; set; } = string.Empty;
        // CEP do endereço
        public string CEP { get; set; } = string.Empty;
    }
}