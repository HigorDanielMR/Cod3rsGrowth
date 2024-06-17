using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Forms
{
    public partial class FormListagemVenda : Form
    {
        private ServicoVenda _servicoVenda;
        private ValidacoesVenda _validacoesVenda;
        private FiltroVenda _filtro = new FiltroVenda();

        public FormListagemVenda(ServicoVenda servico, ValidacoesVenda validations)
        {
            _servicoVenda = servico;
            _validacoesVenda = validations;

            InitializeComponent();

            TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtProcurar.Text == "")
            {
                _filtro = null;

                TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
            }
            else
            {
                _filtro.Nome = txtProcurar.Text;

                TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _filtro.Nome = null;

            TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
        }
    }
}
