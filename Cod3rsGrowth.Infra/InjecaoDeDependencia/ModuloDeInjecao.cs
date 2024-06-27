using Cod3rsGrowth.Infra.ConexaoComBanco;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Infra.InjecaoDeDependencia
{
    public class ModuloDeInjecao
    {
        public static void BindService(ServiceCollection servicos)
        {
            servicos.AddScoped<MeuContextoDeDados>();
        }
    }
}
