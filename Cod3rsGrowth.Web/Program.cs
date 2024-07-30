using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Validadores;
using Cod3rsGrowth.Infra.ConexaoComBanco;
using Cod3rsGrowth.Web.DetalhesDosProblemas;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Microsoft.Extensions.FileProviders;

var stringDeConexao = ConfigurationManager.ConnectionStrings["ConexaoComBanco"].ToString();
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc(); 
builder.Services.AddHttpClient();
builder.Services.AddDirectoryBrowser();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddProblemDetails();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<ServicoCarro>();
builder.Services.AddScoped<ServicoVenda>();
builder.Services.AddScoped<ValidacoesVenda>();
builder.Services.AddScoped<ValidacoesCarro>();
builder.Services.ConfigurarOEstadoDoModeloDeDetalhesDoProblema();
builder.Services.AddScoped<IRepositorioVenda, RepositorioVenda>();
builder.Services.AddScoped<IRepositorioCarro, RepositorioCarro>();
builder.Services.AddScoped(provider => new MeuContextoDeDados(stringDeConexao));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles(new StaticFileOptions { ServeUnknownFileTypes = true});
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "wwwroot")),
    EnableDirectoryBrowsing = true
});
app.UseDefaultFiles();
app.MapControllers();
app.UseAuthorization();
app.UseHttpsRedirection();
app.UseDeveloperExceptionPage();
app.UsarManipuladorDeExcecaoDeDetalhesDoProblema(app.Services.GetRequiredService<ILoggerFactory>());
app.Run();