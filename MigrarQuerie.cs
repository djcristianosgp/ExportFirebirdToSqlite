using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.SQLite;

namespace ExportFirebirdToSqlite
{
    public partial class MigrarQueries : Form
    {
        public MigrarQueries()
        {
            InitializeComponent();
        }

        private async void Executar_Click(object sender, EventArgs e)
        {
            Executar.Enabled = false;
            await ExportData(txtStringFirebird.Text,txtStringSQLITE.Text,txtQuerie.Text,pbProgresso);
            Executar.Enabled = true;
        }

        private async Task ExportData(string firebirdConnectionString, string sqliteConnectionString, string query, ProgressBar progressBar)
        {
            try
            {
                // Conexão com o banco Firebird
                using (var firebirdConnection = new FbConnection(firebirdConnectionString))
                {
                    firebirdConnection.Open();

                    using (var firebirdCommand = new FbCommand(query, firebirdConnection))
                    using (var firebirdReader = firebirdCommand.ExecuteReader())
                    {
                        // Obtenção do schema da tabela retornada
                        var schemaTable = firebirdReader.GetSchemaTable();

                        // Conexão com o banco SQLite
                        using (var sqliteConnection = new SQLiteConnection(sqliteConnectionString))
                        {
                            sqliteConnection.Open();

                            // Criação da tabela no SQLite
                            using (var sqliteCommand = new SQLiteCommand())
                            {
                                sqliteCommand.Connection = sqliteConnection;

                                string createTableSql = "CREATE TABLE GetDadosFirebird (";
                                foreach (DataRow row in schemaTable.Rows)
                                {
                                    string columnName = row["ColumnName"].ToString();
                                    string dataType = row["DataType"].ToString();

                                    // Mapear os tipos do Firebird para SQLite
                                    string sqliteType = dataType switch
                                    {
                                        "System.Int32" => "INTEGER",
                                        "System.String" => "TEXT",
                                        "System.DateTime" => "DATETIME",
                                        "System.Decimal" => "REAL",
                                        "System.Double" => "REAL",
                                        _ => "TEXT"
                                    };

                                    createTableSql += $"{columnName} {sqliteType}, ";
                                }

                                createTableSql = createTableSql.TrimEnd(',', ' ') + ");";

                                sqliteCommand.CommandText = createTableSql;
                                sqliteCommand.ExecuteNonQuery();
                            }

                            // Inserir os dados do Firebird no SQLite com progressão
                            int totalRows = GetRowCount(firebirdConnection, query);
                            int processedRows = 0;

                            progressBar.Minimum = 0;
                            progressBar.Maximum = totalRows;
                            progressBar.Value = 0;

                            using (var transaction = sqliteConnection.BeginTransaction())
                            {
                                while (firebirdReader.Read())
                                {
                                    string insertSql = "INSERT INTO GetDadosFirebird VALUES (";
                                    for (int i = 0; i < firebirdReader.FieldCount; i++)
                                    {
                                        var value = firebirdReader.IsDBNull(i) ? "NULL" : $"'{firebirdReader.GetValue(i).ToString().Replace("'", "''")}'";
                                        insertSql += value + ", ";
                                    }

                                    insertSql = insertSql.TrimEnd(',', ' ') + ");";

                                    using (var sqliteCommand = new SQLiteCommand(insertSql, sqliteConnection, transaction))
                                    {
                                        sqliteCommand.ExecuteNonQuery();
                                    }

                                    // Atualizar a barra de progresso
                                    processedRows++;
                                    progressBar.Value = processedRows;
                                    progressBar.Refresh();
                                }

                                transaction.Commit();
                            }
                        }
                    }
                }

                MessageBox.Show("Dados exportados com sucesso para o SQLite!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao exportar dados: {ex.Message}");
            }
        }

        private static int GetRowCount(FbConnection connection, string query)
        {
            string countQuery = $"SELECT COUNT(*) FROM ({query}) AS Temp";
            using (var command = new FbCommand(countQuery, connection))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
    }
}
