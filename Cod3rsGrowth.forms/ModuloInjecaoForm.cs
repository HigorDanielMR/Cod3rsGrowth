using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms
{
    public class ModuloInjecaoForm
    {
        public static void Injetar(IServiceCollection servico)
        {
            servico.AddTransient<ServicoCarro>();
            servico.AddTransient<IRepositorio<Carro, FiltroCarro>, RepositorioCarro>();
        }
    }
}
