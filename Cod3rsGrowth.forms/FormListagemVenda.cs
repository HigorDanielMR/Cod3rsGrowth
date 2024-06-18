using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;
using Microsoft.IdentityModel.Tokens;

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

        private void button2_Click(object sender, EventArgs e)
        {
            if (_filtro.Nome != null)
                _filtro.Nome = null;
            txtProcurarNome.Clear();

            if (_filtro.Cpf != null)
                _filtro.Cpf = null;
            procurarCpf.Clear();

            if (_filtro.Email != null)
                _filtro.Email = null;
            txtProcurarEmail.Clear();

            if (_filtro.DataDeCompra != null)
                _filtro.DataDeCompra = null;
            procurarData.Clear();

            TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
        }

        private void botaoFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtProcurarNome.Text.IsNullOrEmpty())
                {
                    _filtro.Nome = txtProcurarNome.Text;
                }

                if (!procurarData.Text.IsNullOrEmpty() && procurarData.Text != "  /  /")
                {
                    _filtro.DataDeCompra = DateTime.Parse(procurarData.Text);
                }

                if (!txtProcurarEmail.Text.IsNullOrEmpty())
                {
                    _filtro.Email = txtProcurarEmail.Text;
                }

                if (!procurarCpf.Text.IsNullOrEmpty() && procurarCpf.Text != "   .   .   -")
                {
                    _filtro.Cpf = procurarCpf.Text;
                }

                TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
