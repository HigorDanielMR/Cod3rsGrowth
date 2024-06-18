using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Enums;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;
using Microsoft.IdentityModel.Tokens;
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

            selecionarCor.SelectedItem = null;
            selecionarMarca.SelectedItem = null;
        }

        private void FormListagem_Load(object sender, EventArgs e)
        {
            TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtro);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(selecionarMarca != null && selecionarMarca.SelectedItem != null)
                {
                    var indexDesejado = selecionarMarca.SelectedIndex;
                    _filtro.Marca = (Marcas)indexDesejado;
                }

                if (!txtProcurar.Text.IsNullOrEmpty())
                {
                    _filtro.Modelo = txtProcurar.Text;
                }
                if(selecionarCor != null && selecionarCor.SelectedItem != null)
                {
                    var indexdesejado = (Cores)selecionarCor.SelectedIndex;
                    _filtro.Cor = indexdesejado;
                }
            }
            
            catch(Exception ex)
            {
                MessageBox.Show($"{ex.Message}");
            }
            
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

            txtProcurar.Clear();
            selecionarCor.SelectedItem = null;
            selecionarMarca.SelectedItem = null;

            TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtro);
        }
    }
}
