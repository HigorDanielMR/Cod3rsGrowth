using FluentValidation;
using System.Globalization;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Forms
{
    public partial class CriandoCarro : Form
    {
        private FiltroCarro _filtroCarro;
        private ServicoCarro _servicoCarro;
        private ValidacoesCarro _validacoes;

        public CriandoCarro(ServicoCarro servico, ValidacoesCarro validacoes)
        {
            _servicoCarro = servico;
            _validacoes = validacoes;
            InitializeComponent();
        }

        private void FormCriandoCarro_Load(object sender, EventArgs e)
        {
            selecionarCor.DataSource = Enum.GetValues(typeof(Cores));
            selecionarMarca.DataSource = Enum.GetValues(typeof(Marcas));

            selecionarCor.SelectedItem = null;
            selecionarMarca.SelectedItem = null;
        }

        private void AoClicarNoBotaoCriarCarro_Click(object sender, EventArgs e)
        {
            var carro = new Carro
            {
                Modelo = txtModelo.Text,
                Flex = selecionarFlex.Checked,
                Cor = (Cores)selecionarCor.SelectedIndex,
                Marca = (Marcas)selecionarMarca.SelectedIndex,
                ValorDoVeiculo = decimal.Parse(selecionarValorDoVeiculo.Text)
            };

            try
            {
                _servicoCarro.Criar(carro);
                MessageBox.Show("Carro criado com sucesso!");
                this.Close();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"{ex.Message}", "Erros");
            }
        }

        private void AoClicarNoBotaoCancelarCarro_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void selecionarValorDoVeiculo_KeyPress(object sender, KeyPressEventArgs e)
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

        private void selecionarValorDoVeiculo_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = sender as TextBox;

            if (textBox.Text == string.Empty)
                return;

            int selectionStart = textBox.SelectionStart;
            int length = textBox.Text.Length;

            string text = textBox.Text.Replace(".", "").Replace(",", "");

            if (!int.TryParse(text, out int value))
            {
                MessageBox.Show("Entrada inválida!");
                textBox.Text = string.Empty;
                return;
            }

            textBox.TextChanged -= selecionarValorDoVeiculo_TextChanged;

            string formattedText = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N2}", value / 100.0);

            textBox.Text = formattedText;

            selectionStart = selectionStart + (textBox.Text.Length - length);
            if (selectionStart > textBox.Text.Length)
                selectionStart = textBox.Text.Length;
            else if (selectionStart < 0)
                selectionStart = 0;

            textBox.SelectionStart = selectionStart;
            textBox.TextChanged += selecionarValorDoVeiculo_TextChanged;


        }
    }
}
