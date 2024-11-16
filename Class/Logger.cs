using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;

namespace J_HR.Class
{
   internal class Logger
    {
        internal static void TextLogging(string message)
        {
            try
            {
                string logFilePath = $"{Application.StartupPath}\\log.txt";
                Directory.CreateDirectory(Path.GetDirectoryName(logFilePath));
                File.AppendAllText(logFilePath, $"{DateTime.Now}: {message}\n");
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "HATALI LOGLAMA İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}