using FluentValidation;
using System.Globalization;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Forms
{
    public partial class FormModificarCarro : Form
    {
        private Carro _carro;
        private ServicoCarro _servicoCarro;

        public FormModificarCarro(ServicoCarro servico)
        {
            _servicoCarro = servico;

            InitializeComponent();
        }

        private void AoCarregarFormCriarCarro(object sender, EventArgs e)
        {
        }

        public void CarregarEnums()
        {
            selecionarCor.DataSource = Enum.GetValues(typeof(Cores));
            selecionarMarca.DataSource = Enum.GetValues(typeof(Marcas));
        }

        public void LimparComboBox()
        {
            selecionarCor.SelectedItem = null;
            selecionarMarca.SelectedItem = null;
        }

        private void AoClicarNoBotaoAdicionar(object sender, EventArgs e)
        {
            try
            {
                var valorDoVeiculoConvertido = decimal.Parse(selecionarValorDoVeiculo.Text);

                var carro = new Carro
                {
                    Modelo = txtModelo.Text,
                    Flex = selecionarFlex.Checked,
                    Cor = (Cores)selecionarCor.SelectedIndex,
                    Marca = (Marcas)selecionarMarca.SelectedIndex,
                    ValorDoVeiculo = valorDoVeiculoConvertido
                };

                _servicoCarro.Criar(carro);
                MessageBox.Show("Carro criado com sucesso!");
                Close();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao criar");
            }
        }

        private void AoClicarNoBotaoCancelarCarro(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao cancelar");
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
                MessageBox.Show($"Carro com ID {_carro.Id} editado com sucesso!", "Sucesso");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao tentar salvar carro");
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

        private void AoPreencherValorDoVeiculo(object sender, KeyPressEventArgs e)
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

        public void AdicionarEventoDeEditar(int id)
        {
            SalvarCarro.Click += (sender, e) => AoClicarNoBotaoSalvarEdicaoCarro(sender, e);
        }

        public void AdicionarEventoDeCriar()
        {
            SalvarCarro.Click += (sender, e) => AoClicarNoBotaoAdicionar(sender, e);
        }

        public void CarregarValoresDoCarro(int id)
        {
            _carro = _servicoCarro.ObterPorId(id);

            txtModelo.Text = _carro.Modelo;
            selecionarFlex.Checked = _carro.Flex;
            selecionarCor.SelectedItem = _carro.Cor;
            selecionarMarca.SelectedItem = _carro.Marca;
            selecionarValorDoVeiculo.Text = _carro.ValorDoVeiculo.ToString();
        }
    }
}
