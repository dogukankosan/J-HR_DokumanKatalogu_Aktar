using System;
using System.Threading;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace J_HR
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            bool isNewInstance;
            using (Mutex mutex = new Mutex(true, "J_HR_Application", out isNewInstance))
            {
                if (!isNewInstance)
                {
                    // Program zaten açık, kullanıcıya uyarı mesajı göster
                    XtraMessageBox.Show("Program zaten çalışıyor!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
            }
        }
    }
}