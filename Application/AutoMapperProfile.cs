using ApiCrudClientes.Application.DTOs;
using ApiCrudClientes.Domain.Entities;
using ApiCrudClientes.Domain.ValueObjects;
using AutoMapper;

namespace ApiCrudClientes.Application
{
    // Configura os mapeamentos entre entidades e DTOs
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapeamento entre Cliente e ClienteDto (e vice-versa)
            CreateMap<Cliente, ClienteDto>().ReverseMap();
            // Mapeamento entre Endereco e EnderecoDto (e vice-versa)
            CreateMap<Endereco, EnderecoDto>().ReverseMap();
        }
    }
}