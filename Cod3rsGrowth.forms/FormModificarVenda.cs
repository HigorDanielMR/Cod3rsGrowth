using FluentValidation;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Forms
{
    public partial class FormModificarVenda : Form
    {
        private ServicoCarro _servico;
        private ServicoVenda _servicoVenda;
        private List<Carro> _carros = new List<Carro>();
        private Venda _venda = new Venda();
        private FiltroCarro _filtro = new FiltroCarro();
        private FiltroVenda _filtroVenda = new FiltroVenda();
        private List<string> comboBoxSelecionarCarro = new List<string>();

        public FormModificarVenda(ServicoVenda servico, ServicoCarro servicoCarro)
        {
            _servicoVenda = servico;
            _servico = servicoCarro;

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
                Close();
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
                var IdDoCarroComprado = _carros[selecionandoCarro.SelectedIndex].Id;
                var valorPago = _carros[selecionandoCarro.SelectedIndex].ValorDoVeiculo;

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
                    carros.Add(car);
                    comboBoxSelecionarCarro.Add($"ID: {car.Id} Modelo: {car.Modelo} Cor: {car.Cor}");
                });

                selecionandoCarro.DataSource = comboBoxSelecionarCarro;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao carregar comboBox");
            }
        }
        public void CarregarValoresDaVenda(int id)
        {
            var vendaSelecionada = _servicoVenda.ObterPorId(id);

            txtCpf.Text = vendaSelecionada.Cpf;
            txtEmail.Text = vendaSelecionada.Email;
            txtNome.Text = vendaSelecionada.Nome;
            txtTelefone.Text = vendaSelecionada.Telefone;
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
        
        private void AoClicarSalvarEdicao(object sender, EventArgs e, int id)
        {
            try
            {
                var IdDoCarroComprado = _carros[selecionandoCarro.SelectedIndex].Id;
                var carroComprado = _servico.ObterPorId(IdDoCarroComprado);

                var vendaEditada = new Venda
                {
                    Id = id,
                    Cpf = txtCpf.Text,
                    Email = txtEmail.Text,
                    IdDoCarroVendido = IdDoCarroComprado,
                    ValorTotal = carroComprado.ValorDoVeiculo,
                    DataDeCompra = DateTime.Parse(_venda.DataDeCompra.ToString()),
                    Nome = txtNome.Text,
                    Telefone = txtTelefone.Text
                };

                _servicoVenda.Editar(vendaEditada);
                MessageBox.Show($"Venda {_venda.Id} editada com successo!", "Editando venda");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        } 

        public void AdicionarEventoDeEditar(int id)
        {
            SalvarVenda.Click += (sender, e) => AoClicarSalvarEdicao(sender, e, id);
        }

        public void AdicionarEventoDeCriar()
        {
            SalvarVenda.Click += (sender, e) => AoClicarNoBotaoAdicionarVenda(sender, e);
        }
    }
}
