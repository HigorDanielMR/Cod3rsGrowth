namespace Cod3rsGrowth.Forms
{
    partial class FormEditarCarro
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
            BotaoCancelarEdicaoCarro = new Button();
            BotaoSalvarEdicaoCarro = new Button();
            panel2 = new Panel();
            selecionarValorDoVeiculo = new TextBox();
            label4 = new Label();
            label1 = new Label();
            label3 = new Label();
            txtModelo = new TextBox();
            selecionarFlex = new CheckBox();
            label2 = new Label();
            selecionarCor = new ComboBox();
            selecionarMarca = new ComboBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(BotaoCancelarEdicaoCarro);
            panel1.Controls.Add(BotaoSalvarEdicaoCarro);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 199);
            panel1.Name = "panel1";
            panel1.Size = new Size(284, 63);
            panel1.TabIndex = 0;
            // 
            // BotaoCancelarEdicaoCarro
            // 
            BotaoCancelarEdicaoCarro.BackColor = Color.DarkGray;
            BotaoCancelarEdicaoCarro.FlatStyle = FlatStyle.Flat;
            BotaoCancelarEdicaoCarro.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BotaoCancelarEdicaoCarro.Location = new Point(178, 23);
            BotaoCancelarEdicaoCarro.Name = "BotaoCancelarEdicaoCarro";
            BotaoCancelarEdicaoCarro.Size = new Size(94, 28);
            BotaoCancelarEdicaoCarro.TabIndex = 1;
            BotaoCancelarEdicaoCarro.Text = "Cancelar";
            BotaoCancelarEdicaoCarro.UseVisualStyleBackColor = false;
            BotaoCancelarEdicaoCarro.Click += AoClicarNoBotaoCancelarEdicaoCarro;
            // 
            // BotaoSalvarEdicaoCarro
            // 
            BotaoSalvarEdicaoCarro.BackColor = Color.DarkGray;
            BotaoSalvarEdicaoCarro.FlatStyle = FlatStyle.Flat;
            BotaoSalvarEdicaoCarro.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            BotaoSalvarEdicaoCarro.Location = new Point(12, 23);
            BotaoSalvarEdicaoCarro.Name = "BotaoSalvarEdicaoCarro";
            BotaoSalvarEdicaoCarro.Size = new Size(94, 28);
            BotaoSalvarEdicaoCarro.TabIndex = 0;
            BotaoSalvarEdicaoCarro.Text = "Salvar";
            BotaoSalvarEdicaoCarro.UseVisualStyleBackColor = false;
            BotaoSalvarEdicaoCarro.Click += AoClicarNoBotaoSalvarEdicaoCarro;
            // 
            // panel2
            // 
            panel2.Controls.Add(selecionarValorDoVeiculo);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(txtModelo);
            panel2.Controls.Add(selecionarFlex);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(selecionarCor);
            panel2.Controls.Add(selecionarMarca);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(284, 199);
            panel2.TabIndex = 1;
            // 
            // selecionarValorDoVeiculo
            // 
            selecionarValorDoVeiculo.AutoCompleteCustomSource.AddRange(new string[] { "R$   " });
            selecionarValorDoVeiculo.Location = new Point(12, 157);
            selecionarValorDoVeiculo.Name = "selecionarValorDoVeiculo";
            selecionarValorDoVeiculo.PlaceholderText = "R$";
            selecionarValorDoVeiculo.Size = new Size(132, 23);
            selecionarValorDoVeiculo.TabIndex = 22;
            selecionarValorDoVeiculo.Text = "0,00";
            selecionarValorDoVeiculo.TextAlign = HorizontalAlignment.Right;
            selecionarValorDoVeiculo.TextChanged += AoPreencherValorDoVeiculo;
            selecionarValorDoVeiculo.KeyPress += AoComecarAPreencherValor;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(12, 135);
            label4.Name = "label4";
            label4.Size = new Size(118, 19);
            label4.TabIndex = 20;
            label4.Text = "Valor do Veiculo";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(13, 18);
            label1.Name = "label1";
            label1.Size = new Size(61, 19);
            label1.TabIndex = 15;
            label1.Text = "Modelo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(150, 75);
            label3.Name = "label3";
            label3.Size = new Size(33, 19);
            label3.TabIndex = 19;
            label3.Text = "Cor";
            // 
            // txtModelo
            // 
            txtModelo.Location = new Point(13, 40);
            txtModelo.Name = "txtModelo";
            txtModelo.Size = new Size(260, 23);
            txtModelo.TabIndex = 14;
            // 
            // selecionarFlex
            // 
            selecionarFlex.AutoSize = true;
            selecionarFlex.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            selecionarFlex.Location = new Point(218, 156);
            selecionarFlex.Name = "selecionarFlex";
            selecionarFlex.Size = new Size(55, 23);
            selecionarFlex.TabIndex = 21;
            selecionarFlex.Text = "Flex";
            selecionarFlex.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(12, 75);
            label2.Name = "label2";
            label2.Size = new Size(51, 19);
            label2.TabIndex = 17;
            label2.Text = "Marca";
            // 
            // selecionarCor
            // 
            selecionarCor.FormattingEnabled = true;
            selecionarCor.Location = new Point(150, 97);
            selecionarCor.Name = "selecionarCor";
            selecionarCor.Size = new Size(123, 23);
            selecionarCor.TabIndex = 18;
            // 
            // selecionarMarca
            // 
            selecionarMarca.FormattingEnabled = true;
            selecionarMarca.Location = new Point(12, 97);
            selecionarMarca.Name = "selecionarMarca";
            selecionarMarca.Size = new Size(132, 23);
            selecionarMarca.TabIndex = 16;
            // 
            // FormEditarCarro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 262);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "FormEditarCarro";
            Text = "FormEditarCarro";
            Load += AoCarregarFormEditarCarro;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button BotaoSalvarEdicaoCarro;
        private Button BotaoCancelarEdicaoCarro;
        private Panel panel2;
        private TextBox selecionarValorDoVeiculo;
        private Label label4;
        private Label label1;
        private Label label3;
        private TextBox txtModelo;
        private CheckBox selecionarFlex;
        private Label label2;
        private ComboBox selecionarCor;
        private ComboBox selecionarMarca;
    }
}