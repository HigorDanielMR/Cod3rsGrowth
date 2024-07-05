using FluentValidation;
using System.Globalization;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormEditarCarro : Form
    {
        private Carro _carro = new Carro();
        private ServicoCarro _servicoCarro;

        public FormEditarCarro(ServicoCarro servicoCarro, Carro carro)
        {
            _carro = carro;
            _servicoCarro = servicoCarro;
            InitializeComponent();
        }

        private void AoCarregarFormEditarCarro(object sender, EventArgs e)
        {
            CarregarEnums();
            CarregarDados();
        }

        private void CarregarEnums()
        {
            selecionarCor.DataSource = Enum.GetValues(typeof(Cores));
            selecionarMarca.DataSource = Enum.GetValues(typeof(Marcas));
        }

        private void AoClicarNoBotaoCancelarEdicaoCarro(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro cancelar Edicao");
            }
        }

        private void AoClicarNoBotaoSalvarEdicaoCarro(object sender, EventArgs e)
        {
            try
            {
                var valorDoVeiculoConvertido = decimal.Parse(selecionarValorDoVeiculo.Text);

                var carroEditado = new Carro
                {
                    Id = _carro.Id,
                    Modelo = txtModelo.Text,
                    Flex = selecionarFlex.Checked,
                    Cor = (Cores)selecionarCor.SelectedIndex,
                    ValorDoVeiculo = valorDoVeiculoConvertido,
                    Marca = (Marcas)selecionarMarca.SelectedIndex
                };

                _servicoCarro.Editar(carroEditado);
                MessageBox.Show($"Carro com ID {_carro.Id} editado com sucesso!", "Editando carro");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao tentar salvar carro");
            }
        }

        private void CarregarDados()
        {
            txtModelo.Text = _carro.Modelo;
            selecionarFlex.Checked = _carro.Flex;
            selecionarCor.SelectedItem = _carro.Cor;
            selecionarMarca.SelectedItem = _carro.Marca;
            selecionarValorDoVeiculo.Text = _carro.ValorDoVeiculo.ToString();
        }

        private void AoComecarAPreencherValor(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != ',' && e.KeyChar != '.')
                {
                    e.Handled = true;
                }

                if ((e.KeyChar == ',' || e.KeyChar == '.') && (sender as TextBox).Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void AoPreencherValorDoVeiculo(object sender, EventArgs e)
        {
            try
            {
                TextBox textBox = sender as TextBox;

                if (textBox.Text == string.Empty)
                    throw new ValidationException("Campo valor do veiculo esta vazio.");

                int inicioDaSelecaoDoCursor = textBox.SelectionStart;
                int tamanhoDoValor = textBox.Text.Length;

                string valorSemMascara = textBox.Text.Replace(".", "").Replace(",", "");

                if (!int.TryParse(valorSemMascara, out int value))
                {
                    MessageBox.Show("Valor inválido!");
                    textBox.Text = string.Empty;
                    return;
                }

                textBox.TextChanged -= AoPreencherValorDoVeiculo;

                string formatandoTexto = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N2}", value / 100.0);

                textBox.Text = formatandoTexto;

                inicioDaSelecaoDoCursor = inicioDaSelecaoDoCursor + (textBox.Text.Length - tamanhoDoValor);
                if (inicioDaSelecaoDoCursor > textBox.Text.Length)
                    inicioDaSelecaoDoCursor = textBox.Text.Length;
                else if (inicioDaSelecaoDoCursor < 0)
                    inicioDaSelecaoDoCursor = 0;

                textBox.SelectionStart = inicioDaSelecaoDoCursor;
                textBox.TextChanged += AoPreencherValorDoVeiculo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao tentar executar evento");
            }
        }
    }
}
