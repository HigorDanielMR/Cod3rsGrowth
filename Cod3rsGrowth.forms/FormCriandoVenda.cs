using FluentValidation;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Forms
{
    public partial class CriandoVenda : Form
    {
        private ServicoCarro _servico;
        private ServicoVenda _servicoVenda;
        private ValidacoesVenda _validacoesVenda;
        private List<Carro> carro = new List<Carro>();
        private FiltroCarro _filtro = new FiltroCarro();
        private FiltroVenda _filtroVenda = new FiltroVenda();
        private List<string> comboBoxSelecionarCarro = new List<string>();
        public CriandoVenda(ValidacoesVenda validacoes, ServicoVenda servico, ServicoCarro servicoCarro)
        {
            _servicoVenda = servico;
            _servico = servicoCarro;
            _validacoesVenda = validacoes;

            InitializeComponent();
        }

        private void CriandoVenda_Load(object sender, EventArgs e)
        {
            CarregarComboBoxCarro();
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
                this.Close();
            }
            catch (ValidationException ex)
            {
                MessageBox.Show($"{ex.Message}", "Erros ao criar venda");
            }
        }

        private void CarregarComboBoxCarro()
        {
            var var = _servico.ObterTodos(_filtro);

            foreach (var car in var)
            {
                carro.Add(car);
                comboBoxSelecionarCarro.Add($"ID: {car.Id} Modelo: {car.Modelo} Cor: {car.Cor}");
            }
            selecionandoCarro.DataSource = comboBoxSelecionarCarro;
        }

        private void AoSelecionarCarro_SelectedIndexChanged(object sender, EventArgs e)
        {
            var var = selecionandoCarro.SelectedItem;
        }
    }
}
