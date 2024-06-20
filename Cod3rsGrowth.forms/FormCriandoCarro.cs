using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.forms;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;
using FluentValidation;

namespace Cod3rsGrowth.Forms
{
    public partial class CriandoCarro : Form
    {
        private ServicoCarro _servicoCarro;
        private ValidacoesCarro _validacoes;
        private FiltroCarro _filtroCarro;

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
                Marca = (Marcas)selecionarMarca.SelectedIndex,
                Cor = (Cores)selecionarCor.SelectedIndex,
                ValorDoVeiculo = selecionarValorDoVeiculo.Value,
                Flex = selecionarFlex.Checked
            };

            try
            {
                _servicoCarro.Criar(carro);
                MessageBox.Show("Carro criado com sucesso!");
                this.Close();

            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void AoClicarNoBotaoCancelarCarro_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
