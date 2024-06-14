using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagemVenda : Form
    {
        private ServicoVenda _servicoVenda;
        private FiltroVenda _filtro;
        private ValidacoesVenda _validacoesVenda;
        public FormListagemVenda(ServicoVenda servico, ValidacoesVenda validations)
        {
            _servicoVenda = servico;
            _validacoesVenda = validations;
            InitializeComponent();

            TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
        }
    }
}
