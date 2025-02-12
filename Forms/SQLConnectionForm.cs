using DevExpress.XtraEditors;
using J_HR.Class;
using J_HR.SQL;
using System.IO;
using System.Windows.Forms;

namespace J_HR.Forms
{
    public partial class SQLConnectionForm : XtraForm
    {
        public SQLConnectionForm()
        {
            InitializeComponent();
        }
        public string formClose = "";
        private void SQLConnectionForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }
        private async void btn_Save_Click(object sender, System.EventArgs e)
        {
            btn_Save.Text = "Lütfen Bekleyiniz SQL Bağlantısı Kontrol Ediliyor..";
            btn_Save.Enabled = false;
            bool status = await SQLCRUD.TestSqlConnectionAsync(txt_ServerName.Text, txt_UserName.Text, txt_Password.Text, txt_DatabaseName.Text);
            if (status)
            {
                XtraMessageBox.Show("SQL BAĞLANTISI BAŞARILI VE KAYDEDİLDİ", "SQL BAĞLANTISI BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLCRUD.sqlConnection = StringEncryptor.DecryptString(File.ReadAllText(Application.StartupPath + "\\connection.txt").Trim());
                formClose = "kapat";
                string checkProcExistsQuery = File.ReadAllText(Application.StartupPath + "\\Queries\\doctransfer.txt");
                string checkProcExistsQuery1 = File.ReadAllText(Application.StartupPath + "\\Queries\\vactransfer.txt");
                string checkProcExistsQuery2 = File.ReadAllText(Application.StartupPath + "\\Queries\\populationtransfer.txt");
                string checkProcExistsQuery3 = File.ReadAllText(Application.StartupPath + "\\Queries\\persontitletransfer.txt");
                string checkProcExistsQuery4 = File.ReadAllText(Application.StartupPath + "\\Queries\\position.txt");
                string checkProcExistsQuery5 = File.ReadAllText(Application.StartupPath + "\\Queries\\place.txt");
                string checkProcExistsQuery6 = File.ReadAllText(Application.StartupPath + "\\Queries\\job.txt");
                string checkProcExistsQuery7 = File.ReadAllText(Application.StartupPath + "\\Queries\\contact.txt");

                await SQLCRUD.DropExecuteAsync("DROP PROC ASY_VacTransfer ");
                await SQLCRUD.DropExecuteAsync("DROP PROC ASY_DOCAKTAR ");
                await SQLCRUD.DropExecuteAsync("DROP PROC ASY_PERSON_POPULATIONTRANSFER ");
                await SQLCRUD.DropExecuteAsync("DROP PROC ASY_PERSON_TITLE_TRANSFER ");
                await SQLCRUD.DropExecuteAsync("DROP PROC ASY_PERSON_POSITION ");
                await SQLCRUD.DropExecuteAsync("DROP PROC ASY_PERSON_PLACE ");
                await SQLCRUD.DropExecuteAsync("DROP PROC ASY_PERSON_JOB ");
                await SQLCRUD.DropExecuteAsync("DROP PROC ASY_PERSON_CONTACT ");

                bool message = await SQLCRUD.ExecuteAsync(checkProcExistsQuery);
                bool message1 = await SQLCRUD.ExecuteAsync(checkProcExistsQuery1);
                bool message2 = await SQLCRUD.ExecuteAsync(checkProcExistsQuery2);
                bool message3 = await SQLCRUD.ExecuteAsync(checkProcExistsQuery3);
                bool message4 = await SQLCRUD.ExecuteAsync(checkProcExistsQuery4);
                bool message5 = await SQLCRUD.ExecuteAsync(checkProcExistsQuery5);
                bool message6 = await SQLCRUD.ExecuteAsync(checkProcExistsQuery6);
                bool message7 = await SQLCRUD.ExecuteAsync(checkProcExistsQuery7);

                if (!message1)
                    XtraMessageBox.Show("ASY_VacTransfer Prosedürü Oluşturulamadı !! ", "SQL İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!message)
                    XtraMessageBox.Show("ASY_DOCAKTAR Prosedürü Oluşturulamadı !! ", "SQL İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!message2)
                    XtraMessageBox.Show("ASY_PERSON_POPULATIONTRANSFER Prosedürü Oluşturulamadı !! ", "SQL İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!message3)
                    XtraMessageBox.Show("ASY_PERSON_TITLE_TRANSFER Prosedürü Oluşturulamadı !! ", "SQL İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!message4)
                    XtraMessageBox.Show("ASY_PERSON_POSITION Prosedürü Oluşturulamadı !! ", "SQL İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!message5)
                    XtraMessageBox.Show("ASY_PERSON_PLACE Prosedürü Oluşturulamadı !! ", "SQL İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 if (!message6)
                    XtraMessageBox.Show("ASY_PERSON_JOB Prosedürü Oluşturulamadı !! ", "SQL İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
                if (!message7)
                    XtraMessageBox.Show("ASY_PERSON_CONTACT Prosedürü Oluşturulamadı !! ", "SQL İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            btn_Save.Enabled = true;
            btn_Save.Text = "Kaydet";
        }
        private async void SQLConnectionForm_Load(object sender, System.EventArgs e)
        {
            string[] connection = await FileProcess.ReadAndParseConnectionStringAsync("connection.txt");
            if (connection != null && connection.Length > 0)
            {
                txt_ServerName.Text = connection[0].ToString();
                txt_DatabaseName.Text = connection[1].ToString();
                txt_UserName.Text = connection[2].ToString();
                txt_Password.Text = connection[3].ToString();
            }
        }
        private void SQLConnectionForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (formClose == "kapat")
            {
                e.Cancel = false;
            }
            else if (formClose == "kapatma")
            {
                e.Cancel = true;
                XtraMessageBox.Show("ÖNCE SQL BAĞLANTISI İŞLEMİNİ TAMAMLAYIN", "FORM KAPATILAMAZ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}