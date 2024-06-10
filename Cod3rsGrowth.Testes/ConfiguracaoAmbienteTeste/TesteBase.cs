using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes.ConfiguracaoAmbienteTeste
{
    public abstract class TesteBase : IDisposable
    {
        protected ServiceProvider ServiceProvider;
        protected TesteBase()
        {
            ServiceProvider = ObterServiceCollection().BuildServiceProvider();
        }

        private IServiceCollection ObterServiceCollection()
        {
            var servicos = new ServiceCollection();
            ModuloDeInjecaoInfra.BindService(servicos);
            ModuloDeInjecao.BindService(servicos);
            return servicos;
        }

        public virtual void Dispose()
        {
            ServiceProvider.Dispose();
        }
    }
}
