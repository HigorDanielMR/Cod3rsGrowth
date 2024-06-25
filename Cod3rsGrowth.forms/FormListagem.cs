using System.Globalization;
using Cod3rsGrowth.Forms;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Microsoft.IdentityModel.Tokens;
using Cod3rsGrowth.Servicos.Validadores;

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
        }

        private void AoCarregarFormListagem(object sender, EventArgs e)
        {
            CarregarListasAtualizadas();
            CarregarEnums();
            LimparComboBox();
        }

        private void AoClicarNoBotaoFiltrarDaTabelaCarro(object sender, EventArgs e)
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

        private void AoClicarNoBotaoLimparFiltroDaTabelaCarro(object sender, EventArgs e)
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
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void AoClicarNoBotaoFiltrarNaTabelaVenda(object sender, EventArgs e)
        {
            try
            {
                if (!txtProcurarNome.Text.IsNullOrEmpty())
                {
                    _filtroVenda.Nome = txtProcurarNome.Text;
                }

                if (!procurarData.Text.IsNullOrEmpty() && procurarData.Text != "  /  /")
                {
                    _filtroVenda.DataDeCompra = DateTime.ParseExact(procurarData.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
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

        private void AoClicarNoBotaoLimparFIltroDaTabelaVenda(object sender, EventArgs e)
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
        private void AoClicarNoBotaoCriarVenda(object sender, EventArgs e)
        {
            var formulario = new FormCriarVenda(_validacoesVenda, _servicoVenda, _servicoCarro);
            formulario.ShowDialog();
            CarregarListasAtualizadas();
        }

        private void AoClicarNoBotaoCriarCarro(object sender, EventArgs e)
        {
            var formulario = new FormCriarCarro(_servicoCarro, _validacoesCarro);
            formulario.ShowDialog();
            CarregarListasAtualizadas();
        }

        private void CarregarListasAtualizadas()
        {
            TabelaVenda.DataSource = _servicoVenda.ObterTodos(_filtroVenda);
            TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtroCarro);
        }

        private void CarregarEnums()
        {
            selecionarCor.DataSource = Enum.GetValues(typeof(Cores));
            selecionarMarca.DataSource = Enum.GetValues(typeof(Marcas));
        }

        private void LimparComboBox()
        {
            selecionarCor.SelectedItem = null;
            selecionarMarca.SelectedItem = null;
        }

        private void AoClicarNoBotaoRemoverVenda(object sender, EventArgs e)
        {
            try
            {
                var linhaSelecionada = TabelaVenda.CurrentCell.RowIndex;
                var colunaDesejadaIdVenda = TabelaVenda.Columns[0].Index;
                var colunaDesejadaIdCarro = TabelaVenda.Columns["IdDoCarroVendido"].Index;

                var idSelecionado = int.Parse(TabelaVenda.Rows[linhaSelecionada].Cells[colunaDesejadaIdVenda].Value.ToString());
                var idCarroSelecionado = int.Parse(TabelaVenda.Rows[linhaSelecionada].Cells[colunaDesejadaIdCarro].Value.ToString());

                DialogResult resultado = MessageBox.Show($"Deseja excluir permanentemente a venda do Id {idSelecionado}?", "Remover Venda", MessageBoxButtons.YesNo);

                DialogResult resultadoRemoverCarro = MessageBox.Show($"Deseja excluir também permanentemente o carro ID {idCarroSelecionado} que está associado a venda ID {idSelecionado}?", "Remover Carro", MessageBoxButtons.YesNo);

                if (resultado == DialogResult.Yes && resultadoRemoverCarro == DialogResult.Yes)
                {
                    _servicoVenda.Remover(idSelecionado);
                    _servicoCarro.Remover(idCarroSelecionado);
                }
                else if(resultado == DialogResult.Yes)
                {
                    _servicoVenda.Remover(idSelecionado);
                }

                CarregarListasAtualizadas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void AoClicarNoBotaoRemoverCarro(object sender, EventArgs e)
        {
            try
            {
                var linhaSelecionada = TabelaCarro.CurrentCell.RowIndex;
                var colunaDeseada = 0;
                var idSelecionado = int.Parse(TabelaCarro.Rows[linhaSelecionada].Cells[colunaDeseada].Value.ToString());

                DialogResult resultadoRemoverCarro = MessageBox.Show($"Deseja excluir permanentemente o carro {idSelecionado}?", "Remover Carro", MessageBoxButtons.YesNo);


                if (resultadoRemoverCarro == DialogResult.Yes)
                {
                    _servicoCarro.Remover(idSelecionado);
                }

                CarregarListasAtualizadas();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
