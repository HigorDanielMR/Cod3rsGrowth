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
            if (txtProcurarNome.Text == "")
            {
                TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
            }
            else
            {
                _filtro.Nome = txtProcurarNome.Text;

                TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(_filtro.Nome != null)
                _filtro.Nome = null;

            if(_filtro.Cpf != null)
                _filtro.Cpf = null;

            if (_filtro.Email!= null)
                _filtro.Email = null;

            TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (procurarCpf.Text == "")
            {
                TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
            }
            else
            {
                _filtro.Cpf = procurarCpf.Text;

                TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (txtProcurarEmail.Text == "")
            {
                TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
            }
            else
            {
                _filtro.Email = txtProcurarEmail.Text;

                TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
            }
        }
    }
}
