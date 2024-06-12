using Cod3rsGrowth.Infra.MeuContextoDeDado;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Infra.InjecaoDeDependencia
{
    public static class ModuloDeInjecao
    {
        public static void BindService(ServiceCollection servicos)
        {
            servicos.AddScoped<MeuDataContext>();

        }
    }
}
