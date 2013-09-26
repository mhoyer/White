namespace TestStack.White.WebBrowser.SimpleBrowser
{
    partial class MainWindow
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
            this.browser = new System.Windows.Forms.WebBrowser();
            this.addressBar = new System.Windows.Forms.Panel();
            this.locationBar = new System.Windows.Forms.TextBox();
            this.mainContent = new System.Windows.Forms.Panel();
            this.addressBar.SuspendLayout();
            this.mainContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // browser
            // 
            this.browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.browser.Location = new System.Drawing.Point(0, 35);
            this.browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(784, 527);
            this.browser.TabIndex = 0;
            this.browser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // addressBar
            // 
            this.addressBar.Controls.Add(this.locationBar);
            this.addressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.addressBar.Location = new System.Drawing.Point(0, 0);
            this.addressBar.Name = "addressBar";
            this.addressBar.Padding = new System.Windows.Forms.Padding(3);
            this.addressBar.Size = new System.Drawing.Size(784, 35);
            this.addressBar.TabIndex = 1;
            // 
            // locationBar
            // 
            this.locationBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.locationBar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.locationBar.Location = new System.Drawing.Point(3, 3);
            this.locationBar.Name = "locationBar";
            this.locationBar.Size = new System.Drawing.Size(778, 29);
            this.locationBar.TabIndex = 1;
            this.locationBar.Text = "about:blank";
            this.locationBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LocationBar_KeyPress);
            // 
            // mainContent
            // 
            this.mainContent.Controls.Add(this.browser);
            this.mainContent.Controls.Add(this.addressBar);
            this.mainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContent.Location = new System.Drawing.Point(0, 0);
            this.mainContent.Name = "mainContent";
            this.mainContent.Size = new System.Drawing.Size(784, 562);
            this.mainContent.TabIndex = 0;
            // 
            // MainWindow
            // 
            this.ClientSize = new System.Drawing.Size(784, 562);
            this.Controls.Add(this.mainContent);
            this.Name = "MainWindow";
            this.Text = "SimpleBrowser";
            this.addressBar.ResumeLayout(false);
            this.addressBar.PerformLayout();
            this.mainContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser browser;
        private System.Windows.Forms.Panel addressBar;
        private System.Windows.Forms.TextBox locationBar;
        private System.Windows.Forms.Panel mainContent;
    }
}

