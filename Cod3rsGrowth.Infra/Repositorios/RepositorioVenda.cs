﻿using LinqToDB;
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
        public List<Venda> ObterTodos(Venda venda)
        {
            IQueryable<Venda> vendas = Filtro(_db.Vendas.ToList(), venda);
            var query = vendas;

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

        private static IQueryable<Venda> Filtro(List<Venda> vendas, Venda venda)
        {
            var query = vendas.AsQueryable();

            if (venda.Nome != null)
                query = query.Where(d => d.Nome == venda.Nome);

            if (venda.Cpf != null)
                query = query.Where(d => d.Cpf == venda.Cpf);

            if (venda.DataDeCompra != null)
                query = query.Where(d => d.DataDeCompra == venda.DataDeCompra);

            if (venda.Telefone != null)
                query = query.Where(d => d.Telefone == venda.Telefone);

            if (venda.Email != null)
                query = query.Where(d => d.Email == venda.Email);

            return query;
        }
    }
}