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
            this.panel1 = new System.Windows.Forms.Panel();
            this.densityBar = new System.Windows.Forms.TrackBar();
            this.densityLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.currentDensityTB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.currentSpeedTB = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.densityBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(592, 376);
            this.panel1.TabIndex = 0;
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
            // GrowthSimulation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 519);
            this.Controls.Add(this.currentSpeedTB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentDensityTB);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.speedBar);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.densityLabel);
            this.Controls.Add(this.densityBar);
            this.Controls.Add(this.panel1);
            this.Name = "GrowthSimulation";
            this.Text = "GrowthSimulation";
            ((System.ComponentModel.ISupportInitialize)(this.densityBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar densityBar;
        private System.Windows.Forms.Label densityLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentDensityTB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox currentSpeedTB;
    }
}