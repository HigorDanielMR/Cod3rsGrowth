using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.Forms
{
    public partial class FormEditarVenda : Form
    {
        private ServicoCarro _servico;
        private Venda _venda = new Venda();
        private ServicoVenda _servicoVenda;
        private List<Carro> carros = new List<Carro>();
        private FiltroCarro _filtro = new FiltroCarro();
        private FiltroVenda _filtroVenda = new FiltroVenda();
        private List<string> comboBoxSelecionarCarro = new List<string>();

        public FormEditarVenda(ServicoCarro servicoCarro, ServicoVenda servico, Venda venda)
        {
            _venda = venda;
            _servicoVenda = servico;
            _servico = servicoCarro;

            InitializeComponent();
        }

        private void AoCarregarFomEditarVenda(object sender, EventArgs e)
        {
            CarregarComboBoxCarro();
            CarregarDados();
        }

        private void AoClicarNoBotaoCancelarEditarVenda(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro cancelar Edicao");
            }
        }

        private void AoClicarNoBotaoSalvarEdicaoVenda(object sender, EventArgs e)
        {
            try
            {
                var IdDoCarroComprado = carros[selecionandoCarro.SelectedIndex].Id;
                var carroComprado = _servico.ObterPorId(IdDoCarroComprado);

                var vendaEditada = new Venda
                {
                    Id = _venda.Id,
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

        private void CarregarComboBoxCarro()
        {
            try
            {
                carros = _servico.ObterTodos(_filtro);
                var venda = _servicoVenda.ObterTodos(_filtroVenda);

                foreach( var vendas in venda)
                {
                    if (venda.Count != 0 && vendas.Id != _venda.Id)
                        carros = carros.Where(x => x.Id != vendas.IdDoCarroVendido).ToList();
                    else
                        carros.ToList();
                }

                foreach (var car in carros)
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

        private void CarregarDados()
        {
            txtCpf.Text = _venda.Cpf;
            txtEmail.Text = _venda.Email;
            txtNome.Text = _venda.Nome;
            txtTelefone.Text = _venda.Telefone;
        }

        private void AoSelecionarCarroComprado(object sender, EventArgs e)
        {
            try
            {
                var carroSelecionado = selecionandoCarro.SelectedItem;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "Erro ao selecionar carro");
            }
        }
    }
}
