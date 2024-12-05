namespace ExportFirebirdToSqlite
{
    public partial class Painel : Form
    {
        public Painel()
        {
            InitializeComponent();
        }

        private void btnMigrarQuerie_Click(object sender, EventArgs e)
        {
            MigrarQueries migrarQueries = new MigrarQueries();
            migrarQueries.ShowDialog();
        }

        private void btnMigrarTabela_Click(object sender, EventArgs e)
        {
            MigrarTabelas migrarTabelas = new MigrarTabelas();  
            migrarTabelas.ShowDialog();
        }
    }
}
