using ApiCrudClientes.Infrastructure.Data;
using ApiCrudClientes.Domain.Interfaces;
using ApiCrudClientes.Infrastructure.Repositories;
using ApiCrudClientes.Application.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configura o banco de dados em memória
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ClientesDb"));

// Configura a injeção de dependência do repositório
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<ClienteService>();

//AutoMapper configuration
builder.Services.AddAutoMapper(typeof(ApiCrudClientes.Application.AutoMapperProfile));

builder.Services.AddControllers();

var app = builder.Build();

//Swagger configuration
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapControllers();


app.Run();
