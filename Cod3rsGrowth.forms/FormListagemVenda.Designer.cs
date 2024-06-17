namespace Cod3rsGrowth.Forms
{
    partial class FormListagemVenda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormListagemVenda));
            TabelaVenda = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nomeDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cpfDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            emailDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefoneDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataDeCompraDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            valorTotalDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            pagoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            vendaBindingSource = new BindingSource(components);
            label1 = new Label();
            txtProcurar = new TextBox();
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            ((System.ComponentModel.ISupportInitialize)TabelaVenda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vendaBindingSource).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // TabelaVenda
            // 
            TabelaVenda.AutoGenerateColumns = false;
            TabelaVenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TabelaVenda.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, cpfDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, telefoneDataGridViewTextBoxColumn, dataDeCompraDataGridViewTextBoxColumn, valorTotalDataGridViewTextBoxColumn, pagoDataGridViewCheckBoxColumn });
            TabelaVenda.DataSource = vendaBindingSource;
            TabelaVenda.Dock = DockStyle.Fill;
            TabelaVenda.Location = new Point(0, 0);
            TabelaVenda.Name = "TabelaVenda";
            TabelaVenda.RowTemplate.Height = 25;
            TabelaVenda.Size = new Size(812, 307);
            TabelaVenda.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            idDataGridViewTextBoxColumn.Width = 42;
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            nomeDataGridViewTextBoxColumn.Width = 65;
            // 
            // cpfDataGridViewTextBoxColumn
            // 
            cpfDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cpfDataGridViewTextBoxColumn.DataPropertyName = "Cpf";
            cpfDataGridViewTextBoxColumn.HeaderText = "Cpf";
            cpfDataGridViewTextBoxColumn.Name = "cpfDataGridViewTextBoxColumn";
            cpfDataGridViewTextBoxColumn.Width = 51;
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // telefoneDataGridViewTextBoxColumn
            // 
            telefoneDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            telefoneDataGridViewTextBoxColumn.DataPropertyName = "Telefone";
            telefoneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            telefoneDataGridViewTextBoxColumn.Name = "telefoneDataGridViewTextBoxColumn";
            telefoneDataGridViewTextBoxColumn.Width = 76;
            // 
            // dataDeCompraDataGridViewTextBoxColumn
            // 
            dataDeCompraDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataDeCompraDataGridViewTextBoxColumn.DataPropertyName = "DataDeCompra";
            dataGridViewCellStyle1.Format = "d";
            dataGridViewCellStyle1.NullValue = null;
            dataDeCompraDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            dataDeCompraDataGridViewTextBoxColumn.HeaderText = "DataDeCompra";
            dataDeCompraDataGridViewTextBoxColumn.Name = "dataDeCompraDataGridViewTextBoxColumn";
            dataDeCompraDataGridViewTextBoxColumn.Width = 113;
            // 
            // valorTotalDataGridViewTextBoxColumn
            // 
            valorTotalDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            valorTotalDataGridViewTextBoxColumn.DataPropertyName = "ValorTotal";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            valorTotalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            valorTotalDataGridViewTextBoxColumn.HeaderText = "ValorTotal";
            valorTotalDataGridViewTextBoxColumn.Name = "valorTotalDataGridViewTextBoxColumn";
            valorTotalDataGridViewTextBoxColumn.Width = 83;
            // 
            // pagoDataGridViewCheckBoxColumn
            // 
            pagoDataGridViewCheckBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            pagoDataGridViewCheckBoxColumn.DataPropertyName = "Pago";
            pagoDataGridViewCheckBoxColumn.HeaderText = "Pago";
            pagoDataGridViewCheckBoxColumn.Name = "pagoDataGridViewCheckBoxColumn";
            pagoDataGridViewCheckBoxColumn.Width = 40;
            // 
            // vendaBindingSource
            // 
            vendaBindingSource.DataSource = typeof(Dominio.Entidades.Venda);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(11, 8);
            label1.Name = "label1";
            label1.Size = new Size(50, 19);
            label1.TabIndex = 1;
            label1.Text = "Nome";
            // 
            // txtProcurar
            // 
            txtProcurar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtProcurar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtProcurar.Location = new Point(11, 30);
            txtProcurar.MaxLength = 100;
            txtProcurar.Name = "txtProcurar";
            txtProcurar.Size = new Size(171, 25);
            txtProcurar.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(188, 15);
            button1.Name = "button1";
            button1.Size = new Size(36, 38);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(591, 15);
            button2.Name = "button2";
            button2.Size = new Size(36, 32);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(txtProcurar);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(1, 1);
            panel1.MinimumSize = new Size(800, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(811, 60);
            panel1.TabIndex = 5;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.Controls.Add(TabelaVenda);
            panel2.Location = new Point(0, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(812, 307);
            panel2.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Location = new Point(1, 380);
            panel3.Name = "panel3";
            panel3.Size = new Size(809, 69);
            panel3.TabIndex = 7;
            // 
            // FormListagemVenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 452);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FormListagemVenda";
            Text = "Lista De Vendas";
            ((System.ComponentModel.ISupportInitialize)TabelaVenda).EndInit();
            ((System.ComponentModel.ISupportInitialize)vendaBindingSource).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView TabelaVenda;
        private BindingSource vendaBindingSource;
        private Label label1;
        private TextBox txtProcurar;
        private Button button1;
        private Button button2;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDeCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorTotalDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn pagoDataGridViewCheckBoxColumn;
    }
}