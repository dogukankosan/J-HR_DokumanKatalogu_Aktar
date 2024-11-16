using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace J_HR.Class
{
    internal class StringEncryptor
    {
        private static readonly string encryptionKey = "Asyen0212!SecureKey"; // 16 karakter veya daha fazla bir anahtar
        internal static string EncryptString(string plainText)
        {
            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 16)); // 16 byte anahtar uzunluğu
                byte[] ivBytes = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 16)); // 16 byte IV uzunluğu
                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                            cryptoStream.Write(plainBytes, 0, plainBytes.Length);
                            cryptoStream.FlushFinalBlock();
                            return Convert.ToBase64String(memoryStream.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ŞİFRELEME HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Hata durumunda null döndür
            }
        }
        internal static string DecryptString(string cipherText)
        {
            try
            {
                byte[] keyBytes = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 16)); // 16 byte anahtar uzunluğu
                byte[] ivBytes = Encoding.UTF8.GetBytes(encryptionKey.Substring(0, 16)); // 16 byte IV uzunluğu
                using (Aes aes = Aes.Create())
                {
                    aes.Key = keyBytes;
                    aes.IV = ivBytes;
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            byte[] cipherBytes = Convert.FromBase64String(cipherText);
                            cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);
                            cryptoStream.FlushFinalBlock();
                            return Encoding.UTF8.GetString(memoryStream.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "ŞİFRELEME ÇÖZME HATASI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; // Hata durumunda null döndür
            }
        }
    }
}