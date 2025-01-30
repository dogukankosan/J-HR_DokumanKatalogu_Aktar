using DevExpress.XtraEditors;
using J_HR.SQL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J_HR.Class
{
    internal class Backup
    {
        internal static async Task FullBackUp(SimpleButton btn_ExcelTemplate, SimpleButton btn_Save, SimpleButton btn_Excel, Label label1, SimpleButton btn_FullBackup)
        {
            bool status = false;
            btn_ExcelTemplate.Enabled = false;
            btn_Save.Enabled = false;
            btn_Excel.Enabled = false;
            label1.Text = "Yedekleme İşlemi Devam Ediyor Bekleyiniz !!";
            label1.ForeColor = Color.Blue;
            btn_FullBackup.Enabled = false;
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                string databaseName = "";
                folderBrowserDialog.Description = "Lütfen yedeğin kaydedileceği klasörü seçin";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string[] connection = await FileProcess.ReadAndParseConnectionStringAsync("connection.txt");
                    if (connection != null && connection.Length > 0)
                    {
                        databaseName = connection[1].ToString();
                    }
                    string backupFolderPath = folderBrowserDialog.SelectedPath;
                    string backupFileName = $"{backupFolderPath}\\{databaseName}_FullBackup_{DateTime.Now:yyyyMMddHHmmss}.bak";
                    status = await SQLCRUD.ExecuteAsync($@"
                        BACKUP DATABASE [{databaseName}] 
                        TO DISK = '{backupFileName}' 
                        WITH FORMAT, INIT, SKIP, NAME = 'Full Backup of {databaseName}', STATS = 10;");
                    if (status)
                        XtraMessageBox.Show("Full yedek işlemi başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                btn_FullBackup.Enabled = true;
                btn_ExcelTemplate.Enabled = true;
                btn_Save.Enabled = true;
                btn_Excel.Enabled = true;
                label1.Text = status ? "YEDEK ALINDI TEŞEKKÜRLER 😎" : "İŞLEM ÖNCESİ YEDEK ALMAYI UNUTMA !!";
                label1.ForeColor = status ? Color.Green : Color.Red;
            }
        }
        internal static async Task TableBackUp(string filetxt)
        {
            string folderPath = Path.Combine(Application.StartupPath, "Queries");
            string filePath = Path.Combine(folderPath, filetxt);
            if (!File.Exists(filePath))
            {
                XtraMessageBox.Show($"Dosya bulunamadı: {filePath}", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Dosya içeriğini oku
            string fileContent = File.ReadAllText(filePath);
            // H_, U_, D_, S_ ile başlayan ve SEQ içermeyen tablo isimlerini bul
            HashSet<string> tables = new HashSet<string>();
            MatchCollection matches = Regex.Matches(fileContent, @"\b(H_|U_|D_|S_)\w+");
            foreach (Match match in matches)
            {
                string tableName = match.Value;
                // SEQ içeren tabloları atla
                if (tableName.IndexOf("SEQ", StringComparison.OrdinalIgnoreCase) < 0)
                    tables.Add(tableName);
            }
            // SQL yedekleme işlemi
            List<string> successList = new List<string>();
            List<string> failedList = new List<string>();
            foreach (var table in tables)
            {
                // Rastgele bir sayı oluştur
                int randomSuffix = new Random().Next(1000, 9999);
                string backupTableName = $"YEDEK_{table}_{randomSuffix}";
                // SQL komutunu oluştur
                string sql = $"SELECT * INTO {backupTableName} FROM {table}";
                try
                {
                    await SQLCRUD.ExecuteAsync(sql);
                    successList.Add(backupTableName);
                }
                catch (Exception ex)
                {
                    failedList.Add($"{table}: {ex.Message}");
                }
            }
            // Mesaj kutusunda sonuçları göster
            string successMessage = successList.Count > 0 ? "Başarıyla yedek alınan tablolar:\n" + string.Join("\n", successList) : "Hiçbir tablo yedeklenemedi.";
            string failedMessage = failedList.Count > 0 ? "\n\nYedek alınamayan tablolar:\n" + string.Join("\n", failedList) : "";
            XtraMessageBox.Show(successMessage + failedMessage, "Yedekleme Sonuçları", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}