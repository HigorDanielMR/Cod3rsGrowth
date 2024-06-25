using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servicos.Servicos;
using FluentValidation;
using System.Globalization;

namespace Cod3rsGrowth.Forms
{
    public partial class FormEditarCarro : Form
    {
        private int _idDaEdicao;
        private string _modelo;
        private string _valor;
        private Cores _cor;
        private Marcas _marca;
        private bool _flex;
        private ServicoCarro _servicoCarro;
        public FormEditarCarro(string modelo, Cores cor, Marcas marca, string valor, bool flex, ServicoCarro servico, int id)
        {
            _modelo = modelo;
            _valor = valor;
            _cor = cor;
            _marca = marca;
            _flex = flex;
            _servicoCarro = servico;
            _idDaEdicao = id;
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
                this.Close();
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
                    Id = _idDaEdicao,
                    Modelo = txtModelo.Text,
                    Cor = (Cores)selecionarCor.SelectedIndex,
                    Marca = (Marcas)selecionarMarca.SelectedIndex,
                    Flex = selecionarFlex.Checked,
                    ValorDoVeiculo = valorDoVeiculoConvertido
                };
                _servicoCarro.Editar(carroEditado);
                MessageBox.Show($"Carro com ID {_idDaEdicao} editado com sucesso!", "Editando carro");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void CarregarDados()
        {
            txtModelo.Text = _modelo;
            selecionarCor.SelectedItem = _cor;
            selecionarFlex.Checked = _flex;
            selecionarMarca.SelectedItem = _marca;
            selecionarValorDoVeiculo.Text = _valor;
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

                if (textBox.Text == string.Empty || textBox.Text == "")
                    throw new ValidationException("Campo valor do veiculo esta vazio.");

                int selectionStart = textBox.SelectionStart;
                int length = textBox.Text.Length;

                string text = textBox.Text.Replace(".", "").Replace(",", "");

                if (!int.TryParse(text, out int value))
                {
                    MessageBox.Show("Entrada inválida!");
                    textBox.Text = string.Empty;
                    return;
                }

                textBox.TextChanged -= AoPreencherValorDoVeiculo;

                string formattedText = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N2}", value / 100.0);

                textBox.Text = formattedText;

                selectionStart = selectionStart + (textBox.Text.Length - length);
                if (selectionStart > textBox.Text.Length)
                    selectionStart = textBox.Text.Length;
                else if (selectionStart < 0)
                    selectionStart = 0;

                textBox.SelectionStart = selectionStart;
                textBox.TextChanged += AoPreencherValorDoVeiculo;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao tentar executar evento");
            }
        }
    }
}
