using LinqToDB;
using Cod3rsGrowth.Dominio.Entities;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Infra.MeuContextoDeDado;

namespace Cod3rsGrowth.Infra.Repositorios
{
    class RepositorioVenda : IRepositorio<Venda>
    {
        private MeuDataContext _db;
        public RepositorioVenda(MeuDataContext meuDataContext)
        {
            _db = meuDataContext;
        }
        public List<Venda> ObterTodos()
        {
            var query = from p in _db.Vendas
                        where p.Id > 0
                        select p;

            return query.ToList();
        }

        public Venda ObterPorId(int IdDeBusca)
        {
            return ObterPorId(IdDeBusca);
        }

        public Venda Criar(Venda venda)
        {
            int idDaVendaNoBanco = _db.InsertWithInt32Identity(venda);

            return ObterPorId(idDaVendaNoBanco);
        }

        public Venda Editar(Venda vendaAtualizada)
        {
            return vendaAtualizada;
        }
        public void Remover(int Id)
        {
        }
    }
}
