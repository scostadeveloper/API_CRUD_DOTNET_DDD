using ApiCrudClientes.Application.DTOs;
using ApiCrudClientes.Domain.Entities;
using ApiCrudClientes.Domain.Interfaces;
using AutoMapper;

namespace ApiCrudClientes.Application.Services
{
    public class ClienteService
    {
        // Responsável por acessar os dados dos clientes
        private readonly IClienteRepository _repository;
        // Responsável por converter entre entidades e DTOs
        private readonly IMapper _mapper;

        // Construtor recebe as dependências necessárias
        public ClienteService(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Retorna todos os clientes cadastrados
        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var clientes = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ClienteDto>>(clientes);
        }

        // Busca um cliente pelo ID
        public async Task<ClienteDto?> GetByIdAsync(Guid id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            return _mapper.Map<ClienteDto>(cliente);
        }

        // Adiciona um novo cliente após validações
        public async Task<ClienteDto> AddAsync(ClienteDto dto)
        {
            // Verifica se já existe um cliente com o mesmo e-mail
            var clienteExistente = await _repository.GetByEmailAsync(dto.Email);
            if (clienteExistente != null)
                throw new InvalidOperationException("Já existe um cliente com este email.");

            // Verifica se todos os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(dto.Nome) || string.IsNullOrWhiteSpace(dto.Email) ||
                dto.Endereco == null ||
                string.IsNullOrWhiteSpace(dto.Endereco.Rua) ||
                string.IsNullOrWhiteSpace(dto.Endereco.Numero) ||
                string.IsNullOrWhiteSpace(dto.Endereco.Cidade) ||
                string.IsNullOrWhiteSpace(dto.Endereco.Estado) ||
                string.IsNullOrWhiteSpace(dto.Endereco.CEP))
            {
                throw new ArgumentException("Todos os campos obrigatórios devem ser preenchidos.");
            }

            // Converte o DTO para a entidade Cliente e gera um novo Id
            var cliente = _mapper.Map<Cliente>(dto);
            cliente.Id = Guid.NewGuid();

            // Salva o cliente no banco de dados
            await _repository.AddAsync(cliente);

            // Atualiza o Id no DTO e retorna
            dto.Id = cliente.Id;
            return dto;
        }

        // Atualiza um cliente existente após validações
        public async Task<bool> UpdateAsync(Guid id, ClienteDto dto)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null)
                return false;

            // Verifica se o e-mail já está em uso por outro cliente
            var clienteExistente = await _repository.GetByEmailAsync(dto.Email);
            if (clienteExistente != null && clienteExistente.Id != id)
                throw new InvalidOperationException("Já existe um cliente com este email.");

            // Verifica se todos os campos obrigatórios estão preenchidos
            if (string.IsNullOrWhiteSpace(dto.Nome) || string.IsNullOrWhiteSpace(dto.Email) ||
                dto.Endereco == null ||
                string.IsNullOrWhiteSpace(dto.Endereco.Rua) ||
                string.IsNullOrWhiteSpace(dto.Endereco.Numero) ||
                string.IsNullOrWhiteSpace(dto.Endereco.Cidade) ||
                string.IsNullOrWhiteSpace(dto.Endereco.Estado) ||
                string.IsNullOrWhiteSpace(dto.Endereco.CEP))
            {
                throw new ArgumentException("Todos os campos obrigatórios devem ser preenchidos.");
            }

            // Atualiza as propriedades do cliente usando o AutoMapper
            _mapper.Map(dto, cliente);

            // Salva as alterações no banco de dados
            await _repository.UpdateAsync(cliente);
            return true;
        }

        // Remove um cliente pelo ID
        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}