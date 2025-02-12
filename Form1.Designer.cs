namespace J_HR
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.menu_FileAccess = new DevExpress.XtraBars.BarButtonItem();
            this.menu_SQLConnection = new DevExpress.XtraBars.BarButtonItem();
            this.bar_Personpermission = new DevExpress.XtraBars.BarButtonItem();
            this.bar_blood = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Title = new DevExpress.XtraBars.BarButtonItem();
            this.btn_TableChange = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Position = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Exit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Minize = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Place = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Job = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.btn_Contact = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup8 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup9 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup10 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.ribbonControl1.SearchEditItem,
            this.menu_FileAccess,
            this.menu_SQLConnection,
            this.bar_Personpermission,
            this.bar_blood,
            this.btn_Title,
            this.btn_TableChange,
            this.btn_Position,
            this.btn_Exit,
            this.barButtonItem3,
            this.btn_Minize,
            this.btn_Place,
            this.btn_Job,
            this.barButtonItem2,
            this.btn_Contact});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 15;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.PageHeaderItemLinks.Add(this.btn_Minize);
            this.ribbonControl1.PageHeaderItemLinks.Add(this.btn_Exit);
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1,
            this.ribbonPage2});
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.barButtonItem2);
            this.ribbonControl1.Size = new System.Drawing.Size(1133, 150);
            // 
            // menu_FileAccess
            // 
            this.menu_FileAccess.Caption = "Döküman Kataloğu Aktar";
            this.menu_FileAccess.Id = 1;
            this.menu_FileAccess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menu_FileAccess.ImageOptions.Image")));
            this.menu_FileAccess.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("menu_FileAccess.ImageOptions.LargeImage")));
            this.menu_FileAccess.Name = "menu_FileAccess";
            this.menu_FileAccess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menu_FileAccess_ItemClick);
            // 
            // menu_SQLConnection
            // 
            this.menu_SQLConnection.Caption = "SQL Bağlantı Ayarları";
            this.menu_SQLConnection.Id = 2;
            this.menu_SQLConnection.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menu_SQLConnection.ImageOptions.Image")));
            this.menu_SQLConnection.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("menu_SQLConnection.ImageOptions.LargeImage")));
            this.menu_SQLConnection.Name = "menu_SQLConnection";
            this.menu_SQLConnection.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.menu_SQLConnection_ItemClick);
            // 
            // bar_Personpermission
            // 
            this.bar_Personpermission.Caption = "İzin Aktarımı";
            this.bar_Personpermission.Id = 3;
            this.bar_Personpermission.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_Personpermission.ImageOptions.Image")));
            this.bar_Personpermission.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_Personpermission.ImageOptions.LargeImage")));
            this.bar_Personpermission.Name = "bar_Personpermission";
            this.bar_Personpermission.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_Personpermission_ItemClick);
            // 
            // bar_blood
            // 
            this.bar_blood.Caption = "Nüfus Bilgileri Aktarımı";
            this.bar_blood.Id = 4;
            this.bar_blood.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bar_blood.ImageOptions.Image")));
            this.bar_blood.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("bar_blood.ImageOptions.LargeImage")));
            this.bar_blood.Name = "bar_blood";
            this.bar_blood.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bar_blood_ItemClick);
            // 
            // btn_Title
            // 
            this.btn_Title.Caption = "Ünvan Aktarımı";
            this.btn_Title.Id = 5;
            this.btn_Title.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Title.ImageOptions.Image")));
            this.btn_Title.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Title.ImageOptions.LargeImage")));
            this.btn_Title.Name = "btn_Title";
            this.btn_Title.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Title_ItemClick);
            // 
            // btn_TableChange
            // 
            this.btn_TableChange.Caption = "Toplu Tablo Dönem Değiştir";
            this.btn_TableChange.Id = 6;
            this.btn_TableChange.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_TableChange.ImageOptions.Image")));
            this.btn_TableChange.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_TableChange.ImageOptions.LargeImage")));
            this.btn_TableChange.Name = "btn_TableChange";
            this.btn_TableChange.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_TableChange_ItemClick);
            // 
            // btn_Position
            // 
            this.btn_Position.Caption = "Pozisyon Aktarımı";
            this.btn_Position.Id = 7;
            this.btn_Position.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Position.ImageOptions.Image")));
            this.btn_Position.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Position.ImageOptions.LargeImage")));
            this.btn_Position.Name = "btn_Position";
            this.btn_Position.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Position_ItemClick);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Caption = "Programı Kapat";
            this.btn_Exit.Id = 8;
            this.btn_Exit.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Exit.ImageOptions.Image")));
            this.btn_Exit.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Exit.ImageOptions.LargeImage")));
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Exit_ItemClick);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Alt Sekmeye Al";
            this.barButtonItem3.Id = 9;
            this.barButtonItem3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.Image")));
            this.barButtonItem3.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem3.ImageOptions.LargeImage")));
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // btn_Minize
            // 
            this.btn_Minize.Caption = "Alt Sekmeye Al";
            this.btn_Minize.Id = 10;
            this.btn_Minize.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Minize.ImageOptions.Image")));
            this.btn_Minize.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Minize.ImageOptions.LargeImage")));
            this.btn_Minize.Name = "btn_Minize";
            this.btn_Minize.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Minize_ItemClick);
            // 
            // btn_Place
            // 
            this.btn_Place.Caption = "Görev Yeri Aktarımı";
            this.btn_Place.Id = 11;
            this.btn_Place.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Place.ImageOptions.Image")));
            this.btn_Place.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Place.ImageOptions.LargeImage")));
            this.btn_Place.Name = "btn_Place";
            this.btn_Place.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Place_ItemClick);
            // 
            // btn_Job
            // 
            this.btn_Job.Caption = "Meslek Kodu Aktarım";
            this.btn_Job.Id = 12;
            this.btn_Job.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Job.ImageOptions.Image")));
            this.btn_Job.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Job.ImageOptions.LargeImage")));
            this.btn_Job.Name = "btn_Job";
            this.btn_Job.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Job_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Enabled = false;
            this.barButtonItem2.Id = 13;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // btn_Contact
            // 
            this.btn_Contact.Caption = "İletişim Bilgileri Aktar";
            this.btn_Contact.Id = 14;
            this.btn_Contact.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btn_Contact.ImageOptions.Image")));
            this.btn_Contact.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btn_Contact.ImageOptions.LargeImage")));
            this.btn_Contact.Name = "btn_Contact";
            this.btn_Contact.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btn_Contact_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup4,
            this.ribbonPageGroup5,
            this.ribbonPageGroup7,
            this.ribbonPageGroup8,
            this.ribbonPageGroup9,
            this.ribbonPageGroup10});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "İşlemler";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.menu_FileAccess);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.bar_Personpermission);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.bar_blood);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.btn_Title);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.btn_Position);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            // 
            // ribbonPageGroup8
            // 
            this.ribbonPageGroup8.ItemLinks.Add(this.btn_Place);
            this.ribbonPageGroup8.Name = "ribbonPageGroup8";
            // 
            // ribbonPageGroup9
            // 
            this.ribbonPageGroup9.ItemLinks.Add(this.btn_Job);
            this.ribbonPageGroup9.Name = "ribbonPageGroup9";
            // 
            // ribbonPageGroup10
            // 
            this.ribbonPageGroup10.ItemLinks.Add(this.btn_Contact);
            this.ribbonPageGroup10.Name = "ribbonPageGroup10";
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup2,
            this.ribbonPageGroup6});
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "Ayarlar";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.menu_SQLConnection);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.btn_TableChange);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1133, 611);
            this.Controls.Add(this.ribbonControl1);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("Form1.IconOptions.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asyen Bilişim J-HR Veri Aktarımı V1.3.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem menu_FileAccess;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarButtonItem menu_SQLConnection;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarButtonItem bar_Personpermission;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bar_blood;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraBars.BarButtonItem btn_Title;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.BarButtonItem btn_TableChange;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarButtonItem btn_Position;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraBars.BarButtonItem btn_Exit;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem btn_Minize;
        private DevExpress.XtraBars.BarButtonItem btn_Place;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup8;
        private DevExpress.XtraBars.BarButtonItem btn_Job;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem btn_Contact;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup10;
    }
}

