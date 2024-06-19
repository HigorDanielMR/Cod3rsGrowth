using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;
using Microsoft.IdentityModel.Tokens;

namespace Cod3rsGrowth.forms
{
    public partial class FormListagem : Form
    {

        private ServicoCarro _servicoCarro;
        private ServicoVenda _servicoVenda;
        private ValidacoesCarro _validacoesCarro;
        private ValidacoesVenda _validacoesVenda;
        private FiltroCarro _filtroCarro = new FiltroCarro();
        private FiltroVenda _filtroVenda = new FiltroVenda();

        public FormListagem(ServicoCarro servicoCarro, ValidacoesCarro validacoesCarro, ValidacoesVenda validacoesVenda, ServicoVenda servicoVenda)
        {
            _validacoesCarro = validacoesCarro;
            _servicoCarro = servicoCarro;

            _validacoesVenda = validacoesVenda;
            _servicoVenda = servicoVenda;

            InitializeComponent();

            selecionarCor.DataSource = Enum.GetValues(typeof(Cores));
            selecionarMarca.DataSource = Enum.GetValues(typeof(Marcas));

            selecionarCor.SelectedItem = null;
            selecionarMarca.SelectedItem = null;
        }

        private void FormListagem_Load(object sender, EventArgs e)
        {
            TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtroCarro);
            TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtroVenda);
        }

        private void AoClicarNoBotaoFiltrarDaTabelaCarro_Click(object sender, EventArgs e)
        {
            try
            {
                if (selecionarMarca != null && selecionarMarca.SelectedItem != null)
                {
                    var indexDesejado = selecionarMarca.SelectedIndex;
                    _filtroCarro.Marca = (Marcas)indexDesejado;
                }

                if (!txtProcurar.Text.IsNullOrEmpty())
                {
                    _filtroCarro.Modelo = txtProcurar.Text;
                }
                if (selecionarCor != null && selecionarCor.SelectedItem != null)
                {
                    var indexdesejado = (Cores)selecionarCor.SelectedIndex;
                    _filtroCarro.Cor = indexdesejado;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }

            TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtroCarro);
        }

        private void AoClicarNoBotaoLimparFiltroDaTabelaCarro_Click(object sender, EventArgs e)
        {
            try
            {
                if (_filtroCarro.Marca != null)
                {
                    _filtroCarro.Marca = null;
                }
                if (_filtroCarro.Modelo != null)
                {
                    _filtroCarro.Modelo = null;
                }
                if (_filtroCarro.Cor != null)
                {
                    _filtroCarro.Cor = null;
                }

                txtProcurar.Clear();
                selecionarCor.SelectedItem = null;
                selecionarMarca.SelectedItem = null;

                TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtroCarro);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void AoClicarNoBotaoFiltrarNaTabelaVenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtProcurarNome.Text.IsNullOrEmpty())
                {
                    _filtroVenda.Nome = txtProcurarNome.Text;
                }

                if (!procurarData.Text.IsNullOrEmpty() && procurarData.Text != "  /  /")
                {
                    _filtroVenda.DataDeCompra = DateTime.Parse(procurarData.Text);
                }

                if (!txtProcurarEmail.Text.IsNullOrEmpty())
                {
                    _filtroVenda.Email = txtProcurarEmail.Text;
                }

                if (!procurarCpf.Text.IsNullOrEmpty() && procurarCpf.Text != "   .   .   -")
                {
                    _filtroVenda.Cpf = procurarCpf.Text;
                }

                TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtroVenda);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void AoCLicarNoBotaoLimparFIltroDaTabelaVenda_Click(object sender, EventArgs e)
        {
            try
            {
                if (_filtroVenda.Nome != null)
                    _filtroVenda.Nome = null;
                txtProcurarNome.Clear();

                if (_filtroVenda.Cpf != null)
                    _filtroVenda.Cpf = null;
                procurarCpf.Clear();

                if (_filtroVenda.Email != null)
                    _filtroVenda.Email = null;
                txtProcurarEmail.Clear();

                if (_filtroVenda.DataDeCompra != null)
                    _filtroVenda.DataDeCompra = null;
                procurarData.Clear();

                TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtroVenda);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
