namespace ApiCrudClientes.Domain.ValueObjects
{ 
    // Representa o endereço de um cliente
    public class Endereco
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