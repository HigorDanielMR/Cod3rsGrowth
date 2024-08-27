using Cod3rsGrowth.forms;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.Repositorios;
using Cod3rsGrowth.Servicos.Validadores;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Forms.InjecaoForms
{
    public class ModuloDeInjecaoForms
    {
        public static void BindService(IServiceCollection servicos)
        {
            servicos.AddTransient<ServicoCarro>();
            servicos.AddTransient<ServicoVenda>();
            servicos.AddTransient<FormListagem>();
            servicos.AddTransient<ValidacoesCarro>();
            servicos.AddTransient<ValidacoesVenda>();
            servicos.AddTransient<IRepositorioCarro, RepositorioCarro>();
            servicos.AddTransient<IRepositorioVenda, RepositorioVenda>();
        }
    }
}
