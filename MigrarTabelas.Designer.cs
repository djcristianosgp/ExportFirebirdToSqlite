namespace ExportFirebirdToSqlite
{
    partial class MigrarTabelas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MigrarTabelas));
            pbResgistros = new ProgressBar();
            Executar = new Button();
            txtStringSQLITE = new TextBox();
            txtStringFirebird = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtTabelas = new TextBox();
            lblProgressoRegistros = new Label();
            lblProgressoTabela = new Label();
            pbTabelas = new ProgressBar();
            SuspendLayout();
            // 
            // pbResgistros
            // 
            pbResgistros.Dock = DockStyle.Bottom;
            pbResgistros.Location = new Point(0, 230);
            pbResgistros.Name = "pbResgistros";
            pbResgistros.Size = new Size(717, 34);
            pbResgistros.TabIndex = 15;
            // 
            // Executar
            // 
            Executar.Location = new Point(12, 136);
            Executar.Name = "Executar";
            Executar.Size = new Size(179, 23);
            Executar.TabIndex = 14;
            Executar.Text = "Executar";
            Executar.UseVisualStyleBackColor = true;
            Executar.Click += Executar_Click;
            // 
            // txtStringSQLITE
            // 
            txtStringSQLITE.Location = new Point(12, 65);
            txtStringSQLITE.Name = "txtStringSQLITE";
            txtStringSQLITE.Size = new Size(668, 23);
            txtStringSQLITE.TabIndex = 12;
            txtStringSQLITE.Text = "Data Source=C:\\RGSystem\\BD\\DadosDevexpress.sqlite;Version=3;";
            // 
            // txtStringFirebird
            // 
            txtStringFirebird.Location = new Point(12, 21);
            txtStringFirebird.Name = "txtStringFirebird";
            txtStringFirebird.Size = new Size(668, 23);
            txtStringFirebird.TabIndex = 11;
            txtStringFirebird.Text = "Server=localhost;Database=VARGEMALTALOCAL;User=SYSDBA;Password=masterkey;";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 89);
            label3.Name = "label3";
            label3.Size = new Size(46, 15);
            label3.TabIndex = 10;
            label3.Text = "Tabelas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 47);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 9;
            label2.Text = "String Sqlite";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 5);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 8;
            label1.Text = "String Firebird";
            // 
            // txtTabelas
            // 
            txtTabelas.Location = new Point(12, 107);
            txtTabelas.Name = "txtTabelas";
            txtTabelas.Size = new Size(668, 23);
            txtTabelas.TabIndex = 16;
            txtTabelas.Text = resources.GetString("txtTabelas.Text");
            // 
            // lblProgressoRegistros
            // 
            lblProgressoRegistros.Dock = DockStyle.Bottom;
            lblProgressoRegistros.Location = new Point(0, 215);
            lblProgressoRegistros.Name = "lblProgressoRegistros";
            lblProgressoRegistros.Size = new Size(717, 15);
            lblProgressoRegistros.TabIndex = 17;
            lblProgressoRegistros.Text = "Progresso Registros";
            // 
            // lblProgressoTabela
            // 
            lblProgressoTabela.Dock = DockStyle.Bottom;
            lblProgressoTabela.Location = new Point(0, 166);
            lblProgressoTabela.Name = "lblProgressoTabela";
            lblProgressoTabela.Size = new Size(717, 15);
            lblProgressoTabela.TabIndex = 19;
            lblProgressoTabela.Text = "ProgressoTabelas";
            // 
            // pbTabelas
            // 
            pbTabelas.Dock = DockStyle.Bottom;
            pbTabelas.Location = new Point(0, 181);
            pbTabelas.Name = "pbTabelas";
            pbTabelas.Size = new Size(717, 34);
            pbTabelas.TabIndex = 18;
            // 
            // MigrarTabelas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 264);
            Controls.Add(lblProgressoTabela);
            Controls.Add(pbTabelas);
            Controls.Add(lblProgressoRegistros);
            Controls.Add(txtTabelas);
            Controls.Add(pbResgistros);
            Controls.Add(Executar);
            Controls.Add(txtStringSQLITE);
            Controls.Add(txtStringFirebird);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MigrarTabelas";
            Text = "MigrarTabelas";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ProgressBar pbResgistros;
        private Button Executar;
        private TextBox txtStringSQLITE;
        private TextBox txtStringFirebird;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtTabelas;
        private Label lblProgressoRegistros;
        private Label lblProgressoTabela;
        private ProgressBar pbTabelas;
    }
}