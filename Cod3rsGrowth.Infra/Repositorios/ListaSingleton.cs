using Cod3rsGrowth.Dominio.Entidades;

namespace Cod3rsGrowth.Infra.Repositorios
{
    public sealed class ListaSingleton
    {
        private static readonly Lazy<ListaSingleton> _instance =
            new Lazy<ListaSingleton>(() => new ListaSingleton());

        public List<Carro> RepositorioCarro { get; } = new List<Carro>();
        public List<Venda> RepositorioVenda { get; } = new List<Venda>();

        private ListaSingleton() { }

        public static ListaSingleton Instance => _instance.Value;

    }
}
