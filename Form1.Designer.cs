namespace OldSchoolScaler
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.blowUpPictureBox = new System.Windows.Forms.PictureBox();
            this.menuConfig = new System.Windows.Forms.MenuStrip();
            this.calibrateVoidLensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toggleStretchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.returnFocusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voidLensesPanel = new System.Windows.Forms.Panel();
            this.labelClickAmount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.mouseClicksTrackBar = new System.Windows.Forms.TrackBar();
            this.labelYOffset = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.offsetYTrackBar = new System.Windows.Forms.TrackBar();
            this.labelXOffset = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.offsetXTrackBar = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.blowUpPictureBox)).BeginInit();
            this.menuConfig.SuspendLayout();
            this.voidLensesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mouseClicksTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetYTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetXTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // blowUpPictureBox
            // 
            this.blowUpPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blowUpPictureBox.Location = new System.Drawing.Point(249, 24);
            this.blowUpPictureBox.Name = "blowUpPictureBox";
            this.blowUpPictureBox.Size = new System.Drawing.Size(928, 611);
            this.blowUpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blowUpPictureBox.TabIndex = 3;
            this.blowUpPictureBox.TabStop = false;
            this.blowUpPictureBox.Click += new System.EventHandler(this.gotCLicked);
            this.blowUpPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blowUpMouseDown);
            this.blowUpPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.blowUpMouseMove);
            this.blowUpPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.blowUpMouseUp);
            // 
            // menuConfig
            // 
            this.menuConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calibrateVoidLensesToolStripMenuItem,
            this.toggleStretchToolStripMenuItem,
            this.returnFocusToolStripMenuItem});
            this.menuConfig.Location = new System.Drawing.Point(0, 0);
            this.menuConfig.Name = "menuConfig";
            this.menuConfig.Size = new System.Drawing.Size(1418, 24);
            this.menuConfig.TabIndex = 4;
            this.menuConfig.Text = "Config Menu";
            // 
            // calibrateVoidLensesToolStripMenuItem
            // 
            this.calibrateVoidLensesToolStripMenuItem.Name = "calibrateVoidLensesToolStripMenuItem";
            this.calibrateVoidLensesToolStripMenuItem.Size = new System.Drawing.Size(131, 20);
            this.calibrateVoidLensesToolStripMenuItem.Text = "Calibrate Void Lenses";
            this.calibrateVoidLensesToolStripMenuItem.Click += new System.EventHandler(this.calibrateVoidLensesToolStripMenuItem_Click);
            // 
            // toggleStretchToolStripMenuItem
            // 
            this.toggleStretchToolStripMenuItem.Name = "toggleStretchToolStripMenuItem";
            this.toggleStretchToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.toggleStretchToolStripMenuItem.Text = "Toggle Stretch";
            this.toggleStretchToolStripMenuItem.Click += new System.EventHandler(this.toggleStretchToolStripMenuItem_Click);
            // 
            // returnFocusToolStripMenuItem
            // 
            this.returnFocusToolStripMenuItem.Name = "returnFocusToolStripMenuItem";
            this.returnFocusToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.returnFocusToolStripMenuItem.Text = "Return Focus";
            this.returnFocusToolStripMenuItem.Click += new System.EventHandler(this.returnFocusToolStripMenuItem_Click);
            // 
            // voidLensesPanel
            // 
            this.voidLensesPanel.BackColor = System.Drawing.Color.DimGray;
            this.voidLensesPanel.Controls.Add(this.labelClickAmount);
            this.voidLensesPanel.Controls.Add(this.label4);
            this.voidLensesPanel.Controls.Add(this.mouseClicksTrackBar);
            this.voidLensesPanel.Controls.Add(this.labelYOffset);
            this.voidLensesPanel.Controls.Add(this.label3);
            this.voidLensesPanel.Controls.Add(this.offsetYTrackBar);
            this.voidLensesPanel.Controls.Add(this.labelXOffset);
            this.voidLensesPanel.Controls.Add(this.label1);
            this.voidLensesPanel.Controls.Add(this.offsetXTrackBar);
            this.voidLensesPanel.Location = new System.Drawing.Point(6, 29);
            this.voidLensesPanel.Name = "voidLensesPanel";
            this.voidLensesPanel.Size = new System.Drawing.Size(330, 154);
            this.voidLensesPanel.TabIndex = 5;
            this.voidLensesPanel.Visible = false;
            // 
            // labelClickAmount
            // 
            this.labelClickAmount.AutoSize = true;
            this.labelClickAmount.Location = new System.Drawing.Point(25, 120);
            this.labelClickAmount.Name = "labelClickAmount";
            this.labelClickAmount.Size = new System.Drawing.Size(13, 13);
            this.labelClickAmount.TabIndex = 8;
            this.labelClickAmount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Clicks:";
            // 
            // mouseClicksTrackBar
            // 
            this.mouseClicksTrackBar.Location = new System.Drawing.Point(62, 103);
            this.mouseClicksTrackBar.Maximum = 5;
            this.mouseClicksTrackBar.Minimum = 1;
            this.mouseClicksTrackBar.Name = "mouseClicksTrackBar";
            this.mouseClicksTrackBar.Size = new System.Drawing.Size(265, 45);
            this.mouseClicksTrackBar.TabIndex = 6;
            this.mouseClicksTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.mouseClicksTrackBar.Value = 2;
            this.mouseClicksTrackBar.Scroll += new System.EventHandler(this.mouseClicksTrackBar_Scroll);
            // 
            // labelYOffset
            // 
            this.labelYOffset.AutoSize = true;
            this.labelYOffset.Location = new System.Drawing.Point(25, 74);
            this.labelYOffset.Name = "labelYOffset";
            this.labelYOffset.Size = new System.Drawing.Size(13, 13);
            this.labelYOffset.TabIndex = 5;
            this.labelYOffset.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y Offset: ";
            // 
            // offsetYTrackBar
            // 
            this.offsetYTrackBar.Location = new System.Drawing.Point(62, 52);
            this.offsetYTrackBar.Maximum = 50;
            this.offsetYTrackBar.Minimum = -50;
            this.offsetYTrackBar.Name = "offsetYTrackBar";
            this.offsetYTrackBar.Size = new System.Drawing.Size(265, 45);
            this.offsetYTrackBar.TabIndex = 3;
            this.offsetYTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.offsetYTrackBar.Scroll += new System.EventHandler(this.offsetYTrackBar_Scroll);
            // 
            // labelXOffset
            // 
            this.labelXOffset.AutoSize = true;
            this.labelXOffset.Location = new System.Drawing.Point(25, 28);
            this.labelXOffset.Name = "labelXOffset";
            this.labelXOffset.Size = new System.Drawing.Size(13, 13);
            this.labelXOffset.TabIndex = 2;
            this.labelXOffset.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X Offset: ";
            // 
            // offsetXTrackBar
            // 
            this.offsetXTrackBar.Location = new System.Drawing.Point(62, 6);
            this.offsetXTrackBar.Maximum = 50;
            this.offsetXTrackBar.Minimum = -50;
            this.offsetXTrackBar.Name = "offsetXTrackBar";
            this.offsetXTrackBar.Size = new System.Drawing.Size(265, 45);
            this.offsetXTrackBar.TabIndex = 0;
            this.offsetXTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.offsetXTrackBar.Scroll += new System.EventHandler(this.offsetXTrackBar_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1418, 631);
            this.Controls.Add(this.voidLensesPanel);
            this.Controls.Add(this.blowUpPictureBox);
            this.Controls.Add(this.menuConfig);
            this.MainMenuStrip = this.menuConfig;
            this.Name = "Form1";
            this.Text = "Old School Scaler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyPress);
            ((System.ComponentModel.ISupportInitialize)(this.blowUpPictureBox)).EndInit();
            this.menuConfig.ResumeLayout(false);
            this.menuConfig.PerformLayout();
            this.voidLensesPanel.ResumeLayout(false);
            this.voidLensesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mouseClicksTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetYTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetXTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox blowUpPictureBox;
        private System.Windows.Forms.MenuStrip menuConfig;
        private System.Windows.Forms.ToolStripMenuItem calibrateVoidLensesToolStripMenuItem;
        private System.Windows.Forms.Panel voidLensesPanel;
        private System.Windows.Forms.Label labelXOffset;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar offsetXTrackBar;
        private System.Windows.Forms.Label labelYOffset;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar offsetYTrackBar;
        private System.Windows.Forms.Label labelClickAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TrackBar mouseClicksTrackBar;
        private System.Windows.Forms.ToolStripMenuItem toggleStretchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem returnFocusToolStripMenuItem;

    }
}

