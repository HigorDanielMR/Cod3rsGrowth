using Cod3rsGrowth.Dominio.Entidades;
using Cod3rsGrowth.Infra.Interfaces;
using Cod3rsGrowth.Servicos.Servicos;

namespace Cod3rsGrowth.forms
{
    public partial class FormListagemCarro : Form
    {
        private ServicoCarro _servicoCarro;
        private FiltroCarro _filtro;
        private RepositorioCarro _repositorioCarro;
        public FormListagemCarro(ServicoCarro servicoCarro, RepositorioCarro repositorio)
        {
            _repositorioCarro = repositorio;
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
