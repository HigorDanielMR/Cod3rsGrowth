using Microsoft.Extensions.DependencyInjection;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Dominio.Services;
using Cod3rsGrowth.Infra.Interfaces;

namespace Cod3rsGrowth.Testes
{
    public static class ModuloDeInjecao
    {
        public static void BindService(ServiceCollection servicos)
        {
            servicos.AddScoped<IServicoCarro, ServicoCarro>();
            servicos.AddScoped<IServicoVenda, ServicoVenda>();
            servicos.AddScoped<IRepositorio, RepositorioMock>();
        }
    }
}
