namespace GUI_PolyCafe
{
    partial class frmMainForm
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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            menuStrip1 = new MenuStrip();
            hệThốngToolStripMenuItem = new ToolStripMenuItem();
            đổiMậtKhẩuToolStripMenuItem = new ToolStripMenuItem();
            đăngXuấtToolStripMenuItem = new ToolStripMenuItem();
            thôngTinTàiKhoànToolStripMenuItem = new ToolStripMenuItem();
            thoátToolStripMenuItem = new ToolStripMenuItem();
            danhMụcToolStripMenuItem = new ToolStripMenuItem();
            quảnLýSảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            quảnLýLoạiSảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            bánHàngToolStripMenuItem = new ToolStripMenuItem();
            nhânViênToolStripMenuItem = new ToolStripMenuItem();
            doanhThuToolStripMenuItem = new ToolStripMenuItem();
            thốngKêToolStripMenuItem = new ToolStripMenuItem();
            hướngDẫnToolStripMenuItem = new ToolStripMenuItem();
            pnMain = new Panel();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hệThốngToolStripMenuItem, danhMụcToolStripMenuItem, bánHàngToolStripMenuItem, nhânViênToolStripMenuItem, doanhThuToolStripMenuItem, hướngDẫnToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1127, 28);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // hệThốngToolStripMenuItem
            // 
            hệThốngToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đổiMậtKhẩuToolStripMenuItem, đăngXuấtToolStripMenuItem, thôngTinTàiKhoànToolStripMenuItem, thoátToolStripMenuItem });
            hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            hệThốngToolStripMenuItem.Size = new Size(88, 24);
            hệThốngToolStripMenuItem.Text = "Hệ Thống";
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            đổiMậtKhẩuToolStripMenuItem.Size = new Size(226, 26);
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi Mật Khẩu";
            đổiMậtKhẩuToolStripMenuItem.Click += đổiMậtKhẩuToolStripMenuItem_Click;
            // 
            // đăngXuấtToolStripMenuItem
            // 
            đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            đăngXuấtToolStripMenuItem.Size = new Size(226, 26);
            đăngXuấtToolStripMenuItem.Text = "Đăng Xuất";
            // 
            // thôngTinTàiKhoànToolStripMenuItem
            // 
            thôngTinTàiKhoànToolStripMenuItem.Name = "thôngTinTàiKhoànToolStripMenuItem";
            thôngTinTàiKhoànToolStripMenuItem.Size = new Size(226, 26);
            thôngTinTàiKhoànToolStripMenuItem.Text = "Thông Tin Tài Khoàn";
            // 
            // thoátToolStripMenuItem
            // 
            thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            thoátToolStripMenuItem.Size = new Size(226, 26);
            thoátToolStripMenuItem.Text = "Thoát";
            // 
            // danhMụcToolStripMenuItem
            // 
            danhMụcToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { quảnLýSảnPhẩmToolStripMenuItem, quảnLýLoạiSảnPhẩmToolStripMenuItem });
            danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            danhMụcToolStripMenuItem.Size = new Size(90, 24);
            danhMụcToolStripMenuItem.Text = "Danh Mục";
            // 
            // quảnLýSảnPhẩmToolStripMenuItem
            // 
            quảnLýSảnPhẩmToolStripMenuItem.Name = "quảnLýSảnPhẩmToolStripMenuItem";
            quảnLýSảnPhẩmToolStripMenuItem.Size = new Size(245, 26);
            quảnLýSảnPhẩmToolStripMenuItem.Text = "Quản Lý Sản Phẩm";
            // 
            // quảnLýLoạiSảnPhẩmToolStripMenuItem
            // 
            quảnLýLoạiSảnPhẩmToolStripMenuItem.Name = "quảnLýLoạiSảnPhẩmToolStripMenuItem";
            quảnLýLoạiSảnPhẩmToolStripMenuItem.Size = new Size(245, 26);
            quảnLýLoạiSảnPhẩmToolStripMenuItem.Text = "Quản Lý Loại Sản Phẩm";
            // 
            // bánHàngToolStripMenuItem
            // 
            bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            bánHàngToolStripMenuItem.Size = new Size(88, 24);
            bánHàngToolStripMenuItem.Text = "Bán Hàng";
            // 
            // nhânViênToolStripMenuItem
            // 
            nhânViênToolStripMenuItem.Name = "nhânViênToolStripMenuItem";
            nhânViênToolStripMenuItem.Size = new Size(91, 24);
            nhânViênToolStripMenuItem.Text = "Nhân Viên";
            nhânViênToolStripMenuItem.Click += nhânViênToolStripMenuItem_Click;
            // 
            // doanhThuToolStripMenuItem
            // 
            doanhThuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thốngKêToolStripMenuItem });
            doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            doanhThuToolStripMenuItem.Size = new Size(95, 24);
            doanhThuToolStripMenuItem.Text = "Doanh Thu";
            // 
            // thốngKêToolStripMenuItem
            // 
            thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            thốngKêToolStripMenuItem.Size = new Size(153, 26);
            thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // hướngDẫnToolStripMenuItem
            // 
            hướngDẫnToolStripMenuItem.Name = "hướngDẫnToolStripMenuItem";
            hướngDẫnToolStripMenuItem.Size = new Size(100, 24);
            hướngDẫnToolStripMenuItem.Text = "Hướng Dẫn";
            // 
            // pnMain
            // 
            pnMain.Location = new Point(0, 535);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(1134, 54);
            pnMain.TabIndex = 10;
            pnMain.Paint += pnMain_Paint;
            // 
            // frmMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Beige_and_Brown_Minimalist_Coffee_Shop_Video;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1127, 588);
            Controls.Add(pnMain);
            Controls.Add(menuStrip1);
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            Name = "frmMainForm";
            Text = "frmMainForm";
            Load += frmMainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem hệThốngToolStripMenuItem;
        private ToolStripMenuItem danhMụcToolStripMenuItem;
        private ToolStripMenuItem bánHàngToolStripMenuItem;
        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem nhânViênToolStripMenuItem;
        private ToolStripMenuItem doanhThuToolStripMenuItem;
        private ToolStripMenuItem hướngDẫnToolStripMenuItem;
        private ToolStripMenuItem thôngTinTàiKhoànToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem quảnLýLoạiSảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem thốngKêToolStripMenuItem;
        private Panel pnMain;
    }
}