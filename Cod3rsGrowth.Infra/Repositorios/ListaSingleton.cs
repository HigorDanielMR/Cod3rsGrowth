using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public sealed class ListaSingleton
    {
        private static ListaSingleton? _instance;

        public List<Carro> RepositorioCarro { get; private set; }
        public List<Venda> RepositorioVenda { get; private set; }

        private ListaSingleton()
        {
            RepositorioCarro = new List<Carro>();
            RepositorioVenda = new List<Venda>();
        }

        public static ListaSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ListaSingleton();
                }
                return _instance;
            }
        }
    }
}
