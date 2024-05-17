using Cod3rsGrowth.Dominio.Servicos;
using Cod3rsGrowth.Dominio.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public static class ModuloDeInjecao
    {
        public static void BindService(ServiceCollection servicos)
        {
            servicos.AddScoped<IServicoCarro, ServicoCarro>();
            servicos.AddScoped<IServicoVenda, ServicoVenda>();
        }
    }
}
