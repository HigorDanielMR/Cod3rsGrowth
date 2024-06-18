using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;
using System.Data;

namespace Cod3rsGrowth.forms
{
    public partial class FormListagemCarro : Form
    {

        private ServicoCarro _servicoCarro;
        private ValidacoesCarro _validacoesCarro;
        private FiltroCarro _filtro = new FiltroCarro();

        public FormListagemCarro(ServicoCarro servicoCarro, ValidacoesCarro validations)
        {
            _validacoesCarro = validations;
            _servicoCarro = servicoCarro;

            InitializeComponent();

            selecionarCor.DataSource = Enum.GetValues(typeof(Cores));
            selecionarMarca.DataSource = Enum.GetValues(typeof(Marcas));
        }

        private void FormListagem_Load(object sender, EventArgs e)
        {
            TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtro);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var indexDesejado = selecionarMarca.SelectedIndex;
            _filtro.Marca = (Marcas)indexDesejado;

            TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtro);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (_filtro.Marca != null)
            {
                _filtro.Marca = null;
            }
            if (_filtro.Modelo != null)
            {
                _filtro.Modelo = null;
            }
            if (_filtro.Cor != null)
            {
                _filtro.Cor = null;
            }

            TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtro);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (txtProcurar.Text == "")
            {
                _filtro = null;

                TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtro);
            }
            else
            {
                _filtro.Modelo = txtProcurar.Text;

                TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtro);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var indexDesejado = (Cores)selecionarCor.SelectedIndex;
            _filtro.Cor = indexDesejado;
            TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtro);
        }

    }
}
