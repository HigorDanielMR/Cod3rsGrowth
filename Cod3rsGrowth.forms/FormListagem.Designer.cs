﻿namespace Cod3rsGrowth.forms
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
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            marcaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            modeloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            corDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDoVeiculoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            flexDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            carroBindingSource = new BindingSource(components);
            label2 = new Label();
            AoClicarNoBotaoFiltrarDaTabelaCarro = new Button();
            selecionarMarca = new ComboBox();
            AoClicarNoBotaoLimparFiltroDaTabelaCarro = new Button();
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
            AoClicarNoBotaoCriarVenda = new Button();
            panel4 = new Panel();
            panel8 = new Panel();
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda = new Button();
            AoClicarNoBotaoFiltrarNaTabelaVenda = new Button();
            label4 = new Label();
            procurarData = new MaskedTextBox();
            label5 = new Label();
            txtProcurarEmail = new TextBox();
            CPF = new Label();
            procurarCpf = new MaskedTextBox();
            txtProcurarNome = new TextBox();
            label6 = new Label();
            panel3 = new Panel();
            TabelaVenda = new DataGridView();
            vendaBindingSource = new BindingSource(components);
            tabPage2 = new TabPage();
            panel6 = new Panel();
            AoClicarNoBotaoCriarCarro = new Button();
            idDataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cpfDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataDeCompraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pagoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
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
            TabelaCarro.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, marcaDataGridViewTextBoxColumn, modeloDataGridViewTextBoxColumn, corDataGridViewTextBoxColumn, valorDoVeiculoDataGridViewTextBoxColumn, flexDataGridViewCheckBoxColumn });
            TabelaCarro.DataSource = carroBindingSource;
            TabelaCarro.Dock = DockStyle.Fill;
            TabelaCarro.Location = new Point(0, 0);
            TabelaCarro.Name = "TabelaCarro";
            TabelaCarro.RowTemplate.Height = 25;
            TabelaCarro.Size = new Size(824, 286);
            TabelaCarro.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "ID";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 43;
            // 
            // marcaDataGridViewTextBoxColumn
            // 
            marcaDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            marcaDataGridViewTextBoxColumn.DataPropertyName = "Marca";
            marcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            marcaDataGridViewTextBoxColumn.Name = "marcaDataGridViewTextBoxColumn";
            // 
            // modeloDataGridViewTextBoxColumn
            // 
            modeloDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            modeloDataGridViewTextBoxColumn.DataPropertyName = "Modelo";
            modeloDataGridViewTextBoxColumn.HeaderText = "Modelo";
            modeloDataGridViewTextBoxColumn.Name = "modeloDataGridViewTextBoxColumn";
            // 
            // corDataGridViewTextBoxColumn
            // 
            corDataGridViewTextBoxColumn.DataPropertyName = "Cor";
            corDataGridViewTextBoxColumn.HeaderText = "Cor";
            corDataGridViewTextBoxColumn.Name = "corDataGridViewTextBoxColumn";
            corDataGridViewTextBoxColumn.Width = 51;
            // 
            // valorDoVeiculoDataGridViewTextBoxColumn
            // 
            valorDoVeiculoDataGridViewTextBoxColumn.DataPropertyName = "ValorDoVeiculo";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            valorDoVeiculoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            valorDoVeiculoDataGridViewTextBoxColumn.HeaderText = "Preço";
            valorDoVeiculoDataGridViewTextBoxColumn.Name = "valorDoVeiculoDataGridViewTextBoxColumn";
            valorDoVeiculoDataGridViewTextBoxColumn.Width = 62;
            // 
            // flexDataGridViewCheckBoxColumn
            // 
            flexDataGridViewCheckBoxColumn.DataPropertyName = "Flex";
            flexDataGridViewCheckBoxColumn.HeaderText = "Flex";
            flexDataGridViewCheckBoxColumn.Name = "flexDataGridViewCheckBoxColumn";
            flexDataGridViewCheckBoxColumn.Width = 34;
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
            // AoClicarNoBotaoFiltrarDaTabelaCarro
            // 
            AoClicarNoBotaoFiltrarDaTabelaCarro.BackColor = Color.DarkGray;
            AoClicarNoBotaoFiltrarDaTabelaCarro.FlatAppearance.BorderColor = Color.Black;
            AoClicarNoBotaoFiltrarDaTabelaCarro.FlatAppearance.MouseOverBackColor = Color.Snow;
            AoClicarNoBotaoFiltrarDaTabelaCarro.FlatStyle = FlatStyle.Flat;
            AoClicarNoBotaoFiltrarDaTabelaCarro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AoClicarNoBotaoFiltrarDaTabelaCarro.Location = new Point(3, 32);
            AoClicarNoBotaoFiltrarDaTabelaCarro.Name = "AoClicarNoBotaoFiltrarDaTabelaCarro";
            AoClicarNoBotaoFiltrarDaTabelaCarro.Size = new Size(94, 28);
            AoClicarNoBotaoFiltrarDaTabelaCarro.TabIndex = 3;
            AoClicarNoBotaoFiltrarDaTabelaCarro.Text = "Filtrar";
            AoClicarNoBotaoFiltrarDaTabelaCarro.UseVisualStyleBackColor = false;
            AoClicarNoBotaoFiltrarDaTabelaCarro.Click += AoClicarNoBotaoFiltrarDaTabelaCarro_Click;
            // 
            // selecionarMarca
            // 
            selecionarMarca.FormattingEnabled = true;
            selecionarMarca.Items.AddRange(new object[] { "  " });
            selecionarMarca.Location = new Point(14, 37);
            selecionarMarca.Name = "selecionarMarca";
            selecionarMarca.Size = new Size(131, 23);
            selecionarMarca.TabIndex = 4;
            // 
            // AoClicarNoBotaoLimparFiltroDaTabelaCarro
            // 
            AoClicarNoBotaoLimparFiltroDaTabelaCarro.BackColor = Color.DarkGray;
            AoClicarNoBotaoLimparFiltroDaTabelaCarro.FlatAppearance.BorderColor = Color.Black;
            AoClicarNoBotaoLimparFiltroDaTabelaCarro.FlatStyle = FlatStyle.Flat;
            AoClicarNoBotaoLimparFiltroDaTabelaCarro.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AoClicarNoBotaoLimparFiltroDaTabelaCarro.Location = new Point(117, 32);
            AoClicarNoBotaoLimparFiltroDaTabelaCarro.Name = "AoClicarNoBotaoLimparFiltroDaTabelaCarro";
            AoClicarNoBotaoLimparFiltroDaTabelaCarro.Size = new Size(94, 28);
            AoClicarNoBotaoLimparFiltroDaTabelaCarro.TabIndex = 5;
            AoClicarNoBotaoLimparFiltroDaTabelaCarro.Text = "Limpar Filtro";
            AoClicarNoBotaoLimparFiltroDaTabelaCarro.UseVisualStyleBackColor = false;
            AoClicarNoBotaoLimparFiltroDaTabelaCarro.Click += AoClicarNoBotaoLimparFiltroDaTabelaCarro_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(selecionarCor);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtProcurar);
            panel1.Controls.Add(selecionarMarca);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(3, 3);
            panel1.MinimumSize = new Size(800, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(858, 70);
            panel1.TabIndex = 6;
            // 
            // panel7
            // 
            panel7.Controls.Add(AoClicarNoBotaoLimparFiltroDaTabelaCarro);
            panel7.Controls.Add(AoClicarNoBotaoFiltrarDaTabelaCarro);
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
            selecionarCor.TabIndex = 8;
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
            txtProcurar.TabIndex = 6;
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
            panel5.Controls.Add(AoClicarNoBotaoCriarVenda);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(3, 375);
            panel5.Name = "panel5";
            panel5.Size = new Size(858, 58);
            panel5.TabIndex = 9;
            // 
            // AoClicarNoBotaoCriarVenda
            // 
            AoClicarNoBotaoCriarVenda.BackColor = Color.DarkGray;
            AoClicarNoBotaoCriarVenda.FlatAppearance.BorderColor = Color.Black;
            AoClicarNoBotaoCriarVenda.FlatStyle = FlatStyle.Flat;
            AoClicarNoBotaoCriarVenda.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            AoClicarNoBotaoCriarVenda.Location = new Point(743, 25);
            AoClicarNoBotaoCriarVenda.Name = "AoClicarNoBotaoCriarVenda";
            AoClicarNoBotaoCriarVenda.Size = new Size(94, 28);
            AoClicarNoBotaoCriarVenda.TabIndex = 10;
            AoClicarNoBotaoCriarVenda.Text = "Criar";
            AoClicarNoBotaoCriarVenda.UseVisualStyleBackColor = false;
            AoClicarNoBotaoCriarVenda.Click += AoClicarNoBotaoCriarVenda_Click;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.Controls.Add(panel8);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(procurarData);
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
            // panel8
            // 
            panel8.Controls.Add(AoCLicarNoBotaoLimparFIltroDaTabelaVenda);
            panel8.Controls.Add(AoClicarNoBotaoFiltrarNaTabelaVenda);
            panel8.Dock = DockStyle.Right;
            panel8.Location = new Point(627, 0);
            panel8.Name = "panel8";
            panel8.Size = new Size(231, 70);
            panel8.TabIndex = 14;
            // 
            // AoCLicarNoBotaoLimparFIltroDaTabelaVenda
            // 
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda.BackColor = Color.DarkGray;
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda.FlatAppearance.BorderColor = Color.Black;
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda.FlatStyle = FlatStyle.Flat;
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda.Location = new Point(116, 33);
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda.Name = "AoCLicarNoBotaoLimparFIltroDaTabelaVenda";
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda.Size = new Size(94, 28);
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda.TabIndex = 4;
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda.Text = "Limpar FIltro";
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda.UseVisualStyleBackColor = false;
            AoCLicarNoBotaoLimparFIltroDaTabelaVenda.Click += AoCLicarNoBotaoLimparFIltroDaTabelaVenda_Click;
            // 
            // AoClicarNoBotaoFiltrarNaTabelaVenda
            // 
            AoClicarNoBotaoFiltrarNaTabelaVenda.BackColor = Color.DarkGray;
            AoClicarNoBotaoFiltrarNaTabelaVenda.FlatAppearance.BorderColor = Color.Black;
            AoClicarNoBotaoFiltrarNaTabelaVenda.FlatStyle = FlatStyle.Flat;
            AoClicarNoBotaoFiltrarNaTabelaVenda.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AoClicarNoBotaoFiltrarNaTabelaVenda.ForeColor = SystemColors.ControlText;
            AoClicarNoBotaoFiltrarNaTabelaVenda.Location = new Point(3, 33);
            AoClicarNoBotaoFiltrarNaTabelaVenda.Name = "AoClicarNoBotaoFiltrarNaTabelaVenda";
            AoClicarNoBotaoFiltrarNaTabelaVenda.Size = new Size(94, 28);
            AoClicarNoBotaoFiltrarNaTabelaVenda.TabIndex = 3;
            AoClicarNoBotaoFiltrarNaTabelaVenda.Text = "Filtrar";
            AoClicarNoBotaoFiltrarNaTabelaVenda.UseVisualStyleBackColor = false;
            AoClicarNoBotaoFiltrarNaTabelaVenda.Click += AoClicarNoBotaoFiltrarNaTabelaVenda_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(427, 15);
            label4.Name = "label4";
            label4.Size = new Size(117, 19);
            label4.TabIndex = 13;
            label4.Text = "Data de compra";
            // 
            // procurarData
            // 
            procurarData.Location = new Point(427, 37);
            procurarData.Mask = "00/00/0000";
            procurarData.Name = "procurarData";
            procurarData.Size = new Size(120, 23);
            procurarData.TabIndex = 12;
            procurarData.ValidatingType = typeof(DateTime);
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
            txtProcurarEmail.TabIndex = 9;
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
            procurarCpf.TabIndex = 6;
            // 
            // txtProcurarNome
            // 
            txtProcurarNome.Location = new Point(17, 37);
            txtProcurarNome.Name = "txtProcurarNome";
            txtProcurarNome.Size = new Size(134, 23);
            txtProcurarNome.TabIndex = 5;
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
            TabelaVenda.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn1, nomeDataGridViewTextBoxColumn, cpfDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, telefoneDataGridViewTextBoxColumn, dataDeCompraDataGridViewTextBoxColumn, valorTotalDataGridViewTextBoxColumn, pagoDataGridViewCheckBoxColumn });
            TabelaVenda.DataSource = vendaBindingSource;
            TabelaVenda.Dock = DockStyle.Fill;
            TabelaVenda.Location = new Point(0, 0);
            TabelaVenda.Name = "TabelaVenda";
            TabelaVenda.ReadOnly = true;
            TabelaVenda.RowTemplate.Height = 25;
            TabelaVenda.Size = new Size(820, 293);
            TabelaVenda.TabIndex = 1;
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
            panel6.Controls.Add(AoClicarNoBotaoCriarCarro);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(3, 375);
            panel6.Name = "panel6";
            panel6.Size = new Size(858, 58);
            panel6.TabIndex = 8;
            // 
            // AoClicarNoBotaoCriarCarro
            // 
            AoClicarNoBotaoCriarCarro.BackColor = Color.DarkGray;
            AoClicarNoBotaoCriarCarro.FlatAppearance.BorderColor = Color.Black;
            AoClicarNoBotaoCriarCarro.FlatStyle = FlatStyle.Flat;
            AoClicarNoBotaoCriarCarro.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            AoClicarNoBotaoCriarCarro.Location = new Point(744, 25);
            AoClicarNoBotaoCriarCarro.Name = "AoClicarNoBotaoCriarCarro";
            AoClicarNoBotaoCriarCarro.Size = new Size(94, 28);
            AoClicarNoBotaoCriarCarro.TabIndex = 0;
            AoClicarNoBotaoCriarCarro.Text = "Criar";
            AoClicarNoBotaoCriarCarro.UseVisualStyleBackColor = false;
            AoClicarNoBotaoCriarCarro.Click += AoClicarNoBotaoCriarCarro_Click;
            // 
            // idDataGridViewTextBoxColumn1
            // 
            idDataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn1.HeaderText = "ID";
            idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
            idDataGridViewTextBoxColumn1.ReadOnly = true;
            idDataGridViewTextBoxColumn1.Width = 43;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cpfDataGridViewTextBoxColumn
            // 
            cpfDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cpfDataGridViewTextBoxColumn.DataPropertyName = "Cpf";
            cpfDataGridViewTextBoxColumn.HeaderText = "CPF";
            cpfDataGridViewTextBoxColumn.Name = "cpfDataGridViewTextBoxColumn";
            cpfDataGridViewTextBoxColumn.ReadOnly = true;
            cpfDataGridViewTextBoxColumn.Width = 53;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            emailDataGridViewTextBoxColumn.ReadOnly = true;
            emailDataGridViewTextBoxColumn.Width = 61;
            // 
            // telefoneDataGridViewTextBoxColumn
            // 
            telefoneDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            telefoneDataGridViewTextBoxColumn.DataPropertyName = "Telefone";
            telefoneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            telefoneDataGridViewTextBoxColumn.Name = "telefoneDataGridViewTextBoxColumn";
            telefoneDataGridViewTextBoxColumn.ReadOnly = true;
            telefoneDataGridViewTextBoxColumn.Width = 76;
            // 
            // dataDeCompraDataGridViewTextBoxColumn
            // 
            dataDeCompraDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataDeCompraDataGridViewTextBoxColumn.DataPropertyName = "DataDeCompra";
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            dataDeCompraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            dataDeCompraDataGridViewTextBoxColumn.HeaderText = "Data da compra";
            dataDeCompraDataGridViewTextBoxColumn.Name = "dataDeCompraDataGridViewTextBoxColumn";
            dataDeCompraDataGridViewTextBoxColumn.ReadOnly = true;
            dataDeCompraDataGridViewTextBoxColumn.Width = 106;
            // 
            // valorTotalDataGridViewTextBoxColumn
            // 
            valorTotalDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            valorTotalDataGridViewTextBoxColumn.DataPropertyName = "ValorTotal";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            valorTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            valorTotalDataGridViewTextBoxColumn.HeaderText = "Valor total";
            valorTotalDataGridViewTextBoxColumn.Name = "valorTotalDataGridViewTextBoxColumn";
            valorTotalDataGridViewTextBoxColumn.ReadOnly = true;
            valorTotalDataGridViewTextBoxColumn.Width = 79;
            // 
            // pagoDataGridViewCheckBoxColumn
            // 
            pagoDataGridViewCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            pagoDataGridViewCheckBoxColumn.DataPropertyName = "Pago";
            pagoDataGridViewCheckBoxColumn.HeaderText = "Pago";
            pagoDataGridViewCheckBoxColumn.Name = "pagoDataGridViewCheckBoxColumn";
            pagoDataGridViewCheckBoxColumn.ReadOnly = true;
            pagoDataGridViewCheckBoxColumn.Width = 40;
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
            Load += FormListagem_Load;
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
        private Button AoClicarNoBotaoFiltrarDaTabelaCarro;
        private ComboBox selecionarMarca;
        private Button AoClicarNoBotaoLimparFiltroDaTabelaCarro;
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
        private MaskedTextBox procurarData;
        private Label label5;
        private TextBox txtProcurarEmail;
        private Label CPF;
        private MaskedTextBox procurarCpf;
        private TextBox txtProcurarNome;
        private Button AoCLicarNoBotaoLimparFIltroDaTabelaVenda;
        private Label label6;
        private Button AoClicarNoBotaoFiltrarNaTabelaVenda;
        private Panel panel3;
        private DataGridView TabelaVenda;
        private Panel panel7;
        private Panel panel8;
        private Button AoClicarNoBotaoCriarVenda;
        private Button AoClicarNoBotaoCriarCarro;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn modeloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn corDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDoVeiculoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn flexDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDeCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorTotalDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn pagoDataGridViewCheckBoxColumn;
    }
}
