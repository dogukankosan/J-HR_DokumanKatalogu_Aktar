namespace J_HR.Forms
{
    partial class TitleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleForm));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_FullBackup = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ExcelTemplate = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Excel = new DevExpress.XtraEditors.SimpleButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_TableBackup = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(544, 624);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_TableBackup);
            this.groupBox1.Controls.Add(this.btn_FullBackup);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(550, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 196);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Yedekleme";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 18.25F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(6, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(480, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "İŞLEM ÖNCESİ YEDEK ALMAYI UNUTMA !!";
            // 
            // btn_ExcelTemplate
            // 
            this.btn_ExcelTemplate.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Question;
            this.btn_ExcelTemplate.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.btn_ExcelTemplate.Appearance.Options.UseBackColor = true;
            this.btn_ExcelTemplate.Appearance.Options.UseFont = true;
            this.btn_ExcelTemplate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_ExcelTemplate.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_ExcelTemplate.ImageOptions.Image")));
            this.btn_ExcelTemplate.Location = new System.Drawing.Point(550, 12);
            this.btn_ExcelTemplate.Name = "btn_ExcelTemplate";
            this.btn_ExcelTemplate.Size = new System.Drawing.Size(172, 44);
            this.btn_ExcelTemplate.TabIndex = 0;
            this.btn_ExcelTemplate.Text = "Örnek Excel Şablonu";
            this.btn_ExcelTemplate.Click += new System.EventHandler(this.btn_ExcelTemplate_Click);
            // 
            // btn_Excel
            // 
            this.btn_Excel.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Warning;
            this.btn_Excel.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.btn_Excel.Appearance.Options.UseBackColor = true;
            this.btn_Excel.Appearance.Options.UseFont = true;
            this.btn_Excel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Excel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Excel.ImageOptions.Image")));
            this.btn_Excel.Location = new System.Drawing.Point(728, 10);
            this.btn_Excel.Name = "btn_Excel";
            this.btn_Excel.Size = new System.Drawing.Size(237, 46);
            this.btn_Excel.TabIndex = 1;
            this.btn_Excel.Text = "EXCELDEN VERİLERİ GETİR";
            this.btn_Excel.Click += new System.EventHandler(this.btn_Excel_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Appearance.BackColor = System.Drawing.Color.Green;
            this.btn_Save.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.btn_Save.Appearance.Options.UseBackColor = true;
            this.btn_Save.Appearance.Options.UseFont = true;
            this.btn_Save.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Save.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Save.ImageOptions.Image")));
            this.btn_Save.Location = new System.Drawing.Point(971, 10);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(168, 46);
            this.btn_Save.TabIndex = 2;
            this.btn_Save.Text = "AKTAR";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_TableBackup
            // 
            this.btn_TableBackup.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btn_TableBackup.Appearance.Font = new System.Drawing.Font("Tahoma", 10.25F);
            this.btn_TableBackup.Appearance.Options.UseBackColor = true;
            this.btn_TableBackup.Appearance.Options.UseFont = true;
            this.btn_TableBackup.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_TableBackup.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.btn_TableBackup.Location = new System.Drawing.Point(20, 125);
            this.btn_TableBackup.Name = "btn_TableBackup";
            this.btn_TableBackup.Size = new System.Drawing.Size(168, 46);
            this.btn_TableBackup.TabIndex = 4;
            this.btn_TableBackup.Text = "TABLO YEDEĞİ AL";
            this.btn_TableBackup.Click += new System.EventHandler(this.btn_TableBackup_Click);
            // 
            // TitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1188, 624);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_ExcelTemplate);
            this.Controls.Add(this.btn_Excel);
            this.Controls.Add(this.btn_Save);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("TitleForm.IconOptions.LargeImage")));
            this.MaximizeBox = false;
            this.Name = "TitleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Görev Yeri Aktarımı";
            this.Load += new System.EventHandler(this.TitleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btn_FullBackup;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btn_ExcelTemplate;
        private DevExpress.XtraEditors.SimpleButton btn_Excel;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
        private DevExpress.XtraEditors.SimpleButton btn_TableBackup;
    }
}