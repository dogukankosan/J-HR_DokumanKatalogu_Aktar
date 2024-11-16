using J_HR.Forms;
using J_HR.SQL;
using System;
using System.Windows.Forms;

namespace J_HR
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
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
    }
}