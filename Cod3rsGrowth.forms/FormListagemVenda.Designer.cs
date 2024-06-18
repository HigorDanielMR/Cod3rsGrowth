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
            button1 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            button4 = new Button();
            label2 = new Label();
            txtProcurarEmail = new TextBox();
            button3 = new Button();
            CPF = new Label();
            txtProcurarNome = new TextBox();
            panel2 = new Panel();
            panel3 = new Panel();
            procurarCpf = new MaskedTextBox();
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
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(151, 19);
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
            button2.Location = new Point(764, 19);
            button2.Name = "button2";
            button2.Size = new Size(36, 38);
            button2.TabIndex = 4;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.Controls.Add(button4);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtProcurarEmail);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(CPF);
            panel1.Controls.Add(procurarCpf);
            panel1.Controls.Add(txtProcurarNome);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(1, 1);
            panel1.MinimumSize = new Size(800, 60);
            panel1.Name = "panel1";
            panel1.Size = new Size(811, 60);
            panel1.TabIndex = 5;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.Control;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(571, 24);
            button4.Name = "button4";
            button4.Size = new Size(36, 32);
            button4.TabIndex = 11;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(390, 8);
            label2.Name = "label2";
            label2.Size = new Size(51, 19);
            label2.TabIndex = 10;
            label2.Text = "E-mail";
            // 
            // txtProcurarEmail
            // 
            txtProcurarEmail.Location = new Point(390, 30);
            txtProcurarEmail.Name = "txtProcurarEmail";
            txtProcurarEmail.Size = new Size(175, 23);
            txtProcurarEmail.TabIndex = 9;
            // 
            // button3
            // 
            button3.BackColor = SystemColors.Control;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Image = (Image)resources.GetObject("button3.Image");
            button3.Location = new Point(326, 26);
            button3.Name = "button3";
            button3.Size = new Size(36, 25);
            button3.TabIndex = 8;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // CPF
            // 
            CPF.AutoSize = true;
            CPF.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            CPF.Location = new Point(220, 8);
            CPF.Name = "CPF";
            CPF.Size = new Size(34, 19);
            CPF.TabIndex = 7;
            CPF.Text = "CPF";
            // 
            // txtProcurarNome
            // 
            txtProcurarNome.Location = new Point(11, 28);
            txtProcurarNome.Name = "txtProcurarNome";
            txtProcurarNome.Size = new Size(134, 23);
            txtProcurarNome.TabIndex = 5;
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
            panel3.Location = new Point(0, 380);
            panel3.Name = "panel3";
            panel3.Size = new Size(809, 69);
            panel3.TabIndex = 7;
            // 
            // procurarCpf
            // 
            procurarCpf.Location = new Point(220, 28);
            procurarCpf.Mask = "000,000,000-00";
            procurarCpf.Name = "procurarCpf";
            procurarCpf.Size = new Size(100, 23);
            procurarCpf.TabIndex = 6;
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
        private Label label2;
        private TextBox txtProcurarEmail;
        private Button button3;
        private Label CPF;
        private TextBox txtProcurarNome;
        private Button button4;
        private MaskedTextBox procurarCpf;
    }
}