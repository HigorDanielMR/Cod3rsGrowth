using FluentValidation;
using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.Forms
{
    public partial class FormModificarVenda : Form
    {
        private ServicoCarro _servicoCarro;
        private ServicoVenda _servicoVenda;
        private Venda _venda = new Venda();
        private List<Carro> _carros = new List<Carro>();
        private List<string> comboBoxSelecionarCarro = new List<string>();

        public FormModificarVenda(ServicoVenda servico, ServicoCarro servicoCarro)
        {
            _servicoVenda = servico;
            _servicoCarro = servicoCarro;

            InitializeComponent();
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

        private void AoClicarSalvarEdicao(object sender, EventArgs e, int id)
        {
            try
            {
                var IdDoCarroComprado = _carros[selecionandoCarro.SelectedIndex].Id;
                var carroComprado = _servicoCarro.ObterPorId(IdDoCarroComprado);

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

        public void AdicionarEventoDeEditar(int id)
        {
            SalvarVenda.Click += (sender, e) => AoClicarSalvarEdicao(sender, e, id);
        }

        public void AdicionarEventoDeCriar()
        {
            SalvarVenda.Click += (sender, e) => AoClicarNoBotaoAdicionarVenda(sender, e);
        }

        public void CarregarComboBoxCarroEditar(int id)
        {
            try
            {
                _carros = _servicoCarro.ObterTodos();
                _venda = _servicoVenda.ObterPorId(id);
                var vendas = _servicoVenda.ObterTodos();

                foreach (var venda in vendas)
                {
                    if (vendas.Count != 0 && venda.Id != _venda.Id)
                        _carros = _carros.Where(x => x.Id != venda.IdDoCarroVendido).ToList();
                    else
                        _carros.ToList();
                }

                foreach (var car in _carros)
                {
                    comboBoxSelecionarCarro.Add($"ID: {car.Id} Modelo: {car.Modelo} Cor: {car.Cor}");
                }

                selecionandoCarro.DataSource = comboBoxSelecionarCarro;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao carregar comboBox");
            }
        }

        public void CarregarComboBoxCarroCriar()
        {
            try
            {
                _carros = _servicoCarro.ObterTodos();
                var vendas = _servicoVenda.ObterTodos();

                vendas.ForEach(x => {
                    _carros = _carros
                    .Where(c => c.Id != x.IdDoCarroVendido)
                    .ToList();
                });

                _carros.ForEach(car =>
                {
                    comboBoxSelecionarCarro.Add($"ID: {car.Id} Modelo: {car.Modelo} Cor: {car.Cor}");
                });

                selecionandoCarro.DataSource = comboBoxSelecionarCarro;
            }
            catch (Exception ex)
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
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
        }
    }
}
