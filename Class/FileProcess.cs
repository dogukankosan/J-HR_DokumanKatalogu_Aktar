using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace J_HR.Class
{
    internal class FileProcess
    {
        internal static async Task SaveToFileAsync(string fileName, string content, bool clearContent) // true olursa siler, false içeriği silmez
        {
            try
            {
                // Uygulama klasörünün yolunu al
                string appFolderPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(appFolderPath, fileName);
                // Dosya içeriğini temizleme veya ekleme modunu belirle
                if (clearContent)
                    // Dosyanın içeriğini temizleyerek yaz
                    await Task.Run(() => File.WriteAllText(filePath, content));
                else
                    // Dosya varsa içeriğin sonuna ekle
                    await Task.Run(() => File.AppendAllText(filePath, content));
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "DOSYA KAYDETME HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.TextLogging(ex.Message);
            }
        }
        internal static async Task<string[]> ReadAndParseConnectionStringAsync(string fileName)
        {
            try
            {
                // Uygulama klasöründeki dosyanın yolunu al
                string appFolderPath = AppDomain.CurrentDomain.BaseDirectory;
                string filePath = Path.Combine(appFolderPath, fileName);
                // Dosyadan şifrelenmiş bağlantı dizesini oku
                if (File.Exists(filePath))
                {
                    // Asenkron olarak dosyayı oku
                    string encryptedConnectionString = await Task.Run(() => File.ReadAllText(filePath));
                    // Şifreyi çöz
                    string decryptedConnectionString = StringEncryptor.DecryptString(encryptedConnectionString);
                    // Bağlantı dizesini ayrıştır ve her bir bileşeni diziye aktar
                    List<string> connectionParts = new List<string>();
                    // Her bir parametreyi ; karakteri ile ayır
                    string[] parameters = decryptedConnectionString.Split(';');
                    foreach (string param in parameters)
                    {
                        if (!string.IsNullOrEmpty(param))
                        {
                            // '=' karakterine göre ayır ve değeri al
                            var keyValue = param.Split('=');
                            if (keyValue.Length == 2)
                            {
                                connectionParts.Add(keyValue[1].Trim());
                            }
                        }
                    }
                    return connectionParts.ToArray(); // Diziyi döndür
                }
                else
                {
                    XtraMessageBox.Show($"{fileName} DOSYASINDAN OKUNAMADI", "OKUMA İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "OKUMA İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.TextLogging(ex.Message);
                return null; // Hata durumunda null döndür
            }
        }
    }
}