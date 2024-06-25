using FluentValidation;
using System.Globalization;
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
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    Email = txtEmail.Text,
                    Telefone = txtTelefone.Text,
                    DataDeCompra = DateTime.Parse(DateTime.Now.ToString().Replace(" 00:00:00", "")),
                    ValorTotal = valorPago,
                    IdDoCarroVendido = IdDoCarroComprado,
                    Pago = true
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
                IEnumerable<Carro> obter;
                var carros = _servico.ObterTodos(_filtro);
                var venda = _servicoVenda.ObterTodos(_filtroVenda);
                if (venda.Count != 0)
                    obter = carros.Where(x => x.Id != venda.FirstOrDefault().IdDoCarroVendido);
                else
                    obter = carros;

                foreach (var car in obter)
                {
                    carro.Add(car);
                    comboBoxSelecionarCarro.Add($"ID: {car.Id} Modelo: {car.Modelo} Cor: {car.Cor}");
                }
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
                var var = selecionandoCarro.SelectedItem;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
