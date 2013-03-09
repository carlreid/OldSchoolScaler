namespace OldSchoolScaler
{
    partial class ClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.clientBrowser = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // clientBrowser
            // 
            this.clientBrowser.IsWebBrowserContextMenuEnabled = false;
            this.clientBrowser.Location = new System.Drawing.Point(0, 0);
            this.clientBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.clientBrowser.Name = "clientBrowser";
            this.clientBrowser.ScrollBarsEnabled = false;
            this.clientBrowser.Size = new System.Drawing.Size(785, 535);
            this.clientBrowser.TabIndex = 3;
            this.clientBrowser.Url = new System.Uri("", System.UriKind.Relative);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 536);
            this.Controls.Add(this.clientBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(801, 575);
            this.MinimumSize = new System.Drawing.Size(801, 575);
            this.Name = "ClientForm";
            this.Text = "Client Window";
            this.Activated += new System.EventHandler(this.gotFocus);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.gettingClosed);
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.WebBrowser clientBrowser;

    }
}