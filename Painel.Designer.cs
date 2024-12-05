namespace ExportFirebirdToSqlite
{
    partial class Painel
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
            btnMigrarQuerie = new Button();
            btnMigrarTabela = new Button();
            SuspendLayout();
            // 
            // btnMigrarQuerie
            // 
            btnMigrarQuerie.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            btnMigrarQuerie.Location = new Point(12, 12);
            btnMigrarQuerie.Name = "btnMigrarQuerie";
            btnMigrarQuerie.Size = new Size(114, 114);
            btnMigrarQuerie.TabIndex = 0;
            btnMigrarQuerie.Text = "Migrar Querie";
            btnMigrarQuerie.UseVisualStyleBackColor = true;
            btnMigrarQuerie.Click += btnMigrarQuerie_Click;
            // 
            // btnMigrarTabela
            // 
            btnMigrarTabela.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnMigrarTabela.Location = new Point(132, 12);
            btnMigrarTabela.Name = "btnMigrarTabela";
            btnMigrarTabela.Size = new Size(114, 114);
            btnMigrarTabela.TabIndex = 1;
            btnMigrarTabela.Text = "Migrar Tabela";
            btnMigrarTabela.UseVisualStyleBackColor = true;
            btnMigrarTabela.Click += btnMigrarTabela_Click;
            // 
            // Painel
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(257, 136);
            Controls.Add(btnMigrarTabela);
            Controls.Add(btnMigrarQuerie);
            MaximizeBox = false;
            Name = "Painel";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Painel";
            ResumeLayout(false);
        }

        #endregion

        private Button btnMigrarQuerie;
        private Button btnMigrarTabela;
    }
}