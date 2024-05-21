﻿using Cod3rsGrowth.Dominio.Entities;

namespace Cod3rsGrowth.Dominio.Interfaces
{
    public interface IServicoVenda
    {
        public List<Venda> ObterTodos();
        public void Criar(Venda venda);
        public void ObterVendaPorId();
        public void EditarVenda();
        public void RemoverVenda();
    }
}
