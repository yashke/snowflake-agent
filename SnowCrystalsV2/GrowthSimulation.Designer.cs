namespace SnowCrystals
{
    partial class GrowthSimulation
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
            this.densityBar = new System.Windows.Forms.TrackBar();
            this.densityLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.currentDensityTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currentSpeedTB = new System.Windows.Forms.TextBox();
            this.mainPanel = new System.Windows.Forms.PictureBox();
            this.EventLabel = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.densityBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // densityBar
            // 
            this.densityBar.Location = new System.Drawing.Point(64, 382);
            this.densityBar.Maximum = 20;
            this.densityBar.Name = "densityBar";
            this.densityBar.Size = new System.Drawing.Size(528, 45);
            this.densityBar.TabIndex = 0;
            this.densityBar.ValueChanged += new System.EventHandler(this.densityBar_ValueChanged);
            // 
            // densityLabel
            // 
            this.densityLabel.AutoSize = true;
            this.densityLabel.Location = new System.Drawing.Point(22, 382);
            this.densityLabel.Name = "densityLabel";
            this.densityLabel.Size = new System.Drawing.Size(45, 13);
            this.densityLabel.TabIndex = 1;
            this.densityLabel.Text = "Density:";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(-3, 435);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(70, 13);
            this.speedLabel.TabIndex = 2;
            this.speedLabel.Text = "Temperature:";
            // 
            // speedBar
            // 
            this.speedBar.Location = new System.Drawing.Point(64, 435);
            this.speedBar.Maximum = 20;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(528, 45);
            this.speedBar.TabIndex = 3;
            this.speedBar.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 487);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Current density:";
            // 
            // currentDensityTB
            // 
            this.currentDensityTB.Location = new System.Drawing.Point(169, 484);
            this.currentDensityTB.Name = "currentDensityTB";
            this.currentDensityTB.Size = new System.Drawing.Size(44, 20);
            this.currentDensityTB.TabIndex = 5;
            this.currentDensityTB.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 487);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Currrent temp:";
            // 
            // currentSpeedTB
            // 
            this.currentSpeedTB.Location = new System.Drawing.Point(345, 484);
            this.currentSpeedTB.Name = "currentSpeedTB";
            this.currentSpeedTB.Size = new System.Drawing.Size(44, 20);
            this.currentSpeedTB.TabIndex = 7;
            this.currentSpeedTB.Text = "0";
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(0, 12);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(592, 364);
            this.mainPanel.TabIndex = 8;
            this.mainPanel.TabStop = false;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // EventLabel
            // 
            this.EventLabel.AutoSize = true;
            this.EventLabel.Location = new System.Drawing.Point(500, 491);
            this.EventLabel.Name = "EventLabel";
            this.EventLabel.Size = new System.Drawing.Size(0, 13);
            this.EventLabel.TabIndex = 9;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(448, 22);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 13);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Status:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // GrowthSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 519);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.EventLabel);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.currentSpeedTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentDensityTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedBar);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.densityLabel);
            this.Controls.Add(this.densityBar);
            this.Name = "GrowthSimulation";
            this.Text = "GrowthSimulation";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GrowthSimulation_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.densityBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar densityBar;
        private System.Windows.Forms.Label densityLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentDensityTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox currentSpeedTB;
        private System.Windows.Forms.PictureBox mainPanel;
        private System.Windows.Forms.Label EventLabel;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer timer1;
    }
}