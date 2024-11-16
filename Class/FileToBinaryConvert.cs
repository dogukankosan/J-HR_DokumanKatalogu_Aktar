using DevExpress.XtraEditors;
using J_HR.Class;
using J_HR.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

internal class FileToBinaryConvert
{
    // İzin verilen dosya türleri listesi
    private static readonly HashSet<string> AllowedExtensions = new HashSet<string>
    {
        ".jpg", ".jpeg", ".png", ".pdf", ".docx", ".xlsx",".rtf",".xls",".html","xml"  // İzin verilen dosya türlerini buraya ekleyin
    };
    // Ana metot: Belirtilen klasördeki dosyaları okuyarak veritabanına kaydedilecek veriyi hazırlar
    public static async Task<List<DocTransferModel>> ConvertFilesAsync(string rootFolderPath)
    {
        List<DocTransferModel> filesData = new List<DocTransferModel>();

        // Root klasörün altındaki klasörleri al
        string[] directories = Directory.GetDirectories(rootFolderPath);

        foreach (string directory in directories)
        {
            // Klasör adını (örneğin TC numarası) al
            string folderName = new DirectoryInfo(directory).Name;

            // Her belirtilen dosya uzantısı için arama yap
            foreach (string extension in AllowedExtensions)
            {
                // Dosya uzantısının izinli olup olmadığını kontrol ediyoruz
                if (!AllowedExtensions.Contains(extension.ToLower()))
                {
                    Console.WriteLine($"{extension} dosya türüne izin verilmediği için işlenmedi.");
                    continue;
                }

                string[] files = Directory.GetFiles(directory, $"*{extension}", SearchOption.AllDirectories);

                foreach (string file in files)
                {
                    // Dosya binary formata çevriliyor
                    byte[] fileBinary = await FileToBinaryAsync(file);

                    // Dosya bilgisi koleksiyona ekleniyor
                    filesData.Add(new DocTransferModel
                    {
                        FolderName = folderName,
                        FileName = Path.GetFileName(file),
                        FileExtension = extension,
                        FileContent = fileBinary
                    });
                }
            }
        }
        return filesData; // Veritabanına eklemek için dosya bilgilerini geri döndürüyoruz
    }
    // Dosyayı binary formata çeviren yardımcı metot (asenkron)
    private static async Task<byte[]> FileToBinaryAsync(string filePath)
    {
        try
        {
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true))
            {
                byte[] fileBytes = new byte[fs.Length];
                await fs.ReadAsync(fileBytes, 0, (int)fs.Length);
                return fileBytes;
            }
        }
        catch (Exception ex)
        {

            XtraMessageBox.Show(ex.Message, "HATALI İŞLEM", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Logger.TextLogging(ex.Message);
        }
        return null;
    }
}
