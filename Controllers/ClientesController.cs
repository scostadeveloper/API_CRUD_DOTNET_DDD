using ApiCrudClientes.Application.DTOs;
using ApiCrudClientes.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudClientes.Controllers
{
    // Controller responsável pelos endpoints da API de clientes
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly ClienteService _clienteService;

        // Construtor recebe o serviço de clientes
        public ClientesController(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // Retorna todos os clientes
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteService.GetAllAsync();
            return Ok(clientes);
        }

        // Busca um cliente pelo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        // Adiciona um novo cliente
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ClienteDto dto)
        {
            try
            {
                var cliente = await _clienteService.AddAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        // Atualiza um cliente existente
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ClienteDto dto)
        {
            try
            {
                var atualizado = await _clienteService.UpdateAsync(id, dto);
                if (!atualizado) return NotFound();
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }

        // Remove um cliente pelo ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var removido = await _clienteService.DeleteAsync(id);
            if (!removido) return NotFound();
            return NoContent();
        }
    }
}