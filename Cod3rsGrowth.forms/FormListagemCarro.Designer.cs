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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListagemCarro));
            TabelaCarro = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            marcaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            modeloDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            corDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorDoVeiculoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            flexDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            carroBindingSource = new BindingSource(components);
            label2 = new Label();
            button1 = new Button();
            selecionarMarca = new ComboBox();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)TabelaCarro).BeginInit();
            ((System.ComponentModel.ISupportInitialize)carroBindingSource).BeginInit();
            SuspendLayout();
            // 
            // TabelaCarro
            // 
            TabelaCarro.AllowUserToOrderColumns = true;
            TabelaCarro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabelaCarro.AutoGenerateColumns = false;
            TabelaCarro.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TabelaCarro.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, marcaDataGridViewTextBoxColumn, modeloDataGridViewTextBoxColumn, corDataGridViewTextBoxColumn, valorDoVeiculoDataGridViewTextBoxColumn, flexDataGridViewCheckBoxColumn });
            TabelaCarro.DataSource = carroBindingSource;
            TabelaCarro.Location = new Point(3, 41);
            TabelaCarro.Name = "TabelaCarro";
            TabelaCarro.RowTemplate.Height = 25;
            TabelaCarro.Size = new Size(795, 408);
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
            marcaDataGridViewTextBoxColumn.DataPropertyName = "Marca";
            marcaDataGridViewTextBoxColumn.HeaderText = "Marca";
            marcaDataGridViewTextBoxColumn.Name = "marcaDataGridViewTextBoxColumn";
            // 
            // modeloDataGridViewTextBoxColumn
            // 
            modeloDataGridViewTextBoxColumn.DataPropertyName = "Modelo";
            modeloDataGridViewTextBoxColumn.HeaderText = "Modelo";
            modeloDataGridViewTextBoxColumn.Name = "modeloDataGridViewTextBoxColumn";
            // 
            // corDataGridViewTextBoxColumn
            // 
            corDataGridViewTextBoxColumn.DataPropertyName = "Cor";
            corDataGridViewTextBoxColumn.HeaderText = "Cor";
            corDataGridViewTextBoxColumn.Name = "corDataGridViewTextBoxColumn";
            // 
            // valorDoVeiculoDataGridViewTextBoxColumn
            // 
            valorDoVeiculoDataGridViewTextBoxColumn.DataPropertyName = "ValorDoVeiculo";
            valorDoVeiculoDataGridViewTextBoxColumn.HeaderText = "ValorDoVeiculo";
            valorDoVeiculoDataGridViewTextBoxColumn.Name = "valorDoVeiculoDataGridViewTextBoxColumn";
            // 
            // flexDataGridViewCheckBoxColumn
            // 
            flexDataGridViewCheckBoxColumn.DataPropertyName = "Flex";
            flexDataGridViewCheckBoxColumn.HeaderText = "Flex";
            flexDataGridViewCheckBoxColumn.Name = "flexDataGridViewCheckBoxColumn";
            // 
            // carroBindingSource
            // 
            carroBindingSource.DataSource = typeof(Dominio.Entidades.Carro);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(217, 12);
            label2.Name = "label2";
            label2.Size = new Size(51, 19);
            label2.TabIndex = 1;
            label2.Text = "Marca";
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ButtonHighlight;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseOverBackColor = Color.Snow;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(459, 6);
            button1.Name = "button1";
            button1.Size = new Size(39, 32);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // selecionarMarca
            // 
            selecionarMarca.FormattingEnabled = true;
            selecionarMarca.Items.AddRange(new object[] { "Toyota", "Honda", "Hyundai", "Volkswagem", "Chevrolet", "Peugeot", "Mercedes", "Bmw", "Mitsubishi" });
            selecionarMarca.Location = new Point(274, 12);
            selecionarMarca.Name = "selecionarMarca";
            selecionarMarca.Size = new Size(179, 23);
            selecionarMarca.TabIndex = 4;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(504, 6);
            button2.Name = "button2";
            button2.Size = new Size(34, 32);
            button2.TabIndex = 5;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormListagemCarro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(selecionarMarca);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(TabelaCarro);
            Name = "FormListagemCarro";
            Text = "Tela de Carros";
            Load += FormListagem_Load;
            ((System.ComponentModel.ISupportInitialize)TabelaCarro).EndInit();
            ((System.ComponentModel.ISupportInitialize)carroBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView TabelaCarro;
        private BindingSource carroBindingSource;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn marcaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn modeloDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn corDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorDoVeiculoDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn flexDataGridViewCheckBoxColumn;
        private Label label2;
        private Button button1;
        private ComboBox selecionarMarca;
        private Button button2;
    }
}
