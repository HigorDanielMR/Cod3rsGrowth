namespace Cod3rsGrowth.Forms
{
    partial class FormEditarVenda
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
            panel1 = new Panel();
            BotaoCancelarEdicaoVenda = new Button();
            BotaoSalvarEdicaoVenda = new Button();
            panel2 = new Panel();
            selecionandoCarro = new ComboBox();
            label6 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNome = new TextBox();
            label3 = new Label();
            txtTelefone = new MaskedTextBox();
            label2 = new Label();
            txtCpf = new MaskedTextBox();
            txtEmail = new TextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(BotaoCancelarEdicaoVenda);
            panel1.Controls.Add(BotaoSalvarEdicaoVenda);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 261);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 63);
            panel1.TabIndex = 0;
            // 
            // BotaoCancelarEdicaoVenda
            // 
            BotaoCancelarEdicaoVenda.BackColor = Color.DarkGray;
            BotaoCancelarEdicaoVenda.FlatStyle = FlatStyle.Flat;
            BotaoCancelarEdicaoVenda.Location = new Point(178, 23);
            BotaoCancelarEdicaoVenda.Name = "BotaoCancelarEdicaoVenda";
            BotaoCancelarEdicaoVenda.Size = new Size(94, 28);
            BotaoCancelarEdicaoVenda.TabIndex = 1;
            BotaoCancelarEdicaoVenda.Text = "Cancelar";
            BotaoCancelarEdicaoVenda.UseVisualStyleBackColor = false;
            BotaoCancelarEdicaoVenda.Click += AoClicarNoBotaoCancelarEditarVenda;
            // 
            // BotaoSalvarEdicaoVenda
            // 
            BotaoSalvarEdicaoVenda.BackColor = Color.DarkGray;
            BotaoSalvarEdicaoVenda.FlatStyle = FlatStyle.Flat;
            BotaoSalvarEdicaoVenda.Location = new Point(12, 23);
            BotaoSalvarEdicaoVenda.Name = "BotaoSalvarEdicaoVenda";
            BotaoSalvarEdicaoVenda.Size = new Size(94, 28);
            BotaoSalvarEdicaoVenda.TabIndex = 0;
            BotaoSalvarEdicaoVenda.Text = "Salvar";
            BotaoSalvarEdicaoVenda.UseVisualStyleBackColor = false;
            BotaoSalvarEdicaoVenda.Click += AoClicarNoBotaoSalvarEdicaoVenda;
            // 
            // panel2
            // 
            panel2.Controls.Add(selecionandoCarro);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(txtNome);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtTelefone);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(txtCpf);
            panel2.Controls.Add(txtEmail);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(284, 261);
            panel2.TabIndex = 1;
            // 
            // selecionandoCarro
            // 
            selecionandoCarro.FormattingEnabled = true;
            selecionandoCarro.Location = new Point(12, 220);
            selecionandoCarro.Name = "selecionandoCarro";
            selecionandoCarro.Size = new Size(260, 23);
            selecionandoCarro.TabIndex = 24;
            selecionandoCarro.SelectedIndexChanged += AoSelecionarCarroComprado;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(12, 198);
            label6.Name = "label6";
            label6.Size = new Size(123, 19);
            label6.TabIndex = 25;
            label6.Text = "Carro Comprado";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 17);
            label4.Name = "label4";
            label4.Size = new Size(50, 19);
            label4.TabIndex = 22;
            label4.Text = "Nome";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(12, 136);
            label5.Name = "label5";
            label5.Size = new Size(51, 19);
            label5.TabIndex = 23;
            label5.Text = "E-mail";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 39);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(260, 23);
            txtNome.TabIndex = 16;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(141, 76);
            label3.Name = "label3";
            label3.Size = new Size(66, 19);
            label3.TabIndex = 19;
            label3.Text = "Telefone";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(141, 98);
            txtTelefone.Mask = "(99) 00000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(131, 23);
            txtTelefone.TabIndex = 20;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 76);
            label2.Name = "label2";
            label2.Size = new Size(34, 19);
            label2.TabIndex = 17;
            label2.Text = "CPF";
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(12, 98);
            txtCpf.Mask = "000,000,000-00";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(123, 23);
            txtCpf.TabIndex = 18;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 158);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(260, 23);
            txtEmail.TabIndex = 21;
            // 
            // FormEditarVenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 324);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FormEditarVenda";
            Text = "Editar Venda";
            Load += AoCarregarFomEditarVenda;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button BotaoSalvarEdicaoVenda;
        private Button BotaoCancelarEdicaoVenda;
        private Panel panel2;
        private ComboBox selecionandoCarro;
        private Label label6;
        private Label label4;
        private Label label5;
        private TextBox txtNome;
        private Label label3;
        private MaskedTextBox txtTelefone;
        private Label label2;
        private MaskedTextBox txtCpf;
        private TextBox txtEmail;
    }
}