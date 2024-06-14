using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Dominio.Interfaces;
using Cod3rsGrowth.Servicos.Servicos;
using Cod3rsGrowth.Servicos.Validadores;

namespace Cod3rsGrowth.forms
{
    public partial class FormListagemCarro : Form
    {
        private ServicoCarro _servicoCarro;
        private FiltroCarro _filtro;
        private ValidacoesCarro _validacoesCarro;
        public FormListagemCarro(ServicoCarro servicoCarro, ValidacoesCarro validations)
        {
            _validacoesCarro = validations;
            _servicoCarro = servicoCarro;
            InitializeComponent();
        }

        private void FormListagem_Load(object sender, EventArgs e)
        {
            TabelaCarro.DataSource = _servicoCarro.ObterTodos(_filtro);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
