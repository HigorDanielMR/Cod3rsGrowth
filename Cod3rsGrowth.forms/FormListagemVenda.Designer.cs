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
            ((System.ComponentModel.ISupportInitialize)TabelaVenda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vendaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // TabelaVenda
            // 
            TabelaVenda.AutoGenerateColumns = false;
            TabelaVenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TabelaVenda.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nomeDataGridViewTextBoxColumn, cpfDataGridViewTextBoxColumn, emailDataGridViewTextBoxColumn, telefoneDataGridViewTextBoxColumn, dataDeCompraDataGridViewTextBoxColumn, valorTotalDataGridViewTextBoxColumn, pagoDataGridViewCheckBoxColumn });
            TabelaVenda.DataSource = vendaBindingSource;
            TabelaVenda.Location = new Point(2, 45);
            TabelaVenda.Name = "TabelaVenda";
            TabelaVenda.RowTemplate.Height = 25;
            TabelaVenda.Size = new Size(808, 405);
            TabelaVenda.TabIndex = 0;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            idDataGridViewTextBoxColumn.HeaderText = "Id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nomeDataGridViewTextBoxColumn
            // 
            nomeDataGridViewTextBoxColumn.DataPropertyName = "Nome";
            nomeDataGridViewTextBoxColumn.HeaderText = "Nome";
            nomeDataGridViewTextBoxColumn.Name = "nomeDataGridViewTextBoxColumn";
            // 
            // cpfDataGridViewTextBoxColumn
            // 
            cpfDataGridViewTextBoxColumn.DataPropertyName = "Cpf";
            cpfDataGridViewTextBoxColumn.HeaderText = "Cpf";
            cpfDataGridViewTextBoxColumn.Name = "cpfDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            emailDataGridViewTextBoxColumn.HeaderText = "Email";
            emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // telefoneDataGridViewTextBoxColumn
            // 
            telefoneDataGridViewTextBoxColumn.DataPropertyName = "Telefone";
            telefoneDataGridViewTextBoxColumn.HeaderText = "Telefone";
            telefoneDataGridViewTextBoxColumn.Name = "telefoneDataGridViewTextBoxColumn";
            // 
            // dataDeCompraDataGridViewTextBoxColumn
            // 
            dataDeCompraDataGridViewTextBoxColumn.DataPropertyName = "DataDeCompra";
            dataDeCompraDataGridViewTextBoxColumn.HeaderText = "DataDeCompra";
            dataDeCompraDataGridViewTextBoxColumn.Name = "dataDeCompraDataGridViewTextBoxColumn";
            // 
            // valorTotalDataGridViewTextBoxColumn
            // 
            valorTotalDataGridViewTextBoxColumn.DataPropertyName = "ValorTotal";
            valorTotalDataGridViewTextBoxColumn.HeaderText = "ValorTotal";
            valorTotalDataGridViewTextBoxColumn.Name = "valorTotalDataGridViewTextBoxColumn";
            // 
            // pagoDataGridViewCheckBoxColumn
            // 
            pagoDataGridViewCheckBoxColumn.DataPropertyName = "Pago";
            pagoDataGridViewCheckBoxColumn.HeaderText = "Pago";
            pagoDataGridViewCheckBoxColumn.Name = "pagoDataGridViewCheckBoxColumn";
            // 
            // vendaBindingSource
            // 
            vendaBindingSource.DataSource = typeof(Dominio.Entidades.Venda);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(216, 12);
            label1.Name = "label1";
            label1.Size = new Size(50, 19);
            label1.TabIndex = 1;
            label1.Text = "Nome";
            // 
            // txtProcurar
            // 
            txtProcurar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtProcurar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtProcurar.Location = new Point(272, 12);
            txtProcurar.MaxLength = 100;
            txtProcurar.Name = "txtProcurar";
            txtProcurar.Size = new Size(251, 25);
            txtProcurar.TabIndex = 2;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(529, 5);
            button1.Name = "button1";
            button1.Size = new Size(40, 38);
            button1.TabIndex = 3;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(563, 8);
            button2.Name = "button2";
            button2.Size = new Size(36, 32);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // FormListagemVenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 452);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtProcurar);
            Controls.Add(label1);
            Controls.Add(TabelaVenda);
            Name = "FormListagemVenda";
            Text = "FormListagemVenda";
            ((System.ComponentModel.ISupportInitialize)TabelaVenda).EndInit();
            ((System.ComponentModel.ISupportInitialize)vendaBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView TabelaVenda;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nomeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cpfDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataDeCompraDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn valorTotalDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn pagoDataGridViewCheckBoxColumn;
        private BindingSource vendaBindingSource;
        private Label label1;
        private TextBox txtProcurar;
        private Button button1;
        private Button button2;
    }
}