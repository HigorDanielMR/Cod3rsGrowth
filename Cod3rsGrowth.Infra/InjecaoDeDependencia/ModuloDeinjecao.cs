using Cod3rsGrowth.Infra.MeuContextoDeDado;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    public static class ModuloDeInjecao
    {
        public static void BindService(ServiceCollection servicos)
        {
            servicos.AddScoped<MeuDataContext>();
        }
    }
}
