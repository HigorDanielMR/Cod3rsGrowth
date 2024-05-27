using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public sealed class ListaSingleton
    {
        private static ListaSingleton? _instance;

        public List<Carro> RepositorioCarro { get; set; } = new List<Carro> { };
        public List<Venda> RepositorioVenda { get; set; } = new List<Venda> { };

        

        private ListaSingleton(){}

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
