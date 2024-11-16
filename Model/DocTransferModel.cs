namespace J_HR.Model
{
    internal class DocTransferModel
    {
        internal string FolderName { get; set; }  // Klasör adı (TC numarası gibi)
        internal string FileName { get; set; }    // Dosya adı
        internal string FileExtension { get; set; } // Dosya uzantısı
        internal byte[] FileContent { get; set; } // Dosyanın binary verisi
    }
}