namespace Cod3rsGrowth.Forms
{
    partial class CriandoVenda
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
            txtNome = new TextBox();
            label2 = new Label();
            txtCpf = new MaskedTextBox();
            label3 = new Label();
            txtTelefone = new MaskedTextBox();
            txtEmail = new TextBox();
            txtDataDeCompra = new DateTimePicker();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            selecionandoCarro = new ComboBox();
            label6 = new Label();
            AoClicarNoBotaoCriarDeCriarVenda = new Button();
            AoClicarNoBotaoCancelarDeCriarVenda = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Location = new Point(12, 37);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(366, 23);
            txtNome.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 74);
            label2.Name = "label2";
            label2.Size = new Size(34, 19);
            label2.TabIndex = 2;
            label2.Text = "CPF";
            // 
            // txtCpf
            // 
            txtCpf.Location = new Point(12, 96);
            txtCpf.Mask = "000,000,000-00";
            txtCpf.Name = "txtCpf";
            txtCpf.Size = new Size(176, 23);
            txtCpf.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(203, 74);
            label3.Name = "label3";
            label3.Size = new Size(66, 19);
            label3.TabIndex = 4;
            label3.Text = "Telefone";
            // 
            // txtTelefone
            // 
            txtTelefone.Location = new Point(203, 96);
            txtTelefone.Mask = "(99) 00000-0000";
            txtTelefone.Name = "txtTelefone";
            txtTelefone.Size = new Size(184, 23);
            txtTelefone.TabIndex = 5;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(12, 156);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(390, 23);
            txtEmail.TabIndex = 7;
            // 
            // txtDataDeCompra
            // 
            txtDataDeCompra.Location = new Point(12, 214);
            txtDataDeCompra.Name = "txtDataDeCompra";
            txtDataDeCompra.Size = new Size(390, 23);
            txtDataDeCompra.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(12, 192);
            label1.Name = "label1";
            label1.Size = new Size(117, 19);
            label1.TabIndex = 11;
            label1.Text = "Data da compra";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 15);
            label4.Name = "label4";
            label4.Size = new Size(50, 19);
            label4.TabIndex = 12;
            label4.Text = "Nome";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(12, 134);
            label5.Name = "label5";
            label5.Size = new Size(51, 19);
            label5.TabIndex = 13;
            label5.Text = "E-mail";
            // 
            // selecionandoCarro
            // 
            selecionandoCarro.FormattingEnabled = true;
            selecionandoCarro.Location = new Point(12, 273);
            selecionandoCarro.Name = "selecionandoCarro";
            selecionandoCarro.Size = new Size(390, 23);
            selecionandoCarro.TabIndex = 14;
            selecionandoCarro.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(12, 251);
            label6.Name = "label6";
            label6.Size = new Size(123, 19);
            label6.TabIndex = 15;
            label6.Text = "Carro Comprado";
            // 
            // AoClicarNoBotaoCriarDeCriarVenda
            // 
            AoClicarNoBotaoCriarDeCriarVenda.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            AoClicarNoBotaoCriarDeCriarVenda.Location = new Point(12, 23);
            AoClicarNoBotaoCriarDeCriarVenda.Name = "AoClicarNoBotaoCriarDeCriarVenda";
            AoClicarNoBotaoCriarDeCriarVenda.Size = new Size(94, 28);
            AoClicarNoBotaoCriarDeCriarVenda.TabIndex = 16;
            AoClicarNoBotaoCriarDeCriarVenda.Text = "Criar Venda";
            AoClicarNoBotaoCriarDeCriarVenda.UseVisualStyleBackColor = true;
            AoClicarNoBotaoCriarDeCriarVenda.Click += AoClicarNoBotaoCriarDeCriarVenda_Click;
            // 
            // AoClicarNoBotaoCancelarDeCriarVenda
            // 
            AoClicarNoBotaoCancelarDeCriarVenda.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            AoClicarNoBotaoCancelarDeCriarVenda.Location = new Point(308, 22);
            AoClicarNoBotaoCancelarDeCriarVenda.Name = "AoClicarNoBotaoCancelarDeCriarVenda";
            AoClicarNoBotaoCancelarDeCriarVenda.Size = new Size(94, 28);
            AoClicarNoBotaoCancelarDeCriarVenda.TabIndex = 17;
            AoClicarNoBotaoCancelarDeCriarVenda.Text = "Cancelar";
            AoClicarNoBotaoCancelarDeCriarVenda.UseVisualStyleBackColor = true;
            AoClicarNoBotaoCancelarDeCriarVenda.Click += AoClicarNoBotaoCancelarDeCriarVenda_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(AoClicarNoBotaoCriarDeCriarVenda);
            panel1.Controls.Add(AoClicarNoBotaoCancelarDeCriarVenda);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 386);
            panel1.Name = "panel1";
            panel1.Size = new Size(414, 63);
            panel1.TabIndex = 18;
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
            panel2.Controls.Add(txtDataDeCompra);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(txtCpf);
            panel2.Controls.Add(txtEmail);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(414, 386);
            panel2.TabIndex = 18;
            // 
            // CriandoVenda
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 449);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "CriandoVenda";
            Text = "Cadastro de Venda";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private TextBox txtNome;
        private Label label2;
        private MaskedTextBox txtCpf;
        private Label label3;
        private MaskedTextBox txtTelefone;
        private TextBox txtEmail;
        private DateTimePicker txtDataDeCompra;
        private Label label1;
        private Label label4;
        private Label label5;
        private ComboBox selecionandoCarro;
        private Label label6;
        private Button AoClicarNoBotaoCriarDeCriarVenda;
        private Button AoClicarNoBotaoCancelarDeCriarVenda;
        private Panel panel1;
        private Panel panel2;
    }
}