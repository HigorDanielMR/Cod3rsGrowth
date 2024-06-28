using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.ConexaoComBanco;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;
using System.Configuration;
using static LinqToDB.Common.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;



var stringDeConexao = ConfigurationManager.ConnectionStrings["ConexaoComBanco"].ToString();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped(provider => new MeuContextoDeDados(stringDeConexao));
builder.Services.AddScoped<ServicoCarro>();
builder.Services.AddScoped<ServicoVenda>();
builder.Services.AddScoped<ValidacoesVenda>();
builder.Services.AddScoped<ValidacoesCarro>();
builder.Services.AddScoped<IRepositorioVenda, RepositorioVenda>();
builder.Services.AddScoped<IRepositorioCarro, RepositorioCarro>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseDeveloperExceptionPage();

app.Run();
