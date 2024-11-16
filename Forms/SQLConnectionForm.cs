using DevExpress.XtraEditors;
using J_HR.Class;
using J_HR.SQL;
using System.IO;
using System.Text;
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
            if (e.KeyCode==Keys.Escape)
                this.Close();
        }
        private async void btn_Save_Click(object sender, System.EventArgs e)
        {
            btn_Save.Text = "Lütfen Bekleyiniz SQL Bağlantısı Kontrol Ediliyor..";
            btn_Save.Enabled = false;
            bool status=await SQLCRUD.TestSqlConnectionAsync(txt_ServerName.Text, txt_UserName.Text, txt_Password.Text, txt_DatabaseName.Text);
            if (status)
            {
                XtraMessageBox.Show("SQL BAĞLANTISI BAŞARILI VE KAYDEDİLDİ", "SQL BAĞLANTISI BAŞARILI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SQLCRUD.sqlConnection= StringEncryptor.DecryptString(File.ReadAllText(Application.StartupPath + "\\connection.txt").Trim());
                formClose = "kapat";
                string checkProcExistsQuery = @"IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ASY_DOCAKTAR]') AND type in (N'P', N'PC'))
BEGIN
    EXEC('
    CREATE PROCEDURE ASY_DOCAKTAR 
        @TCNO char(11), 
        @FILENAME VARCHAR(250), 
        @DOCUMENTCONTENT IMAGE 
    AS 
    BEGIN 
        DECLARE @NextValueForD_BODocumentsSeq INT; 
        DECLARE @NextValueForD_WFDocsSeq INT; 
        DECLARE @CLIENTREF INT; 
        DECLARE @NAMESURNAME VARCHAR(100); 
        SELECT TOP 1 
            @CLIENTREF = TE_WPIID, 
            @NAMESURNAME = CONCAT(NAME, '' '', SURNAME) 
        FROM H_001_PERSONS WITH (NOLOCK) 
        WHERE TYP=1 AND SSCNO = @TCNO;
        
        BEGIN TRANSACTION;

        BEGIN TRY 
            SET @NextValueForD_BODocumentsSeq = NEXT VALUE FOR D_BODOCUMENTSSEQ; 
            SET @NextValueForD_WFDocsSeq = NEXT VALUE FOR D_WFDOCSSEQ; 

            INSERT INTO D_BODOCUMENTS 
                ([LOGICALREF], [CLASSNAME], [BOLREF], [CONTAINERNAME], [DOCNAME], [DOCPATH], 
                 [DOCREVISION], [DOCURI], [INLOCK], [OPTYPE], [DEFAULTCONT], [VARIABLE1], 
                 [VARIABLE2], [HASPASSWORD], [AUXCODE], [AYNACID], [AUTHCODE], [TE_RECSTATUS], 
                 [TE_LABELS], [CREATEDBY], [CREATEDBYNAME], [CREATEDON], [MODIFIEDBY], 
                 [MODIFIEDBYNAME], [MODIFIEDON], [TE_SUBCOMPANY],[TE_WPIID], [TE_WFIID], 
                 [TE_DOMAINID], [TE_RIGHTS]) 
            VALUES 
                (@NextValueForD_BODocumentsSeq, ''Employee'', @CLIENTREF, ''WFDOCS'', @FILENAME, ''/'', 
                 ''1.0'', CONCAT(''WFDOCS:/'', @FILENAME, '','' , ''1.0''), 0, 3, 0, 1, 1, 0, '''', '''', '''', 1, NULL, 
                 4, ''asyen'', GETDATE(), 0, '''', NULL, 0, 0, '''', 0, 0);

            INSERT INTO D_WFDOCS 
                ([LOGICALREF], [PARENTREF], [ELEMTYPE], [ELEMNAME], [ELEMPATH], [DOCUDI], 
                 [DESCRIPTION], [REVISION], [CREATEDON], [MODIFIEDON], [DOCUMENT], [AUXCODE], 
                 [DOCPASSWD], [HASPASSWORD], [AUTHCODE], [TE_RECSTATUS], [TE_LABELS], [CREATEDBY], 
                 [CREATEDBYNAME], [MODIFIEDBY], [MODIFIEDBYNAME], [TE_SUBCOMPANY], [TE_WPIID], 
                 [TE_WFIID], [TE_DOMAINID], [TE_RIGHTS]) 
            VALUES 
                (@NextValueForD_WFDocsSeq, 0, 1, @FILENAME, ''/'', CONCAT(''WFDOCS:/'', @FILENAME, '','' , ''1.0''), '''', ''1.0'', GETDATE(), NULL, @DOCUMENTCONTENT, '''', NULL, 0, '''', -1, NULL, 4, ''asyen'', 0, '''', 0, 0, '''', 0, 0);

            COMMIT TRANSACTION; 
        END TRY 
        BEGIN CATCH 
            ROLLBACK TRANSACTION; 
            DECLARE @ErrorMessage NVARCHAR(4000) = CONCAT(''TC No: '', @TCNO, '' Personel Adı: '', ISNULL(@NAMESURNAME, ''TC Kimlik No Personel J-HR YOK''), '' '', ERROR_MESSAGE()); 
            DECLARE @ErrorSeverity INT = ERROR_SEVERITY(); 
            DECLARE @ErrorState INT = ERROR_STATE(); 
            RAISERROR(@ErrorMessage, @ErrorSeverity, @ErrorState); 
        END CATCH 
    END')
END;
";
                string message =await SQLCRUD.ExecuteAsync(checkProcExistsQuery);
                if (message!="Başarılı")
                    XtraMessageBox.Show("ASY_DOCAKTAR Prosedürü Oluşturulamadı !! ", "SQL İŞLEMİ HATALI", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (formClose=="kapat")
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