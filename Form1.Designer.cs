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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
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
            this.panelToggleBox = new System.Windows.Forms.PictureBox();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.loadWorldButton = new System.Windows.Forms.Button();
            this.calibratePictureBox = new System.Windows.Forms.PictureBox();
            this.worldComboBox = new System.Windows.Forms.ComboBox();
            this.resizePictureBox = new System.Windows.Forms.PictureBox();
            this.blowUpPictureBox = new System.Windows.Forms.PictureBox();
            this.voidLensesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mouseClicksTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetYTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetXTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelToggleBox)).BeginInit();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.calibratePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blowUpPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // voidLensesPanel
            // 
            this.voidLensesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.voidLensesPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.voidLensesPanel.Controls.Add(this.labelClickAmount);
            this.voidLensesPanel.Controls.Add(this.label4);
            this.voidLensesPanel.Controls.Add(this.mouseClicksTrackBar);
            this.voidLensesPanel.Controls.Add(this.labelYOffset);
            this.voidLensesPanel.Controls.Add(this.label3);
            this.voidLensesPanel.Controls.Add(this.offsetYTrackBar);
            this.voidLensesPanel.Controls.Add(this.labelXOffset);
            this.voidLensesPanel.Controls.Add(this.label1);
            this.voidLensesPanel.Controls.Add(this.offsetXTrackBar);
            this.voidLensesPanel.Location = new System.Drawing.Point(51, 50);
            this.voidLensesPanel.Name = "voidLensesPanel";
            this.voidLensesPanel.Size = new System.Drawing.Size(330, 154);
            this.voidLensesPanel.TabIndex = 5;
            this.voidLensesPanel.Visible = false;
            // 
            // labelClickAmount
            // 
            this.labelClickAmount.AutoSize = true;
            this.labelClickAmount.BackColor = System.Drawing.Color.Transparent;
            this.labelClickAmount.ForeColor = System.Drawing.Color.White;
            this.labelClickAmount.Location = new System.Drawing.Point(25, 120);
            this.labelClickAmount.Name = "labelClickAmount";
            this.labelClickAmount.Size = new System.Drawing.Size(13, 13);
            this.labelClickAmount.TabIndex = 8;
            this.labelClickAmount.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(20, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Clicks:";
            // 
            // mouseClicksTrackBar
            // 
            this.mouseClicksTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.mouseClicksTrackBar.Location = new System.Drawing.Point(62, 103);
            this.mouseClicksTrackBar.Maximum = 5;
            this.mouseClicksTrackBar.Minimum = 1;
            this.mouseClicksTrackBar.Name = "mouseClicksTrackBar";
            this.mouseClicksTrackBar.Size = new System.Drawing.Size(265, 45);
            this.mouseClicksTrackBar.TabIndex = 6;
            this.mouseClicksTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.mouseClicksTrackBar.Value = 1;
            this.mouseClicksTrackBar.Scroll += new System.EventHandler(this.mouseClicksTrackBar_Scroll);
            // 
            // labelYOffset
            // 
            this.labelYOffset.AutoSize = true;
            this.labelYOffset.BackColor = System.Drawing.Color.Transparent;
            this.labelYOffset.ForeColor = System.Drawing.Color.White;
            this.labelYOffset.Location = new System.Drawing.Point(25, 74);
            this.labelYOffset.Name = "labelYOffset";
            this.labelYOffset.Size = new System.Drawing.Size(13, 13);
            this.labelYOffset.TabIndex = 5;
            this.labelYOffset.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(10, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Y Offset: ";
            // 
            // offsetYTrackBar
            // 
            this.offsetYTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
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
            this.labelXOffset.BackColor = System.Drawing.Color.Transparent;
            this.labelXOffset.ForeColor = System.Drawing.Color.White;
            this.labelXOffset.Location = new System.Drawing.Point(25, 28);
            this.labelXOffset.Name = "labelXOffset";
            this.labelXOffset.Size = new System.Drawing.Size(13, 13);
            this.labelXOffset.TabIndex = 2;
            this.labelXOffset.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(10, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "X Offset: ";
            // 
            // offsetXTrackBar
            // 
            this.offsetXTrackBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(46)))));
            this.offsetXTrackBar.Location = new System.Drawing.Point(62, 6);
            this.offsetXTrackBar.Maximum = 50;
            this.offsetXTrackBar.Minimum = -50;
            this.offsetXTrackBar.Name = "offsetXTrackBar";
            this.offsetXTrackBar.Size = new System.Drawing.Size(265, 45);
            this.offsetXTrackBar.TabIndex = 0;
            this.offsetXTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.offsetXTrackBar.Scroll += new System.EventHandler(this.offsetXTrackBar_Scroll);
            // 
            // panelToggleBox
            // 
            this.panelToggleBox.BackColor = System.Drawing.Color.Transparent;
            this.panelToggleBox.BackgroundImage = global::OldSchoolScaler.Properties.Resources.panelToggle;
            this.panelToggleBox.Location = new System.Drawing.Point(3, 50);
            this.panelToggleBox.Name = "panelToggleBox";
            this.panelToggleBox.Size = new System.Drawing.Size(50, 25);
            this.panelToggleBox.TabIndex = 9;
            this.panelToggleBox.TabStop = false;
            this.panelToggleBox.Click += new System.EventHandler(this.panelToggleBox_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.DimGray;
            this.menuPanel.BackgroundImage = global::OldSchoolScaler.Properties.Resources.menuPanel;
            this.menuPanel.Controls.Add(this.loadWorldButton);
            this.menuPanel.Controls.Add(this.calibratePictureBox);
            this.menuPanel.Controls.Add(this.worldComboBox);
            this.menuPanel.Controls.Add(this.resizePictureBox);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(1418, 50);
            this.menuPanel.TabIndex = 8;
            // 
            // loadWorldButton
            // 
            this.loadWorldButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loadWorldButton.Location = new System.Drawing.Point(1338, 26);
            this.loadWorldButton.Name = "loadWorldButton";
            this.loadWorldButton.Size = new System.Drawing.Size(75, 20);
            this.loadWorldButton.TabIndex = 7;
            this.loadWorldButton.Text = "Load World";
            this.loadWorldButton.UseVisualStyleBackColor = true;
            this.loadWorldButton.Click += new System.EventHandler(this.loadWorldButton_Click);
            // 
            // calibratePictureBox
            // 
            this.calibratePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.calibratePictureBox.Image = global::OldSchoolScaler.Properties.Resources.calibrateMouse;
            this.calibratePictureBox.Location = new System.Drawing.Point(51, 5);
            this.calibratePictureBox.Name = "calibratePictureBox";
            this.calibratePictureBox.Size = new System.Drawing.Size(40, 40);
            this.calibratePictureBox.TabIndex = 1;
            this.calibratePictureBox.TabStop = false;
            this.calibratePictureBox.Click += new System.EventHandler(this.calibratePictureBox_Click);
            // 
            // worldComboBox
            // 
            this.worldComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.worldComboBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.worldComboBox.FormattingEnabled = true;
            this.worldComboBox.ItemHeight = 16;
            this.worldComboBox.Location = new System.Drawing.Point(1338, 3);
            this.worldComboBox.MaxDropDownItems = 4;
            this.worldComboBox.Name = "worldComboBox";
            this.worldComboBox.Size = new System.Drawing.Size(75, 24);
            this.worldComboBox.TabIndex = 6;
            // 
            // resizePictureBox
            // 
            this.resizePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.resizePictureBox.Image = global::OldSchoolScaler.Properties.Resources.resizeButton;
            this.resizePictureBox.Location = new System.Drawing.Point(5, 5);
            this.resizePictureBox.Name = "resizePictureBox";
            this.resizePictureBox.Size = new System.Drawing.Size(40, 40);
            this.resizePictureBox.TabIndex = 0;
            this.resizePictureBox.TabStop = false;
            this.resizePictureBox.Click += new System.EventHandler(this.resizePictureBox_Click);
            // 
            // blowUpPictureBox
            // 
            this.blowUpPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blowUpPictureBox.Location = new System.Drawing.Point(249, 51);
            this.blowUpPictureBox.Name = "blowUpPictureBox";
            this.blowUpPictureBox.Size = new System.Drawing.Size(928, 611);
            this.blowUpPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blowUpPictureBox.TabIndex = 3;
            this.blowUpPictureBox.TabStop = false;
            this.blowUpPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.blowUpMouseDown);
            this.blowUpPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.blowUpMouseMove);
            this.blowUpPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.blowUpMouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(1418, 656);
            this.Controls.Add(this.voidLensesPanel);
            this.Controls.Add(this.panelToggleBox);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.blowUpPictureBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.Text = "Old School Scaler";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.programEnding);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyPressUp);
            this.Resize += new System.EventHandler(this.onFormResize);
            this.voidLensesPanel.ResumeLayout(false);
            this.voidLensesPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mouseClicksTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetYTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetXTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelToggleBox)).EndInit();
            this.menuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.calibratePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resizePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blowUpPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox blowUpPictureBox;
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
        private System.Windows.Forms.ComboBox worldComboBox;
        private System.Windows.Forms.Button loadWorldButton;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.PictureBox resizePictureBox;
        private System.Windows.Forms.PictureBox calibratePictureBox;
        private System.Windows.Forms.PictureBox panelToggleBox;

    }
}

