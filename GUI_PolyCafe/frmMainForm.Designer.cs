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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMainForm));
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            menuStrip1 = new MenuStrip();
            hethongToolStripMenuItem = new ToolStripMenuItem();
            đổiMậtKhẩuToolStripMenuItem = new ToolStripMenuItem();
            dangxuatToolStripMenuItem = new ToolStripMenuItem();
            thongtintaikhoanToolStripMenuItem = new ToolStripMenuItem();
            thoatToolStripMenuItem = new ToolStripMenuItem();
            danhmucToolStripMenuItem = new ToolStripMenuItem();
            quảnLýSảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            quảnLýLoạiSảnPhẩmToolStripMenuItem = new ToolStripMenuItem();
            banhangToolStripMenuItem = new ToolStripMenuItem();
            nhanvienToolStripMenuItem = new ToolStripMenuItem();
            doanhthuToolStripMenuItem = new ToolStripMenuItem();
            thốngKêToolStripMenuItem = new ToolStripMenuItem();
            huongdanToolStripMenuItem = new ToolStripMenuItem();
            pnMain = new Panel();
            imageList1 = new ImageList(components);
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { hethongToolStripMenuItem, danhmucToolStripMenuItem, banhangToolStripMenuItem, nhanvienToolStripMenuItem, doanhthuToolStripMenuItem, huongdanToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1337, 28);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // hethongToolStripMenuItem
            // 
            hethongToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { đổiMậtKhẩuToolStripMenuItem, dangxuatToolStripMenuItem, thongtintaikhoanToolStripMenuItem, thoatToolStripMenuItem });
            hethongToolStripMenuItem.Name = "hethongToolStripMenuItem";
            hethongToolStripMenuItem.Size = new Size(88, 24);
            hethongToolStripMenuItem.Text = "Hệ Thống";
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            đổiMậtKhẩuToolStripMenuItem.Size = new Size(226, 26);
            đổiMậtKhẩuToolStripMenuItem.Text = "Đổi Mật Khẩu";
            đổiMậtKhẩuToolStripMenuItem.Click += đổiMậtKhẩuToolStripMenuItem_Click;
            // 
            // dangxuatToolStripMenuItem
            // 
            dangxuatToolStripMenuItem.Name = "dangxuatToolStripMenuItem";
            dangxuatToolStripMenuItem.Size = new Size(226, 26);
            dangxuatToolStripMenuItem.Text = "Đăng Xuất";
            // 
            // thongtintaikhoanToolStripMenuItem
            // 
            thongtintaikhoanToolStripMenuItem.Name = "thongtintaikhoanToolStripMenuItem";
            thongtintaikhoanToolStripMenuItem.Size = new Size(226, 26);
            thongtintaikhoanToolStripMenuItem.Text = "Thông Tin Tài Khoàn";
            // 
            // thoatToolStripMenuItem
            // 
            thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            thoatToolStripMenuItem.Size = new Size(226, 26);
            thoatToolStripMenuItem.Text = "Thoát";
            // 
            // danhmucToolStripMenuItem
            // 
            danhmucToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { quảnLýSảnPhẩmToolStripMenuItem, quảnLýLoạiSảnPhẩmToolStripMenuItem });
            danhmucToolStripMenuItem.Name = "danhmucToolStripMenuItem";
            danhmucToolStripMenuItem.Size = new Size(90, 24);
            danhmucToolStripMenuItem.Text = "Danh Mục";
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
            // banhangToolStripMenuItem
            // 
            banhangToolStripMenuItem.Name = "banhangToolStripMenuItem";
            banhangToolStripMenuItem.Size = new Size(88, 24);
            banhangToolStripMenuItem.Text = "Bán Hàng";
            banhangToolStripMenuItem.Click += banhangToolStripMenuItem_Click;
            // 
            // nhanvienToolStripMenuItem
            // 
            nhanvienToolStripMenuItem.Name = "nhanvienToolStripMenuItem";
            nhanvienToolStripMenuItem.Size = new Size(91, 24);
            nhanvienToolStripMenuItem.Text = "Nhân Viên";
            nhanvienToolStripMenuItem.Click += nhânViênToolStripMenuItem_Click;
            // 
            // doanhthuToolStripMenuItem
            // 
            doanhthuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { thốngKêToolStripMenuItem });
            doanhthuToolStripMenuItem.Name = "doanhthuToolStripMenuItem";
            doanhthuToolStripMenuItem.Size = new Size(95, 24);
            doanhthuToolStripMenuItem.Text = "Doanh Thu";
            // 
            // thốngKêToolStripMenuItem
            // 
            thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            thốngKêToolStripMenuItem.Size = new Size(153, 26);
            thốngKêToolStripMenuItem.Text = "Thống kê";
            // 
            // huongdanToolStripMenuItem
            // 
            huongdanToolStripMenuItem.Name = "huongdanToolStripMenuItem";
            huongdanToolStripMenuItem.Size = new Size(100, 24);
            huongdanToolStripMenuItem.Text = "Hướng Dẫn";
            // 
            // pnMain
            // 
            pnMain.BackColor = Color.Transparent;
            pnMain.Location = new Point(3, 31);
            pnMain.Name = "pnMain";
            pnMain.Size = new Size(1334, 632);
            pnMain.TabIndex = 10;
            pnMain.Paint += pnMain_Paint;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "coffee-cup.png");
            // 
            // frmMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1337, 677);
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
        private ToolStripMenuItem hethongToolStripMenuItem;
        private ToolStripMenuItem danhmucToolStripMenuItem;
        private ToolStripMenuItem banhangToolStripMenuItem;
        private ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private ToolStripMenuItem dangxuatToolStripMenuItem;
        private ToolStripMenuItem nhanvienToolStripMenuItem;
        private ToolStripMenuItem doanhthuToolStripMenuItem;
        private ToolStripMenuItem huongdanToolStripMenuItem;
        private ToolStripMenuItem thongtintaikhoanToolStripMenuItem;
        private ToolStripMenuItem thoatToolStripMenuItem;
        private ToolStripMenuItem quảnLýSảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem quảnLýLoạiSảnPhẩmToolStripMenuItem;
        private ToolStripMenuItem thốngKêToolStripMenuItem;
        private Panel pnMain;
        private ImageList imageList1;
    }
}