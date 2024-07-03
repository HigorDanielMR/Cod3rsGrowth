namespace Cod3rsGrowth.forms
{
    partial class FormListagem
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            TabelaCarro = new DataGridView();
            ColunaIdCarro = new DataGridViewTextBoxColumn();
            ColunaMarca = new DataGridViewTextBoxColumn();
            ColunaModelo = new DataGridViewTextBoxColumn();
            ColunaCor = new DataGridViewTextBoxColumn();
            ColunaValorDoVeiculo = new DataGridViewTextBoxColumn();
            ColunaFlex = new DataGridViewCheckBoxColumn();
            carroBindingSource = new BindingSource(components);
            label2 = new Label();
            FiltrarCarro = new Button();
            selecionarMarca = new ComboBox();
            LimparFiltroCarro = new Button();
            panel1 = new Panel();
            panel7 = new Panel();
            label1 = new Label();
            selecionarCor = new ComboBox();
            label3 = new Label();
            txtProcurar = new TextBox();
            carroBindingSource1 = new BindingSource(components);
            panel2 = new Panel();
            tabelaDeControleVenda = new TabControl();
            tabPage1 = new TabPage();
            panel5 = new Panel();
            BotaoEditarVenda = new Button();
            BotaoRemoverVenda = new Button();
            CriarVenda = new Button();
            panel4 = new Panel();
            label7 = new Label();
            procurarDataFinal = new MaskedTextBox();
            panel8 = new Panel();
            LimparFIltroVenda = new Button();
            FiltrarVenda = new Button();
            label4 = new Label();
            procurarDataInicial = new MaskedTextBox();
            label5 = new Label();
            txtProcurarEmail = new TextBox();
            CPF = new Label();
            procurarCpf = new MaskedTextBox();
            txtProcurarNome = new TextBox();
            label6 = new Label();
            panel3 = new Panel();
            TabelaVenda = new DataGridView();
            ColunaIdVenda = new DataGridViewTextBoxColumn();
            ColunaNome = new DataGridViewTextBoxColumn();
            colunaCpf = new DataGridViewTextBoxColumn();
            ColunaEmail = new DataGridViewTextBoxColumn();
            ColunaTelefone = new DataGridViewTextBoxColumn();
            IdDoCarroVendido = new DataGridViewTextBoxColumn();
            ColunaDataDeCompra = new DataGridViewTextBoxColumn();
            ColunaValorTotal = new DataGridViewTextBoxColumn();
            ColunaPago = new DataGridViewCheckBoxColumn();
            vendaBindingSource = new BindingSource(components);
            tabPage2 = new TabPage();
            panel6 = new Panel();
            BotaoEditarCarro = new Button();
            BotaoRemoverCarro = new Button();
            CriarCarro = new Button();
            ((System.ComponentModel.ISupportInitialize)TabelaCarro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)carroBindingSource).BeginInit();
            panel1.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)carroBindingSource1).BeginInit();
            panel2.SuspendLayout();
            tabelaDeControleVenda.SuspendLayout();
            tabPage1.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel8.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)TabelaVenda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vendaBindingSource).BeginInit();
            tabPage2.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // TabelaCarro
            // 
            TabelaCarro.AllowUserToAddRows = false;
            TabelaCarro.AllowUserToDeleteRows = false;
            TabelaCarro.AllowUserToResizeColumns = false;
            TabelaCarro.AllowUserToResizeRows = false;
            TabelaCarro.AutoGenerateColumns = false;
            TabelaCarro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            TabelaCarro.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            TabelaCarro.BackgroundColor = SystemColors.Control;
            TabelaCarro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TabelaCarro.Columns.AddRange(new DataGridViewColumn[] { ColunaIdCarro, ColunaMarca, ColunaModelo, ColunaCor, ColunaValorDoVeiculo, ColunaFlex });
            TabelaCarro.DataSource = carroBindingSource;
            TabelaCarro.Dock = DockStyle.Fill;
            TabelaCarro.Location = new Point(0, 0);
            TabelaCarro.Name = "TabelaCarro";
            TabelaCarro.RowTemplate.Height = 25;
            TabelaCarro.Size = new Size(824, 286);
            TabelaCarro.TabIndex = 0;
            // 
            // ColunaIdCarro
            // 
            ColunaIdCarro.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColunaIdCarro.DataPropertyName = "Id";
            ColunaIdCarro.HeaderText = "ID";
            ColunaIdCarro.Name = "ColunaIdCarro";
            ColunaIdCarro.Width = 43;
            // 
            // ColunaMarca
            // 
            ColunaMarca.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColunaMarca.DataPropertyName = "Marca";
            ColunaMarca.HeaderText = "Marca";
            ColunaMarca.Name = "ColunaMarca";
            // 
            // ColunaModelo
            // 
            ColunaModelo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColunaModelo.DataPropertyName = "Modelo";
            ColunaModelo.HeaderText = "Modelo";
            ColunaModelo.Name = "ColunaModelo";
            // 
            // ColunaCor
            // 
            ColunaCor.DataPropertyName = "Cor";
            ColunaCor.HeaderText = "Cor";
            ColunaCor.Name = "ColunaCor";
            ColunaCor.Width = 51;
            // 
            // ColunaValorDoVeiculo
            // 
            ColunaValorDoVeiculo.DataPropertyName = "ValorDoVeiculo";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            ColunaValorDoVeiculo.DefaultCellStyle = dataGridViewCellStyle1;
            ColunaValorDoVeiculo.HeaderText = "Preço";
            ColunaValorDoVeiculo.Name = "ColunaValorDoVeiculo";
            ColunaValorDoVeiculo.Width = 62;
            // 
            // ColunaFlex
            // 
            ColunaFlex.DataPropertyName = "Flex";
            ColunaFlex.HeaderText = "Flex";
            ColunaFlex.Name = "ColunaFlex";
            ColunaFlex.Width = 34;
            // 
            // carroBindingSource
            // 
            carroBindingSource.DataSource = typeof(Dominio.Entidades.Carro);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(14, 15);
            label2.Name = "label2";
            label2.Size = new Size(51, 19);
            label2.TabIndex = 1;
            label2.Text = "Marca";
            // 
            // FiltrarCarro
            // 
            FiltrarCarro.BackColor = Color.DarkGray;
            FiltrarCarro.FlatAppearance.BorderColor = Color.Black;
            FiltrarCarro.FlatAppearance.MouseOverBackColor = Color.Snow;
            FiltrarCarro.FlatStyle = FlatStyle.Flat;
            FiltrarCarro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FiltrarCarro.Location = new Point(3, 32);
            FiltrarCarro.MaximumSize = new Size(94, 28);
            FiltrarCarro.Name = "FiltrarCarro";
            FiltrarCarro.Size = new Size(94, 28);
            FiltrarCarro.TabIndex = 4;
            FiltrarCarro.Text = "Filtrar";
            FiltrarCarro.UseVisualStyleBackColor = false;
            FiltrarCarro.Click += AoClicarNoBotaoFiltrarDaTabelaCarro;
            // 
            // selecionarMarca
            // 
            selecionarMarca.FormattingEnabled = true;
            selecionarMarca.Items.AddRange(new object[] { "  " });
            selecionarMarca.Location = new Point(14, 37);
            selecionarMarca.Name = "selecionarMarca";
            selecionarMarca.Size = new Size(131, 23);
            selecionarMarca.TabIndex = 1;
            // 
            // LimparFiltroCarro
            // 
            LimparFiltroCarro.BackColor = Color.DarkGray;
            LimparFiltroCarro.FlatAppearance.BorderColor = Color.Black;
            LimparFiltroCarro.FlatStyle = FlatStyle.Flat;
            LimparFiltroCarro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LimparFiltroCarro.Location = new Point(117, 32);
            LimparFiltroCarro.MaximumSize = new Size(94, 28);
            LimparFiltroCarro.Name = "LimparFiltroCarro";
            LimparFiltroCarro.Size = new Size(94, 28);
            LimparFiltroCarro.TabIndex = 5;
            LimparFiltroCarro.Text = "Limpar Filtro";
            LimparFiltroCarro.UseVisualStyleBackColor = false;
            LimparFiltroCarro.Click += AoClicarNoBotaoLimparFiltroDaTabelaCarro;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(selecionarCor);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtProcurar);
            panel1.Controls.Add(selecionarMarca);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(3, 3);
            panel1.MinimumSize = new Size(800, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(858, 70);
            panel1.TabIndex = 6;
            // 
            // panel7
            // 
            panel7.Controls.Add(LimparFiltroCarro);
            panel7.Controls.Add(FiltrarCarro);
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(627, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(231, 70);
            panel7.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(333, 15);
            label1.Name = "label1";
            label1.Size = new Size(33, 19);
            label1.TabIndex = 9;
            label1.Text = "Cor";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // selecionarCor
            // 
            selecionarCor.FormattingEnabled = true;
            selecionarCor.Items.AddRange(new object[] { " " });
            selecionarCor.Location = new Point(333, 37);
            selecionarCor.Name = "selecionarCor";
            selecionarCor.Size = new Size(128, 23);
            selecionarCor.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(151, 15);
            label3.Name = "label3";
            label3.Size = new Size(50, 19);
            label3.TabIndex = 7;
            label3.Text = "Nome";
            // 
            // txtProcurar
            // 
            txtProcurar.Location = new Point(151, 37);
            txtProcurar.Name = "txtProcurar";
            txtProcurar.Size = new Size(176, 23);
            txtProcurar.TabIndex = 2;
            // 
            // carroBindingSource1
            // 
            carroBindingSource1.DataSource = typeof(Dominio.Entidades.Carro);
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(TabelaCarro);
            panel2.Location = new Point(17, 83);
            panel2.Name = "panel2";
            panel2.Size = new Size(824, 286);
            panel2.TabIndex = 7;
            // 
            // tabelaDeControleVenda
            // 
            tabelaDeControleVenda.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabelaDeControleVenda.Controls.Add(tabPage1);
            tabelaDeControleVenda.Controls.Add(tabPage2);
            tabelaDeControleVenda.Location = new Point(0, -1);
            tabelaDeControleVenda.Name = "tabelaDeControleVenda";
            tabelaDeControleVenda.SelectedIndex = 0;
            tabelaDeControleVenda.Size = new Size(872, 464);
            tabelaDeControleVenda.TabIndex = 8;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.Controls.Add(panel5);
            tabPage1.Controls.Add(panel4);
            tabPage1.Controls.Add(panel3);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(864, 436);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Tabela de Vendas";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ButtonHighlight;
            panel5.Controls.Add(BotaoEditarVenda);
            panel5.Controls.Add(BotaoRemoverVenda);
            panel5.Controls.Add(CriarVenda);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(3, 375);
            panel5.Name = "panel5";
            panel5.Size = new Size(858, 58);
            panel5.TabIndex = 9;
            // 
            // BotaoEditarVenda
            // 
            BotaoEditarVenda.BackColor = Color.DarkGray;
            BotaoEditarVenda.FlatStyle = FlatStyle.Flat;
            BotaoEditarVenda.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BotaoEditarVenda.Location = new Point(630, 27);
            BotaoEditarVenda.Name = "BotaoEditarVenda";
            BotaoEditarVenda.Size = new Size(94, 28);
            BotaoEditarVenda.TabIndex = 9;
            BotaoEditarVenda.Text = "Editar";
            BotaoEditarVenda.UseVisualStyleBackColor = false;
            BotaoEditarVenda.Click += AoClicarNoBotaoEditarVenda;
            // 
            // BotaoRemoverVenda
            // 
            BotaoRemoverVenda.BackColor = Color.DarkGray;
            BotaoRemoverVenda.FlatStyle = FlatStyle.Flat;
            BotaoRemoverVenda.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BotaoRemoverVenda.Location = new Point(743, 27);
            BotaoRemoverVenda.Name = "BotaoRemoverVenda";
            BotaoRemoverVenda.Size = new Size(94, 28);
            BotaoRemoverVenda.TabIndex = 10;
            BotaoRemoverVenda.Text = "Remover";
            BotaoRemoverVenda.UseVisualStyleBackColor = false;
            BotaoRemoverVenda.Click += AoClicarNoBotaoRemoverVenda;
            // 
            // CriarVenda
            // 
            CriarVenda.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CriarVenda.BackColor = Color.DarkGray;
            CriarVenda.FlatAppearance.BorderColor = Color.Black;
            CriarVenda.FlatStyle = FlatStyle.Flat;
            CriarVenda.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            CriarVenda.Location = new Point(519, 27);
            CriarVenda.MaximumSize = new Size(94, 28);
            CriarVenda.Name = "CriarVenda";
            CriarVenda.Size = new Size(94, 28);
            CriarVenda.TabIndex = 8;
            CriarVenda.Text = "Criar";
            CriarVenda.UseVisualStyleBackColor = false;
            CriarVenda.Click += AoClicarNoBotaoCriarVenda;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.Controls.Add(label7);
            panel4.Controls.Add(procurarDataFinal);
            panel4.Controls.Add(panel8);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(procurarDataInicial);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(txtProcurarEmail);
            panel4.Controls.Add(CPF);
            panel4.Controls.Add(procurarCpf);
            panel4.Controls.Add(txtProcurarNome);
            panel4.Controls.Add(label6);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(3, 3);
            panel4.MinimumSize = new Size(800, 60);
            panel4.Name = "panel4";
            panel4.Size = new Size(858, 70);
            panel4.TabIndex = 8;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(512, 15);
            label7.Name = "label7";
            label7.Size = new Size(75, 19);
            label7.TabIndex = 17;
            label7.Text = "Data Final";
            // 
            // procurarDataFinal
            // 
            procurarDataFinal.Location = new Point(512, 37);
            procurarDataFinal.Mask = "00/00/0000";
            procurarDataFinal.Name = "procurarDataFinal";
            procurarDataFinal.Size = new Size(79, 23);
            procurarDataFinal.TabIndex = 5;
            procurarDataFinal.ValidatingType = typeof(DateTime);
            // 
            // panel8
            // 
            panel8.Controls.Add(LimparFIltroVenda);
            panel8.Controls.Add(FiltrarVenda);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(627, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(231, 70);
            panel8.TabIndex = 14;
            // 
            // LimparFIltroVenda
            // 
            LimparFIltroVenda.BackColor = Color.DarkGray;
            LimparFIltroVenda.FlatAppearance.BorderColor = Color.Black;
            LimparFIltroVenda.FlatStyle = FlatStyle.Flat;
            LimparFIltroVenda.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            LimparFIltroVenda.Location = new Point(116, 33);
            LimparFIltroVenda.MaximumSize = new Size(94, 28);
            LimparFIltroVenda.Name = "LimparFIltroVenda";
            LimparFIltroVenda.Size = new Size(94, 28);
            LimparFIltroVenda.TabIndex = 7;
            LimparFIltroVenda.Text = "Limpar FIltro";
            LimparFIltroVenda.UseVisualStyleBackColor = false;
            LimparFIltroVenda.Click += AoClicarNoBotaoLimparFiltroDaTabelaVenda;
            // 
            // FiltrarVenda
            // 
            FiltrarVenda.BackColor = Color.DarkGray;
            FiltrarVenda.FlatAppearance.BorderColor = Color.Black;
            FiltrarVenda.FlatStyle = FlatStyle.Flat;
            FiltrarVenda.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            FiltrarVenda.ForeColor = SystemColors.ControlText;
            FiltrarVenda.Location = new Point(3, 33);
            FiltrarVenda.MaximumSize = new Size(94, 28);
            FiltrarVenda.Name = "FiltrarVenda";
            FiltrarVenda.Size = new Size(94, 28);
            FiltrarVenda.TabIndex = 6;
            FiltrarVenda.Text = "Filtrar";
            FiltrarVenda.UseVisualStyleBackColor = false;
            FiltrarVenda.Click += AoClicarNoBotaoFiltrarNaTabelaVenda;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(427, 15);
            label4.Name = "label4";
            label4.Size = new Size(83, 19);
            label4.TabIndex = 13;
            label4.Text = "Data Inicial";
            // 
            // procurarDataInicial
            // 
            procurarDataInicial.Location = new Point(427, 37);
            procurarDataInicial.Mask = "00/00/0000";
            procurarDataInicial.Name = "procurarDataInicial";
            procurarDataInicial.Size = new Size(79, 23);
            procurarDataInicial.TabIndex = 4;
            procurarDataInicial.ValidatingType = typeof(DateTime);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(246, 15);
            label5.Name = "label5";
            label5.Size = new Size(51, 19);
            label5.TabIndex = 10;
            label5.Text = "E-mail";
            // 
            // txtProcurarEmail
            // 
            txtProcurarEmail.Location = new Point(246, 37);
            txtProcurarEmail.Name = "txtProcurarEmail";
            txtProcurarEmail.Size = new Size(175, 23);
            txtProcurarEmail.TabIndex = 3;
            // 
            // CPF
            // 
            CPF.AutoSize = true;
            CPF.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            CPF.Location = new Point(157, 15);
            CPF.Name = "CPF";
            CPF.Size = new Size(34, 19);
            CPF.TabIndex = 7;
            CPF.Text = "CPF";
            // 
            // procurarCpf
            // 
            procurarCpf.Location = new Point(157, 37);
            procurarCpf.Mask = "000,000,000-00";
            procurarCpf.Name = "procurarCpf";
            procurarCpf.Size = new Size(83, 23);
            procurarCpf.TabIndex = 2;
            // 
            // txtProcurarNome
            // 
            txtProcurarNome.Location = new Point(17, 37);
            txtProcurarNome.Name = "txtProcurarNome";
            txtProcurarNome.Size = new Size(134, 23);
            txtProcurarNome.TabIndex = 1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(17, 15);
            label6.Name = "label6";
            label6.Size = new Size(50, 19);
            label6.TabIndex = 1;
            label6.Text = "Nome";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(TabelaVenda);
            panel3.Location = new Point(20, 79);
            panel3.Name = "panel3";
            panel3.Size = new Size(820, 293);
            panel3.TabIndex = 7;
            // 
            // TabelaVenda
            // 
            TabelaVenda.AllowUserToAddRows = false;
            TabelaVenda.AllowUserToDeleteRows = false;
            TabelaVenda.AllowUserToResizeColumns = false;
            TabelaVenda.AllowUserToResizeRows = false;
            TabelaVenda.AutoGenerateColumns = false;
            TabelaVenda.BackgroundColor = SystemColors.Control;
            TabelaVenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TabelaVenda.Columns.AddRange(new DataGridViewColumn[] { ColunaIdVenda, ColunaNome, colunaCpf, ColunaEmail, ColunaTelefone, IdDoCarroVendido, ColunaDataDeCompra, ColunaValorTotal, ColunaPago });
            TabelaVenda.DataSource = vendaBindingSource;
            TabelaVenda.Dock = DockStyle.Fill;
            TabelaVenda.Location = new Point(0, 0);
            TabelaVenda.Name = "TabelaVenda";
            TabelaVenda.ReadOnly = true;
            TabelaVenda.RowTemplate.Height = 25;
            TabelaVenda.Size = new Size(820, 293);
            TabelaVenda.TabIndex = 1;
            // 
            // ColunaIdVenda
            // 
            ColunaIdVenda.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColunaIdVenda.DataPropertyName = "Id";
            ColunaIdVenda.HeaderText = "ID";
            ColunaIdVenda.Name = "ColunaIdVenda";
            ColunaIdVenda.ReadOnly = true;
            ColunaIdVenda.Width = 43;
            // 
            // ColunaNome
            // 
            ColunaNome.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColunaNome.DataPropertyName = "Nome";
            ColunaNome.HeaderText = "Nome";
            ColunaNome.Name = "ColunaNome";
            ColunaNome.ReadOnly = true;
            // 
            // colunaCpf
            // 
            colunaCpf.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            colunaCpf.DataPropertyName = "Cpf";
            colunaCpf.HeaderText = "CPF";
            colunaCpf.Name = "colunaCpf";
            colunaCpf.ReadOnly = true;
            colunaCpf.Width = 53;
            // 
            // ColunaEmail
            // 
            ColunaEmail.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColunaEmail.DataPropertyName = "Email";
            ColunaEmail.HeaderText = "Email";
            ColunaEmail.Name = "ColunaEmail";
            ColunaEmail.ReadOnly = true;
            ColunaEmail.Width = 61;
            // 
            // ColunaTelefone
            // 
            ColunaTelefone.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColunaTelefone.DataPropertyName = "Telefone";
            ColunaTelefone.HeaderText = "Telefone";
            ColunaTelefone.Name = "ColunaTelefone";
            ColunaTelefone.ReadOnly = true;
            ColunaTelefone.Width = 76;
            // 
            // IdDoCarroVendido
            // 
            IdDoCarroVendido.DataPropertyName = "IdDoCarroVendido";
            IdDoCarroVendido.HeaderText = "Id do Carro vendido";
            IdDoCarroVendido.Name = "IdDoCarroVendido";
            IdDoCarroVendido.ReadOnly = true;
            // 
            // ColunaDataDeCompra
            // 
            ColunaDataDeCompra.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColunaDataDeCompra.DataPropertyName = "DataDeCompra";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            ColunaDataDeCompra.DefaultCellStyle = dataGridViewCellStyle2;
            ColunaDataDeCompra.HeaderText = "Data da compra";
            ColunaDataDeCompra.Name = "ColunaDataDeCompra";
            ColunaDataDeCompra.ReadOnly = true;
            ColunaDataDeCompra.Width = 106;
            // 
            // ColunaValorTotal
            // 
            ColunaValorTotal.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ColunaValorTotal.DataPropertyName = "ValorTotal";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            ColunaValorTotal.DefaultCellStyle = dataGridViewCellStyle3;
            ColunaValorTotal.HeaderText = "Valor total";
            ColunaValorTotal.Name = "ColunaValorTotal";
            ColunaValorTotal.ReadOnly = true;
            ColunaValorTotal.Width = 79;
            // 
            // ColunaPago
            // 
            ColunaPago.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColunaPago.DataPropertyName = "Pago";
            ColunaPago.HeaderText = "Pago";
            ColunaPago.Name = "ColunaPago";
            ColunaPago.ReadOnly = true;
            ColunaPago.Width = 40;
            // 
            // vendaBindingSource
            // 
            vendaBindingSource.DataSource = typeof(Dominio.Entidades.Venda);
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel6);
            tabPage2.Controls.Add(panel2);
            tabPage2.Controls.Add(panel1);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(864, 436);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Tabela de Carros";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel6.Controls.Add(BotaoEditarCarro);
            panel6.Controls.Add(BotaoRemoverCarro);
            panel6.Controls.Add(CriarCarro);
            panel6.Location = new Point(3, 375);
            panel6.Name = "panel6";
            panel6.Size = new Size(858, 58);
            panel6.TabIndex = 8;
            // 
            // BotaoEditarCarro
            // 
            BotaoEditarCarro.BackColor = Color.DarkGray;
            BotaoEditarCarro.FlatStyle = FlatStyle.Flat;
            BotaoEditarCarro.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BotaoEditarCarro.Location = new Point(630, 27);
            BotaoEditarCarro.Name = "BotaoEditarCarro";
            BotaoEditarCarro.Size = new Size(94, 28);
            BotaoEditarCarro.TabIndex = 7;
            BotaoEditarCarro.Text = "Editar";
            BotaoEditarCarro.UseVisualStyleBackColor = false;
            BotaoEditarCarro.Click += AoClicarNoBotaoEditarCarro;
            // 
            // BotaoRemoverCarro
            // 
            BotaoRemoverCarro.BackColor = Color.DarkGray;
            BotaoRemoverCarro.FlatStyle = FlatStyle.Flat;
            BotaoRemoverCarro.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BotaoRemoverCarro.Location = new Point(744, 27);
            BotaoRemoverCarro.Name = "BotaoRemoverCarro";
            BotaoRemoverCarro.Size = new Size(94, 28);
            BotaoRemoverCarro.TabIndex = 8;
            BotaoRemoverCarro.Text = "Remover";
            BotaoRemoverCarro.UseVisualStyleBackColor = false;
            BotaoRemoverCarro.Click += AoClicarNoBotaoRemoverCarro;
            // 
            // CriarCarro
            // 
            CriarCarro.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            CriarCarro.BackColor = Color.DarkGray;
            CriarCarro.FlatAppearance.BorderColor = Color.Black;
            CriarCarro.FlatStyle = FlatStyle.Flat;
            CriarCarro.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            CriarCarro.Location = new Point(518, 27);
            CriarCarro.MaximumSize = new Size(94, 28);
            CriarCarro.Name = "CriarCarro";
            CriarCarro.Size = new Size(94, 28);
            CriarCarro.TabIndex = 6;
            CriarCarro.Text = "Criar";
            CriarCarro.UseVisualStyleBackColor = false;
            CriarCarro.Click += AoClicarNoBotaoCriarCarro;
            // 
            // FormListagem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(874, 463);
            Controls.Add(tabelaDeControleVenda);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "FormListagem";
            Text = "Cod3rsGrowth";
            Load += AoCarregarFormListagem;
            ((System.ComponentModel.ISupportInitialize)TabelaCarro).EndInit();
            ((System.ComponentModel.ISupportInitialize)carroBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)carroBindingSource1).EndInit();
            panel2.ResumeLayout(false);
            tabelaDeControleVenda.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel8.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)TabelaVenda).EndInit();
            ((System.ComponentModel.ISupportInitialize)vendaBindingSource).EndInit();
            tabPage2.ResumeLayout(false);
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView TabelaCarro;
        private BindingSource carroBindingSource;
        private Label label2;
        private Button FiltrarCarro;
        private ComboBox selecionarMarca;
        private Button LimparFiltroCarro;
        private Panel panel1;
        private Panel panel2;
        private ComboBox selecionarCor;
        private Label label3;
        private TextBox txtProcurar;
        private BindingSource carroBindingSource1;
        private TabControl tabelaDeControleVenda;
        private TabPage tabPage2;
        private BindingSource vendaBindingSource;
        private Panel panel6;
        private TabPage tabPage1;
        private Panel panel5;
        private Panel panel4;
        private Label label4;
        private MaskedTextBox procurarDataInicial;
        private Label label5;
        private TextBox txtProcurarEmail;
        private Label CPF;
        private MaskedTextBox procurarCpf;
        private TextBox txtProcurarNome;
        private Button LimparFIltroVenda;
        private Label label6;
        private Button FiltrarVenda;
        private Panel panel3;
        private DataGridView TabelaVenda;
        private Panel panel7;
        private Panel panel8;
        private Button CriarVenda;
        private Button CriarCarro;
        private Button BotaoRemoverVenda;
        private Button BotaoRemoverCarro;
        private Button BotaoEditarVenda;
        private Button BotaoEditarCarro;
        private DataGridViewTextBoxColumn ColunaIdVenda;
        private DataGridViewTextBoxColumn ColunaNome;
        private DataGridViewTextBoxColumn colunaCpf;
        private DataGridViewTextBoxColumn ColunaEmail;
        private DataGridViewTextBoxColumn ColunaTelefone;
        private DataGridViewTextBoxColumn IdDoCarroVendido;
        private DataGridViewTextBoxColumn ColunaDataDeCompra;
        private DataGridViewTextBoxColumn ColunaValorTotal;
        private DataGridViewCheckBoxColumn ColunaPago;
        private DataGridViewTextBoxColumn ColunaIdCarro;
        private DataGridViewTextBoxColumn ColunaMarca;
        private DataGridViewTextBoxColumn ColunaModelo;
        private DataGridViewTextBoxColumn ColunaCor;
        private DataGridViewTextBoxColumn ColunaValorDoVeiculo;
        private DataGridViewCheckBoxColumn ColunaFlex;
        private MaskedTextBox procurarDataFinal;
        private Label label7;
    }
}
