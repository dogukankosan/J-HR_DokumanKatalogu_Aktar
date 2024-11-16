using DevExpress.XtraEditors;
using J_HR.Class;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J_HR.SQL
{
    internal class SQLCRUD
    {
        public static string sqlConnection= StringEncryptor.DecryptString(File.ReadAllText(Application.StartupPath+ "\\connection.txt").Trim());
        public static async Task<bool> TestSqlConnectionLoadAsync()
        {
            try
            {
                using (SqlConnection connection =  new SqlConnection(sqlConnection))
                {
                    await connection.OpenAsync();
                    return true; // Başarılıysa true döndür
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SQL BAĞLANTISI HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.TextLogging(ex.Message);
                return false; // Bağlantı başarısızsa false döndür
            }
        }
        public static async Task<bool> TestSqlConnectionAsync(string serverName, string userName, string password, string databaseName)
        {
            // Bağlantı dizesini oluştur, 10 saniyelik zaman aşımı ekle
            string connectionString = $"Server={serverName};Database={databaseName};User Id={userName};Password={password};Connect Timeout=10;Encrypt=True;TrustServerCertificate=True;";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string connectionEnc = StringEncryptor.EncryptString(connectionString);
                    await FileProcess.SaveToFileAsync("connection.txt", connectionEnc, true);
                    return true; // Başarılıysa true döndür
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "SQL BAĞLANTISI HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.TextLogging(ex.Message);
                return false; // Bağlantı başarısızsa false döndür
            }
        }
        public static async Task<DataTable> DataListAsync(string sqlQuery)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(sqlConnection))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATALI SQL LİSTELEME İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.TextLogging(ex.Message);
            }
            return dataTable;
        }
        public static async Task<string> ExecuteStoredProcedureAsync(string procedureName, SqlParameter[] parameters)
        {
            string errorMessage = "";
            try
            {
                // SqlConnection kullanarak veritabanına bağlan
                using (SqlConnection connection = new SqlConnection(sqlConnection))
                {
                    await connection.OpenAsync();
                    // SqlCommand ile prosedürü hazırla
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.CommandTimeout = 0;
                        // Parametreleri ekle
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        // Prosedürü asenkron olarak çalıştır
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda hata mesajını yakala
                errorMessage = string.Concat(ex.Message, "\n");
                Logger.TextLogging(ex.Message);
                return errorMessage;
            }
            return "Başarılı";
        }
        public static async Task<string> ExecuteAsync(string query)
        {
            string errorMessage = "";
            try
            {
                // SqlConnection kullanarak veritabanına bağlan
                using (SqlConnection connection = new SqlConnection(sqlConnection))
                {
                    await connection.OpenAsync();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        await command.ExecuteNonQueryAsync();
                    }
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda hata mesajını yakala
                errorMessage = string.Concat(ex.Message);
                Logger.TextLogging(ex.Message);
                return errorMessage;
            }
            return "Başarılı";
        }
    }
}