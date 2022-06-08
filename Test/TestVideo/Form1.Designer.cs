namespace WinFormsApp2
{
    partial class VideoOutputTest
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.Btn_Stop = new System.Windows.Forms.Button();
            this.Btn_Play = new System.Windows.Forms.Button();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.Btn_SelectFile = new System.Windows.Forms.Button();
            this.speedLabel = new System.Windows.Forms.Label();
            this.Btn_ApplySpeed = new System.Windows.Forms.Button();
            this.speedBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(122, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(569, 286);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Location = new System.Drawing.Point(203, 355);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.Btn_Stop.TabIndex = 1;
            this.Btn_Stop.Text = "Stop";
            this.Btn_Stop.UseVisualStyleBackColor = true;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // Btn_Play
            // 
            this.Btn_Play.Location = new System.Drawing.Point(284, 355);
            this.Btn_Play.Name = "Btn_Play";
            this.Btn_Play.Size = new System.Drawing.Size(75, 23);
            this.Btn_Play.TabIndex = 2;
            this.Btn_Play.Text = "Play";
            this.Btn_Play.UseVisualStyleBackColor = true;
            this.Btn_Play.Click += new System.EventHandler(this.Btn_Play_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(122, 304);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(569, 45);
            this.trackBar.TabIndex = 3;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // Btn_SelectFile
            // 
            this.Btn_SelectFile.Location = new System.Drawing.Point(122, 355);
            this.Btn_SelectFile.Name = "Btn_SelectFile";
            this.Btn_SelectFile.Size = new System.Drawing.Size(75, 23);
            this.Btn_SelectFile.TabIndex = 4;
            this.Btn_SelectFile.Text = "Select File";
            this.Btn_SelectFile.UseVisualStyleBackColor = true;
            this.Btn_SelectFile.Click += new System.EventHandler(this.Btn_SelectFile_Click);
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(382, 359);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(42, 15);
            this.speedLabel.TabIndex = 5;
            this.speedLabel.Text = "Speed:";
            // 
            // Btn_ApplySpeed
            // 
            this.Btn_ApplySpeed.Location = new System.Drawing.Point(536, 355);
            this.Btn_ApplySpeed.Name = "Btn_ApplySpeed";
            this.Btn_ApplySpeed.Size = new System.Drawing.Size(75, 23);
            this.Btn_ApplySpeed.TabIndex = 7;
            this.Btn_ApplySpeed.Text = "Apply";
            this.Btn_ApplySpeed.UseVisualStyleBackColor = true;
            this.Btn_ApplySpeed.Click += new System.EventHandler(this.Btn_ApplySpeed_Click);
            // 
            // speedBox
            // 
            this.speedBox.Location = new System.Drawing.Point(430, 355);
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(100, 23);
            this.speedBox.TabIndex = 8;
            // 
            // VideoOutputTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.speedBox);
            this.Controls.Add(this.Btn_ApplySpeed);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.Btn_SelectFile);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.Btn_Play);
            this.Controls.Add(this.Btn_Stop);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "VideoOutputTest";
            this.Text = "VideoOutputTest";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private Button Btn_Stop;
        private Button Btn_Play;
        private TrackBar trackBar;
        private Button Btn_SelectFile;
        private Label speedLabel;
        private Button Btn_ApplySpeed;
        private TextBox speedBox;
    }
}