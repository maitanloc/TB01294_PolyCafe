namespace GUI_PolyCafe
{
    partial class frmWelcome
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
            progressBar = new ProgressBar();
            SuspendLayout();
            // 
            // progressBar
            // 
            progressBar.Location = new Point(-6, 590);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(1084, 29);
            progressBar.TabIndex = 0;
            // 
            // frmWelcome
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Brown_Beige_Cream_Modern_Illustration_Coffee_Project_Presentation;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1078, 614);
            Controls.Add(progressBar);
            DoubleBuffered = true;
            Name = "frmWelcome";
            Text = "frmWelcome";
            FormClosing += frmWelcome_FormClosing;
            Load += frmWelcome_Load;
            ResumeLayout(false);
        }

        #endregion

        private ProgressBar progressBar;
    }
}