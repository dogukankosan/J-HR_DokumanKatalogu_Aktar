using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using J_HR.SQL;
using J_HR.Class;
using ExcelDataReader;
using System.IO;
using System.Diagnostics;

namespace J_HR.Forms
{
    public partial class TitleForm : XtraForm
    {
        public TitleForm()
        {
            InitializeComponent();
        }
        private bool statusClose = false;
        private async void btn_FullBackup_Click(object sender, EventArgs e)
        {
            await Backup.FullBackUp(btn_ExcelTemplate, btn_Save, btn_Excel, label1, btn_FullBackup);
        }
        private void btn_Excel_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                Title = "Bir Excel Dosyası Seçin"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofd.FileName;
                try
                {
                    DataTable dt = ReadExcelData(filePath);
                    gridControl1.DataSource = dt;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Hata: {ex.Message}", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
                return;
        }
        private DataTable ReadExcelData(string filePath)
        {
            DataTable dataTable = new DataTable();
            using (FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true // İlk satır başlık olarak kullanılır
                        }
                    });
                    dataTable = result.Tables[0];
                }
            }
            return dataTable;
        }
        private void btn_ExcelTemplate_Click(object sender, EventArgs e)
        {
            string filePath = $"{Application.StartupPath}\\Template\\Title.xlsx";
            if (File.Exists(filePath))
            {
                try
                {
                    Process.Start(new ProcessStartInfo(filePath) { UseShellExecute = true });
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Dosya açılamadı. Hata: {ex.Message}", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
                XtraMessageBox.Show("Excel dosyası bulunamadı. Lütfen yolu kontrol edin.", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void TitleForm_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false; // Düzenlemeyi kapat
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect; // Satır seçimi
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false; // Hücre odaklanmasını kaldır
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus; // Tüm satırı vurgula
        }
        private async void btn_Save_Click(object sender, EventArgs e)
        {
            if (statusClose)
            {
                XtraMessageBox.Show($"Aktarım işlemi yaptınız tekrardan yapmak için formu kapatıp açınız", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (gridView1.RowCount == 0)
            {
                XtraMessageBox.Show("Lütfen önce excelden verileri gridview'e çekiniz !!", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
                OpenFileDialog ofd = new OpenFileDialog
                {
                    Filter = "Excel Files|*.xls;*.xlsx;*.xlsm",
                    Title = "Bir Excel Dosyası Seçin"
                };
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string filePath = ofd.FileName;
                    try
                    {
                        DataTable dt = ReadExcelData(filePath);
                        gridControl1.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        XtraMessageBox.Show($"Hata: {ex.Message}", "Hatalı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                    return;
                return;
            }
            await SQLCRUD.ExecuteAsync(@"IF OBJECT_ID('dbo.AKTARPERSONTITLE', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.AKTARPERSONTITLE;
            END;
            CREATE TABLE AKTARPERSONTITLE
           (
ID INT PRIMARY KEY IDENTITY(1,1),
PERSONCODE VARCHAR(16) NOT NULL,
TITLECODE VARCHAR(32),
TITLENAME VARCHAR(150)
); ");
            await SQLCRUD.ExecuteAsync("TRUNCATE TABLE  AKTARPERSONTITLE");
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string personelCode = gridView1.GetRowCellValue(i, gridView1.Columns[0])?.ToString();
                string titleCode = gridView1.GetRowCellValue(i, gridView1.Columns[1])?.ToString();
                string titleName = gridView1.GetRowCellValue(i, gridView1.Columns[2])?.ToString();
                await SQLCRUD.ExecuteAsync($@" INSERT INTO AKTARPERSONTITLE (PERSONCODE, TITLECODE, TITLENAME ) VALUES ('{personelCode}', '{titleCode}', '{titleName}')");
            }
            bool status = await SQLCRUD.ExecuteAsync("EXEC ASY_PERSON_TITLE_TRANSFER");
            if (status)
            {
                XtraMessageBox.Show("Aktarım işleminiz tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusClose = true;
            }
        }
        private async void btn_TableBackup_Click(object sender, EventArgs e)
        {
           await  Backup.TableBackUp("persontitletransfer.txt");
        }
    }
}