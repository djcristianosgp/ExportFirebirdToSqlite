namespace ExportFirebirdToSqlite
{
    partial class MigrarQueries
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MigrarQueries));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            txtStringFirebird = new TextBox();
            txtStringSQLITE = new TextBox();
            txtQuerie = new RichTextBox();
            Executar = new Button();
            pbProgresso = new ProgressBar();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(81, 15);
            label1.TabIndex = 0;
            label1.Text = "String Firebird";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 51);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 1;
            label2.Text = "String Sqlite";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 93);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 2;
            label3.Text = "Querie";
            // 
            // txtStringFirebird
            // 
            txtStringFirebird.Location = new Point(12, 25);
            txtStringFirebird.Name = "txtStringFirebird";
            txtStringFirebird.Size = new Size(668, 23);
            txtStringFirebird.TabIndex = 3;
            txtStringFirebird.Text = "Server=localhost;Database=C:\\BancoTeste.FDB;User=SYSDBA;Password=masterkey;";
            // 
            // txtStringSQLITE
            // 
            txtStringSQLITE.Location = new Point(12, 69);
            txtStringSQLITE.Name = "txtStringSQLITE";
            txtStringSQLITE.Size = new Size(668, 23);
            txtStringSQLITE.TabIndex = 4;
            txtStringSQLITE.Text = "Data Source=C:\\Dados.sqlite;Version=3;";
            // 
            // txtQuerie
            // 
            txtQuerie.Location = new Point(12, 111);
            txtQuerie.Name = "txtQuerie";
            txtQuerie.Size = new Size(675, 256);
            txtQuerie.TabIndex = 5;
            txtQuerie.Text = resources.GetString("txtQuerie.Text");
            // 
            // Executar
            // 
            Executar.Location = new Point(7, 373);
            Executar.Name = "Executar";
            Executar.Size = new Size(179, 23);
            Executar.TabIndex = 6;
            Executar.Text = "Executar";
            Executar.UseVisualStyleBackColor = true;
            Executar.Click += Executar_Click;
            // 
            // pbProgresso
            // 
            pbProgresso.Dock = DockStyle.Bottom;
            pbProgresso.Location = new Point(0, 416);
            pbProgresso.Name = "pbProgresso";
            pbProgresso.Size = new Size(707, 34);
            pbProgresso.TabIndex = 7;
            // 
            // MigrarQueries
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(707, 450);
            Controls.Add(pbProgresso);
            Controls.Add(Executar);
            Controls.Add(txtQuerie);
            Controls.Add(txtStringSQLITE);
            Controls.Add(txtStringFirebird);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MigrarQueries";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Migrar Queries";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtStringFirebird;
        private TextBox txtStringSQLITE;
        private RichTextBox txtQuerie;
        private Button Executar;
        private ProgressBar pbProgresso;
    }
}
