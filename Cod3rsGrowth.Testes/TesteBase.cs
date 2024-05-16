using Xunit.Microsoft.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace Cod3rsGrowth.Testes
{
    class TesteBase : IDisposable
    {
        protected ServiceProvider ServiceProvider { get; private set; }

        public TesteBase(ServiceProvider serviceProvider)
        {
            ServiceProvider = serviceProvider;
        }

        public void Dispose()
        {
            if (ServiceProvider != null)
            {
                if (ServiceProvider is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }
        }
    }
}
