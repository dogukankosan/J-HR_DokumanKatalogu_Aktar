using System;
using System.Data;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using ExcelDataReader;
using System.Diagnostics;
using J_HR.SQL;
using System.Globalization;
using J_HR.Class;
namespace J_HR.Forms
{
    public partial class PopulationForm : XtraForm
    {
        public PopulationForm()
        {
            InitializeComponent();
        }
        private bool statusClose = false;
        private void BloodForm_Load(object sender, EventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.RowSelect;
            gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
        }
        private void btn_Excel_Click(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.RefreshDataSource();
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
            string filePath = $"{Application.StartupPath}\\Template\\Population.xlsx";
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
                gridControl1.RefreshDataSource();
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
            await SQLCRUD.ExecuteAsync(@"IF OBJECT_ID('dbo.AKTARPOPULATIONTRANSFERPERSON', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.AKTARPOPULATIONTRANSFERPERSON;
            END;
            CREATE TABLE AKTARPOPULATIONTRANSFERPERSON
           (
ID INT PRIMARY KEY IDENTITY(1,1),
PERSONCODE VARCHAR(16),
DADDYNAME VARCHAR(30),
MUMMYNAME VARCHAR(30),
BIRTHPLACE VARCHAR(30),
BIRTHDATE DATETIME,
MARTIALNAME VARCHAR(20),
BLOODGROUPNAME VARCHAR(20),
IDTCNO VARCHAR(20),
CITY VARCHAR(30),
TOWN VARCHAR(30),
VILLAGE VARCHAR(50),
); ");
            await SQLCRUD.ExecuteAsync("TRUNCATE TABLE AKTARPOPULATIONTRANSFERPERSON"); 
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                string personelCode = gridView1.GetRowCellValue(i, gridView1.Columns[0])?.ToString();
                string daddy = gridView1.GetRowCellValue(i, gridView1.Columns[1])?.ToString();
                string mummy = gridView1.GetRowCellValue(i, gridView1.Columns[2])?.ToString();
                string birthplace = gridView1.GetRowCellValue(i, gridView1.Columns[3])?.ToString();
                string birthdate = gridView1.GetRowCellValue(i, gridView1.Columns[4])?.ToString();
                DateTime parsedDate;
                if (DateTime.TryParseExact(birthdate, "d.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate))
                {
                    birthdate = parsedDate.ToString("yyyy-MM-dd HH:mm:ss");
                }
                else
                    birthdate = null;
                string marital = gridView1.GetRowCellValue(i, gridView1.Columns[5])?.ToString();
                string blood = gridView1.GetRowCellValue(i, gridView1.Columns[6])?.ToString();
                string tc = gridView1.GetRowCellValue(i, gridView1.Columns[7])?.ToString();
                string city = gridView1.GetRowCellValue(i, gridView1.Columns[8])?.ToString();
                string town = gridView1.GetRowCellValue(i, gridView1.Columns[9])?.ToString();
                string village = gridView1.GetRowCellValue(i, gridView1.Columns[10])?.ToString();

                await SQLCRUD.ExecuteAsync($@"
        INSERT INTO AKTARPOPULATIONTRANSFERPERSON 
        (PERSONCODE, DADDYNAME, MUMMYNAME, BIRTHPLACE, BIRTHDATE, MARTIALNAME, BLOODGROUPNAME, IDTCNO, CITY, TOWN, VILLAGE) 
        VALUES 
        ('{personelCode}', '{daddy}', '{mummy}', '{birthplace}', '{birthdate}', '{marital}', '{blood}', '{tc}', '{city}', '{town}', '{village}')
    ");
            }
            bool status = await SQLCRUD.ExecuteAsync("EXEC ASY_PERSON_POPULATIONTRANSFER");
            if (status)
            {
                XtraMessageBox.Show("Aktarım işleminiz tamamlandı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusClose = true;
            }    
        }
        private async void btn_FullBackup_Click(object sender, EventArgs e)
        {
            await Backup.FullBackUp(btn_ExcelTemplate, btn_Save, btn_Excel, label1, btn_FullBackup);
        }
        private async void btn_TableBackup_Click_1(object sender, EventArgs e)
        {
            await Backup.TableBackUp("populationtransfer.txt");
        }
    }
}