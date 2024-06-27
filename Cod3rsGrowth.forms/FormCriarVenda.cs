using FluentValidation;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Forms
{
    public partial class FormCriarVenda : Form
    {
        private ServicoCarro _servico;
        private ServicoVenda _servicoVenda;
        private ValidacoesVenda _validacoesVenda;
        private List<Carro> carro = new List<Carro>();
        private FiltroCarro _filtro = new FiltroCarro();
        private FiltroVenda _filtroVenda = new FiltroVenda();
        private List<string> comboBoxSelecionarCarro = new List<string>();

        public FormCriarVenda(ValidacoesVenda validacoes, ServicoVenda servico, ServicoCarro servicoCarro)
        {
            _servicoVenda = servico;
            _servico = servicoCarro;
            _validacoesVenda = validacoes;

            InitializeComponent();
        }

        private void AoCarregarFormCriarVenda(object sender, EventArgs e)
        {
            CarregarComboBoxCarro();
        }

        private void AoClicarNoBotaoCancelarDeVenda(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao cancelar");
            }
        }

        private void AoClicarNoBotaoAdicionarVenda(object sender, EventArgs e)
        {
            try
            {
                var IdDoCarroComprado = carro[selecionandoCarro.SelectedIndex].Id;
                var valorPago = carro[selecionandoCarro.SelectedIndex].ValorDoVeiculo;

                var venda = new Venda
                {
                    Pago = true,
                    Cpf = txtCpf.Text,
                    Nome = txtNome.Text,
                    Email = txtEmail.Text,
                    ValorTotal = valorPago,
                    Telefone = txtTelefone.Text,
                    IdDoCarroVendido = IdDoCarroComprado,
                    DataDeCompra = DateTime.Parse(DateTime.Now.ToString())
                };

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
            try
            {
                var carros = _servico.ObterTodos(_filtro);
                var vendas = _servicoVenda.ObterTodos(_filtroVenda);

                vendas.ForEach(x => {
                    carros = carros
                    .Where(c => c.Id != x.IdDoCarroVendido)
                    .ToList();
                });

                carros.ForEach(car =>
                {
                    carro.Add(car);
                    comboBoxSelecionarCarro.Add($"ID: {car.Id} Modelo: {car.Modelo} Cor: {car.Cor}");
                });

                selecionandoCarro.DataSource = comboBoxSelecionarCarro;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }

        private void AoSelecionarCarro(object sender, EventArgs e)
        {
            try
            {
                var carroSelecionado = selecionandoCarro.SelectedItem;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
