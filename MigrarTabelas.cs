using FirebirdSql.Data.FirebirdClient;
using System.Data;
using System.Data.SQLite;

namespace ExportFirebirdToSqlite
{
    public partial class MigrarTabelas : Form
    {
        public MigrarTabelas()
        {
            InitializeComponent();
        }

        public async Task MigrateTables(string firebirdConnectionString, string sqliteConnectionString,
                                     List<string> tableNames, ProgressBar tableProgressBar, ProgressBar recordProgressBar,
                                     Label tableProgressLabel, Label recordProgressLabel)
        {
            try
            {
                using (var firebirdConnection = new FbConnection(firebirdConnectionString))
                {
                    firebirdConnection.Open();

                    using (var sqliteConnection = new SQLiteConnection(sqliteConnectionString))
                    {
                        sqliteConnection.Open();

                        // Configurar barra de progresso e label para tabelas
                        tableProgressBar.Minimum = 0;
                        tableProgressBar.Maximum = tableNames.Count;
                        tableProgressBar.Value = 0;

                        foreach (var tableName in tableNames)
                        {

                            // Atualizar label de progresso de tabelas
                            tableProgressLabel.Text = $"Tabela: {tableName} - {(tableProgressBar.Value * 100) / tableProgressBar.Maximum}%";
                            tableProgressLabel.Refresh();

                            // Obter esquema da tabela Firebird
                            string query = $"SELECT * FROM {tableName}";
                            using (var firebirdCommand = new FbCommand(query, firebirdConnection))
                            using (var firebirdReader = firebirdCommand.ExecuteReader())
                            {
                                var schemaTable = firebirdReader.GetSchemaTable();

                                // Criar tabela ou adicionar campos no SQLite
                                using (var sqliteCommand = new SQLiteCommand())
                                {
                                    sqliteCommand.Connection = sqliteConnection;

                                    if (!TableExists(sqliteConnection, tableName))
                                    {
                                        // Criação da tabela no SQLite
                                        string createTableSql = $"CREATE TABLE {tableName} (";
                                        foreach (DataRow row in schemaTable.Rows)
                                        {
                                            string columnName = row["ColumnName"].ToString();
                                            string dataType = row["DataType"].ToString();

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
                                    else
                                    {
                                        // Adicionar campos que ainda não existem
                                        foreach (DataRow row in schemaTable.Rows)
                                        {
                                            string columnName = row["ColumnName"].ToString();
                                            if (!ColumnExists(sqliteConnection, tableName, columnName))
                                            {
                                                string dataType = row["DataType"].ToString();

                                                string sqliteType = dataType switch
                                                {
                                                    "System.Int32" => "INTEGER",
                                                    "System.String" => "TEXT",
                                                    "System.DateTime" => "DATETIME",
                                                    "System.Decimal" => "REAL",
                                                    "System.Double" => "REAL",
                                                    _ => "TEXT"
                                                };

                                                string alterTableSql = $"ALTER TABLE {tableName} ADD COLUMN {columnName} {sqliteType};";
                                                sqliteCommand.CommandText = alterTableSql;
                                                sqliteCommand.ExecuteNonQuery();
                                            }
                                        }
                                    }
                                }

                                // Configurar barra de progresso e label para registros
                                int totalRecords = GetRowCount(firebirdConnection, tableName);
                                recordProgressBar.Minimum = 0;
                                recordProgressBar.Maximum = totalRecords;
                                recordProgressBar.Value = 0;

                                recordProgressLabel.Text = "0%";
                                recordProgressLabel.Refresh();

                                // Inserir dados no SQLite somente se não existirem
                                using (var transaction = sqliteConnection.BeginTransaction())
                                {
                                    int processedRecords = 0;

                                    while (firebirdReader.Read())
                                    {
                                        // Construir comando de verificação
                                        string checkExistsSql = $"SELECT 1 FROM {tableName} WHERE ";
                                        for (int i = 0; i < firebirdReader.FieldCount; i++)
                                        {
                                            string columnName = firebirdReader.GetName(i);
                                            var value = firebirdReader.IsDBNull(i) ? "NULL" : $"'{firebirdReader.GetValue(i).ToString().Replace("'", "''")}'";
                                            checkExistsSql += $"{columnName} = {value} AND ";
                                        }
                                        checkExistsSql = checkExistsSql.TrimEnd(" AND ".ToCharArray());

                                        using (var checkCommand = new SQLiteCommand(checkExistsSql, sqliteConnection))
                                        {
                                            bool recordExists = checkCommand.ExecuteScalar() != null;

                                            if (!recordExists)
                                            {
                                                string insertSql = $"INSERT INTO {tableName} VALUES (";
                                                for (int i = 0; i < firebirdReader.FieldCount; i++)
                                                {
                                                    var value = firebirdReader.IsDBNull(i)
                                                        ? "NULL"
                                                        : $"'{firebirdReader.GetValue(i).ToString().Replace("'", "''")}'";
                                                    insertSql += value + ", ";
                                                }

                                                insertSql = insertSql.TrimEnd(',', ' ') + ");";

                                                using (var sqliteCommand = new SQLiteCommand(insertSql, sqliteConnection, transaction))
                                                {
                                                    sqliteCommand.ExecuteNonQuery();
                                                }
                                            }
                                        }

                                        // Atualizar barra de progresso de registros
                                        processedRecords++;
                                        recordProgressBar.Value = processedRecords;
                                        recordProgressBar.Refresh();

                                        // Atualizar label de progresso de registros
                                        recordProgressLabel.Text = $"Registros: {(processedRecords * 100) / totalRecords}%";
                                        recordProgressLabel.Refresh();
                                    }

                                    transaction.Commit();
                                }
                            }

                            // Atualizar barra de progresso de tabelas
                            tableProgressBar.Value++;
                            tableProgressBar.Refresh();

                            // Atualizar label de progresso de tabelas
                            tableProgressLabel.Text = $"Tabela: {tableName} - {(tableProgressBar.Value * 100) / tableProgressBar.Maximum}%";
                            tableProgressLabel.Refresh();
                        }
                    }

                    MessageBox.Show("Migração concluída com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro na migração: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool TableExists(SQLiteConnection connection, string tableName)
        {
            string query = "SELECT name FROM sqlite_master WHERE type='table' AND name=@tableName";
            using (var command = new SQLiteCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tableName", tableName);
                return command.ExecuteScalar() != null;
            }
        }

        private static bool ColumnExists(SQLiteConnection connection, string tableName, string columnName)
        {
            string query = $"PRAGMA table_info({tableName});";
            using (var command = new SQLiteCommand(query, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader["name"].ToString().Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private static int GetRowCount(FbConnection connection, string tableName)
        {
            string countQuery = $"SELECT COUNT(*) FROM {tableName}";
            using (var command = new FbCommand(countQuery, connection))
            {
                return Convert.ToInt32(command.ExecuteScalar());
            }
        }
        private async void Executar_Click(object sender, EventArgs e)
        {
            var lista = new List<string>(txtTabelas.Text.ToUpper().Split(','));
            await MigrateTables(txtStringFirebird.Text, txtStringSQLITE.Text, lista, pbTabelas, pbResgistros, lblProgressoTabela, lblProgressoRegistros);
        }
    }
}
