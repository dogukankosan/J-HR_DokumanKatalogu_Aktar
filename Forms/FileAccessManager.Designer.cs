namespace J_HR.Forms
{
    partial class FileAccessManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileAccessManager));
            this.btn_Files = new DevExpress.XtraEditors.SimpleButton();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_TableBackup = new DevExpress.XtraEditors.SimpleButton();
            this.btn_FullBackup = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ExcelTemplate = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Excel = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Files
            // 
            this.btn_Files.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Files.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Files.ImageOptions.SvgImage")));
            this.btn_Files.Location = new System.Drawing.Point(12, 12);
            this.btn_Files.Name = "btn_Files";
            this.btn_Files.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.btn_Files.Size = new System.Drawing.Size(42, 40);
            this.btn_Files.TabIndex = 0;
            this.btn_Files.Click += new System.EventHandler(this.btn_Files_Click);
            this.btn_Files.MouseHover += new System.EventHandler(this.btn_Files_MouseHover);
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 15.25F);
            this.btn_Save.Appearance.Options.UseBackColor = true;
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btn_Save.ImageOptions.SvgImage")));
            this.btn_Save.Location = new System.Drawing.Point(12, 79);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(353, 48);
            this.btn_Save.TabIndex = 4;
            this.btn_Save.Text = "J-HR\'a Aktar";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Dosya Yolu";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.richTextBox1.Location = new System.Drawing.Point(0, 297);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(1152, 213);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_TableBackup);
            this.groupBox1.Controls.Add(this.btn_FullBackup);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(620, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 178);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yedekleme";
            // 
            // btn_TableBackup
            // 
            this.btn_TableBackup.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_TableBackup.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.btn_TableBackup.Appearance.Options.UseBackColor = true;
            this.btn_TableBackup.Appearance.Options.UseFont = true;
            this.btn_TableBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TableBackup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_TableBackup.ImageOptions.Image")));
            this.btn_TableBackup.Location = new System.Drawing.Point(20, 126);
            this.btn_TableBackup.Name = "btn_TableBackup";
            this.btn_TableBackup.Size = new System.Drawing.Size(168, 46);
            this.btn_TableBackup.TabIndex = 4;
            this.btn_TableBackup.Text = "TABLO YEDEĞİ AL";
            this.btn_TableBackup.Click += new System.EventHandler(this.btn_TableBackup_Click);
            // 
            // btn_FullBackup
            // 
            this.btn_FullBackup.Appearance.BackColor = System.Drawing.Color.HotPink;
            this.btn_FullBackup.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.btn_FullBackup.Appearance.Options.UseBackColor = true;
            this.btn_FullBackup.Appearance.Options.UseFont = true;
            this.btn_FullBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_FullBackup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_FullBackup.ImageOptions.Image")));
            this.btn_FullBackup.Location = new System.Drawing.Point(20, 73);
            this.btn_FullBackup.Name = "btn_FullBackup";
            this.btn_FullBackup.Size = new System.Drawing.Size(168, 46);
            this.btn_FullBackup.TabIndex = 3;
            this.btn_FullBackup.Text = "FULL BACKUP";
            this.btn_FullBackup.Click += new System.EventHandler(this.btn_FullBackup_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 18.25F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(6, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(480, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "İŞLEM ÖNCESİ YEDEK ALMAYI UNUTMA !!";
            // 
            // btn_ExcelTemplate
            // 
            this.btn_ExcelTemplate.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btn_ExcelTemplate.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.btn_ExcelTemplate.Appearance.Options.UseBackColor = true;
            this.btn_ExcelTemplate.Appearance.Options.UseFont = true;
            this.btn_ExcelTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ExcelTemplate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ExcelTemplate.ImageOptions.Image")));
            this.btn_ExcelTemplate.Location = new System.Drawing.Point(710, 229);
            this.btn_ExcelTemplate.Name = "btn_ExcelTemplate";
            this.btn_ExcelTemplate.Size = new System.Drawing.Size(172, 44);
            this.btn_ExcelTemplate.TabIndex = 9;
            this.btn_ExcelTemplate.Text = "Örnek Excel Şablonu";
            this.btn_ExcelTemplate.Visible = false;
            // 
            // btn_Excel
            // 
            this.btn_Excel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btn_Excel.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.btn_Excel.Appearance.Options.UseBackColor = true;
            this.btn_Excel.Appearance.Options.UseFont = true;
            this.btn_Excel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Excel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Excel.ImageOptions.Image")));
            this.btn_Excel.Location = new System.Drawing.Point(888, 227);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(237, 46);
            this.btn_Excel.TabIndex = 10;
            this.btn_Excel.Text = "EXCELDEN VERİLERİ GETİR";
            this.btn_Excel.Visible = false;
            // 
            // FileAccessManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1152, 510);
            this.Controls.Add(this.btn_ExcelTemplate);
            this.Controls.Add(this.btn_Excel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.btn_Files);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("FileAccessManager.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileAccessManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "J-HR\'a Dosya Aktar";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btn_Files;
        private System.Windows.Forms.ToolTip toolTip1;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btn_TableBackup;
        private DevExpress.XtraEditors.SimpleButton btn_FullBackup;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.SimpleButton btn_ExcelTemplate;
        private DevExpress.XtraEditors.SimpleButton btn_Excel;
    }
}