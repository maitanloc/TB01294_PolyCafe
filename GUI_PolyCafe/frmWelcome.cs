using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_PolyCafe
{
    public partial class frmWelcome : Form
    {
        public frmWelcome()
        {
            InitializeComponent();
            progressBar.Style = ProgressBarStyle.Marquee;
            progressBar.MarqueeAnimationSpeed = 30;
            Task.Delay(3000).ContinueWith(t =>
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    this.Invoke(new Action(() =>
                    {
                        frmLogin login = new frmLogin();
                        login.Show();
                        this.Hide();

                    }));
                }


            });
        }

        private void frmWelcome_Load(object sender, EventArgs e)
        {

        }

        private void frmWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {

            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true; 
            }
        }
    }
}
