using Cod3rsGrowth.Dominio.Services;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Infra.MeuContextoDeDado;
using Cod3rsGrowth.Servicos.Validadores;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public static class ModuloDeInjecaoInfra
    {
        public static void BindService(ServiceCollection servicos)
        {
            servicos.AddScoped<MeuDataContext>();

            servicos.AddScoped<ValidacoesCarro>();
            servicos.AddScoped<ValidacoesVenda>();

            servicos.AddScoped<ServicoCarro>();
            servicos.AddScoped<ServicoVenda>();

            servicos.AddScoped<IRepositorioCarro, RepositorioCarroMock>();
            servicos.AddScoped<IRepositorioVenda, RepositorioVendaMock>();
        }
    }
}
