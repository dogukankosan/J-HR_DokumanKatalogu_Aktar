using DevExpress.XtraEditors;
using J_HR.Forms;
using J_HR.SQL;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace J_HR
{
    public partial class Form1 :XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async void Form1_Load(object sender, EventArgs e)
        {
            bool status=await SQLCRUD.TestSqlConnectionLoadAsync();
            if (!status)
            {
                // Açılacak formun daha önce açılıp açılmadığını kontrol et
                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm is SQLConnectionForm)
                    {
                        // Form zaten açıksa, o formu öne getir ve işlemi sonlandır
                        openForm.BringToFront();
                        return;
                    }
                }
                // Eğer form açık değilse, yeni bir örneğini oluştur ve aç
                SQLConnectionForm childForm = new SQLConnectionForm();
                childForm.MdiParent = this;
                childForm.formClose = "kapatma";
                childForm.Show();
            }
        }
        private void menu_SQLConnection_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Açılacak formun daha önce açılıp açılmadığını kontrol et
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is SQLConnectionForm)
                {
                    // Form zaten açıksa, o formu öne getir ve işlemi sonlandır
                    openForm.BringToFront();
                    return;
                }
            }
            // Eğer form açık değilse, yeni bir örneğini oluştur ve aç
            SQLConnectionForm childForm = new SQLConnectionForm();
            childForm.MdiParent = this;
            childForm.Show();
        }
        private void menu_FileAccess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Açılacak formun daha önce açılıp açılmadığını kontrol et
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is FileAccessManager)
                {
                    // Form zaten açıksa, o formu öne getir ve işlemi sonlandır
                    openForm.BringToFront();
                    return;
                }
            }
            // Eğer form açık değilse, yeni bir örneğini oluştur ve aç
            FileAccessManager childForm = new FileAccessManager();
            childForm.MdiParent = this;
            childForm.Show();
        }
        private void bar_Personpermission_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is PermissionForm)
                {
                    openForm.BringToFront();
                    return;
                }
            }
            PermissionForm childForm = new PermissionForm();
            childForm.MdiParent = this;
            childForm.Show();
        }
        private void bar_blood_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is PopulationForm)
                {
                    openForm.BringToFront();
                    return;
                }
            }
            PopulationForm childForm = new PopulationForm();
            childForm.MdiParent = this;
            childForm.Show();
        }
        private void btn_Title_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            foreach(Form openForm in Application.OpenForms)
            {
                if (openForm is TitleForm)
                {
                    openForm.BringToFront();
                    return;
                }
            }
            TitleForm childForm = new TitleForm();
            childForm.MdiParent = this;
            childForm.Show();
        }
        private void btn_TableChange_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string result = XtraInputBox.Show("Değiştirelecek tablo şirket bilgisi giriniz:", "Tablo Şirket Takısı", "XXX");
            if (string.IsNullOrEmpty(result))
            {
                XtraMessageBox.Show("Tablo şirket takı boş geçilemez !!","Hatalı Veri Girişi",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Queries");
            if (Directory.Exists(folderPath))
            {
                // Tüm .txt dosyalarını al
                string[] txtFiles = Directory.GetFiles(folderPath, "*.txt");
                foreach (string file in txtFiles)
                {
                    string fileContent = File.ReadAllText(file);
                    // H_ veya U_ ile başlayan ve ardından 3 karakter gelen yapıları bul ve değiştir
                    string updatedContent = Regex.Replace(fileContent, @"\b(H_|U_)(\d{3})(\w*)", match =>
                    {
                        string prefix = match.Groups[1].Value; // H_ veya U_
                        string currentCode = match.Groups[2].Value; // 3 karakterlik şirket bilgisi
                        string rest = match.Groups[3].Value; // Geri kalan kısım (örneğin tablo ismi)
                        return prefix + result + rest; // Yeni şirket kodunu ekle
                    });
                    // Dosyayı güncelle
                    File.WriteAllText(file, updatedContent);
                }
                XtraMessageBox.Show("Tüm dosyalar başarıyla güncellendi.","Başarılı",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
                XtraMessageBox.Show("Belirtilen dosya bulunamadı..", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}