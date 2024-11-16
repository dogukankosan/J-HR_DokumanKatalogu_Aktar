using DevExpress.XtraEditors;
using J_HR.Class;
using J_HR.Model;
using J_HR.SQL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace J_HR.Forms
{
    public partial class FileAccessManager : XtraForm
    {
        public FileAccessManager()
        {
            InitializeComponent();
        }
        // sql için formatlıyorum in şartı için
        private string values = "''";
        string secilenKlasorYolu = "";
        private async void btn_Files_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Aktarılacak Klasörün Ana Dizini Seçin";
                fbd.ShowNewFolderButton = true;
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    secilenKlasorYolu = fbd.SelectedPath;
                    // Seçilen klasör içerisindeki tüm alt klasörleri alır
                    try
                    {
                        string[] klasorIsimleri = Directory.GetDirectories(secilenKlasorYolu);
                        // Klasör isimlerini yalnızca klasör adı olacak şekilde günceller
                        for (ushort i = 0; i < klasorIsimleri.Length; i++)
                            klasorIsimleri[i] = Path.GetFileName(klasorIsimleri[i]);
                        for (ushort i = 0; i < klasorIsimleri.Length; i++)
                            values += "'" + klasorIsimleri[i] + "',";
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show(ex.Message, "HATALI İŞLEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.TextLogging(ex.Message);
                    }
                 
                    values = values.Substring(0, values.Length - 1); // sondaki , temizliyorum
                    label1.Text = secilenKlasorYolu;
                }
            }
        }
        private void FileAccessManager_Load(object sender, EventArgs e)
        {

        }
        private void btn_Files_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(btn_Files, "Ana Erişim Klasörünü Seçiniz");
        }
        private void FileAccessManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (secilenKlasorYolu == "")
            {
                XtraMessageBox.Show("Önce Ana Dosya Dizini Seçiniz Lütfen", "HATALI İŞLEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btn_Files.Focus();
                return;
            }
            btn_Save.Text = "Aktarma İşlemi Devam Ediyor..";
            try
            {
                List<DocTransferModel> model = await FileToBinaryConvert.ConvertFilesAsync(secilenKlasorYolu);
                foreach (DocTransferModel item in model)
                {
                    SqlParameter[] parameters = new SqlParameter[]
                    {
                    new SqlParameter("@TCNO", SqlDbType.VarChar,25) { Value = item.FolderName },
                    new SqlParameter("@FILENAME", SqlDbType.VarChar, 250) { Value = item.FileName },
                    new SqlParameter("@DOCUMENTCONTENT", SqlDbType.Image) { Value = item.FileContent }
                    };
                    string message = await SQLCRUD.ExecuteStoredProcedureAsync("ASY_DOCAKTAR", parameters);
                    if (message != "Başarılı")
                    {
                        richTextBox1.Text += message + Environment.NewLine;
                        XtraMessageBox.Show(message, "HATALI AKTARMA İŞLEMİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Logger.TextLogging(message);
                    }
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message, "AKTARMA İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.TextLogging(ex.Message);
                btn_Save.Text = "J-HR'a Aktar";
                return;
            }      
            XtraMessageBox.Show("HATA MESAJINIZ VARSA METİN KUTUSUNDAN KONTROL EDİNİZ ONUN DIŞINDAKİLERİ AKTARIM İŞLEMİ TAMAMLANMIŞTIR", "AKTARMA İŞLEMİ TAMAMLANDI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            btn_Save.Text = "J-HR'a Aktar";
        }
    }
}