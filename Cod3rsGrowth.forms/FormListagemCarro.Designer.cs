namespace Cod3rsGrowth.forms
{
    partial class FormListagemCarro
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
            TabelaCarro = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            marcaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            modeloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            corDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDoVeiculoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            flexDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            carroBindingSource = new BindingSource(components);
            label2 = new Label();
            AoClicarNoBotaoFiltrar = new Button();
            selecionarMarca = new ComboBox();
            button2 = new Button();
            panel1 = new Panel();
            label1 = new Label();
            selecionarCor = new ComboBox();
            label3 = new Label();
            txtProcurar = new TextBox();
            carroBindingSource1 = new BindingSource(components);
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)TabelaCarro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)carroBindingSource).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)carroBindingSource1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // TabelaCarro
            // 
            TabelaCarro.AllowUserToOrderColumns = true;
            TabelaCarro.AutoGenerateColumns = false;
            TabelaCarro.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            TabelaCarro.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            TabelaCarro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TabelaCarro.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, marcaDataGridViewTextBoxColumn, modeloDataGridViewTextBoxColumn, corDataGridViewTextBoxColumn, valorDoVeiculoDataGridViewTextBoxColumn, flexDataGridViewCheckBoxColumn });
            TabelaCarro.DataSource = carroBindingSource;
            TabelaCarro.Dock = DockStyle.Fill;
            TabelaCarro.Location = new Point(0, 0);
            TabelaCarro.Name = "TabelaCarro";
            TabelaCarro.RowTemplate.Height = 25;
            TabelaCarro.Size = new Size(847, 331);
            TabelaCarro.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 42;
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
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(51, 19);
            label2.TabIndex = 1;
            label2.Text = "Marca";
            // 
            // AoClicarNoBotaoFiltrar
            // 
            AoClicarNoBotaoFiltrar.BackColor = SystemColors.ButtonHighlight;
            AoClicarNoBotaoFiltrar.FlatAppearance.BorderColor = Color.Black;
            AoClicarNoBotaoFiltrar.FlatAppearance.MouseOverBackColor = Color.Snow;
            AoClicarNoBotaoFiltrar.FlatStyle = FlatStyle.Flat;
            AoClicarNoBotaoFiltrar.Location = new Point(694, 15);
            AoClicarNoBotaoFiltrar.Name = "AoClicarNoBotaoFiltrar";
            AoClicarNoBotaoFiltrar.Size = new Size(54, 42);
            AoClicarNoBotaoFiltrar.TabIndex = 3;
            AoClicarNoBotaoFiltrar.Text = "Filtrar";
            AoClicarNoBotaoFiltrar.UseVisualStyleBackColor = false;
            AoClicarNoBotaoFiltrar.Click += button1_Click;
            // 
            // selecionarMarca
            // 
            selecionarMarca.FormattingEnabled = true;
            selecionarMarca.Items.AddRange(new object[] { "  " });
            selecionarMarca.Location = new Point(12, 37);
            selecionarMarca.Name = "selecionarMarca";
            selecionarMarca.Size = new Size(117, 23);
            selecionarMarca.TabIndex = 4;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderColor = Color.Black;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Location = new Point(767, 15);
            button2.Name = "button2";
            button2.Size = new Size(65, 42);
            button2.TabIndex = 5;
            button2.Text = "Limpar Filtro";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(selecionarCor);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(txtProcurar);
            panel1.Controls.Add(selecionarMarca);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(AoClicarNoBotaoFiltrar);
            panel1.Location = new Point(0, 0);
            panel1.MinimumSize = new Size(800, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(841, 60);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(369, 9);
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
            selecionarCor.Location = new Point(369, 37);
            selecionarCor.Name = "selecionarCor";
            selecionarCor.Size = new Size(97, 23);
            selecionarCor.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(149, 9);
            label3.Name = "label3";
            label3.Size = new Size(50, 19);
            label3.TabIndex = 7;
            label3.Text = "Nome";
            // 
            // txtProcurar
            // 
            txtProcurar.Location = new Point(149, 37);
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
            panel2.Location = new Point(0, 66);
            panel2.Name = "panel2";
            panel2.Size = new Size(847, 331);
            panel2.TabIndex = 7;
            // 
            // FormListagemCarro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(844, 463);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = SystemColors.ActiveCaptionText;
            Name = "FormListagemCarro";
            Text = "Tela de Carros";
            Load += FormListagem_Load;
            ((System.ComponentModel.ISupportInitialize)TabelaCarro).EndInit();
            ((System.ComponentModel.ISupportInitialize)carroBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)carroBindingSource1).EndInit();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private DataGridView TabelaCarro;
        private BindingSource carroBindingSource;
        private Label label2;
        private Button AoClicarNoBotaoFiltrar;
        private ComboBox selecionarMarca;
        private Button button2;
        private Panel panel1;
        private Panel panel2;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn modeloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn corDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDoVeiculoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn flexDataGridViewCheckBoxColumn;
        private ComboBox selecionarCor;
        private Label label3;
        private TextBox txtProcurar;
        private BindingSource carroBindingSource1;
    }
}
