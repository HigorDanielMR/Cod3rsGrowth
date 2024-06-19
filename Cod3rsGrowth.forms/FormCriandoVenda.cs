using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;
using FluentValidation;

namespace Cod3rsGrowth.Forms
{
    public partial class CriandoVenda : Form
    {
        private ValidacoesVenda _validacoesVenda;
        private ServicoVenda _servicoVenda;
        private ServicoCarro _servico;
        private FiltroVenda _filtroVenda = new FiltroVenda();
        private FiltroCarro _filtro = new FiltroCarro();
        private List<Carro> carro = new List<Carro>();
        private List<string> comboBoxSelecionarCarro = new List<string>();
        public CriandoVenda(ValidacoesVenda validacoes, ServicoVenda servico, ServicoCarro servicoCarro)
        {
            _validacoesVenda = validacoes;
            _servicoVenda = servico;
            _servico = servicoCarro;

            InitializeComponent();
            var var = _servico.ObterTodos(_filtro);

            foreach (var car in var)
            {
                carro.Add(car);
                comboBoxSelecionarCarro.Add($"ID: {car.Id} Modelo: {car.Modelo} Cor: {car.Cor}");
            }
            selecionandoCarro.DataSource = comboBoxSelecionarCarro;
        }

        private void AoClicarNoBotaoCancelarDeCriarVenda_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AoClicarNoBotaoCriarDeCriarVenda_Click(object sender, EventArgs e)
        {
            var IdDoCarroComprado = carro[selecionandoCarro.SelectedIndex].Id;
            var valorPago = carro[selecionandoCarro.SelectedIndex].ValorDoVeiculo;
            var venda = new Venda
            {
                Nome = txtNome.Text,
                Cpf = txtCpf.Text,
                Email = txtEmail.Text,
                Telefone = txtTelefone.Text,
                DataDeCompra = DateTime.Parse(txtDataDeCompra.Text),
                ValorTotal = valorPago,
                IdDoCarroVendido = IdDoCarroComprado,
                Pago = true
            };
            try
            {
                _servicoVenda.Criar(venda);
                MessageBox.Show("Venda criada com sucesso.");
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var var = selecionandoCarro.SelectedItem;
        }
    }
}
