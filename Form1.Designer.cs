namespace Tabada_IntSys1_ImageProcessingProgram
{
    partial class MainForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnClearImages1 = new System.Windows.Forms.Button();
            this.btnHistogram = new System.Windows.Forms.Button();
            this.btnSepia = new System.Windows.Forms.Button();
            this.btnGrayscale = new System.Windows.Forms.Button();
            this.btnInvert = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnSaveImage1 = new System.Windows.Forms.Button();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pbOutputImage = new System.Windows.Forms.PictureBox();
            this.pbInputImage = new System.Windows.Forms.PictureBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnSubtract = new System.Windows.Forms.Button();
            this.pbSubtractedImage = new System.Windows.Forms.PictureBox();
            this.pbBackgroundImage = new System.Windows.Forms.PictureBox();
            this.btnClearImages2 = new System.Windows.Forms.Button();
            this.btnLoadBackground = new System.Windows.Forms.Button();
            this.btnSaveImage2 = new System.Windows.Forms.Button();
            this.btnLoadForeground = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.pbForegroundImage = new System.Windows.Forms.PictureBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutputImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInputImage)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubtractedImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbForegroundImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.MinimumSize = this.tabControl1.Size;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1200, 800);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnClearImages1);
            this.tabPage1.Controls.Add(this.btnHistogram);
            this.tabPage1.Controls.Add(this.btnSepia);
            this.tabPage1.Controls.Add(this.btnGrayscale);
            this.tabPage1.Controls.Add(this.btnInvert);
            this.tabPage1.Controls.Add(this.btnCopy);
            this.tabPage1.Controls.Add(this.btnSaveImage1);
            this.tabPage1.Controls.Add(this.btnLoadImage);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.pbOutputImage);
            this.tabPage1.Controls.Add(this.pbInputImage);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.MinimumSize = this.tabPage1.Size;
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1192, 767);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Basic Mode";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnClearImages1
            // 
            this.btnClearImages1.Location = new System.Drawing.Point(517, 22);
            this.btnClearImages1.MinimumSize = this.btnClearImages1.Size;
            this.btnClearImages1.Name = "btnClearImages1";
            this.btnClearImages1.Size = new System.Drawing.Size(150, 30);
            this.btnClearImages1.TabIndex = 11;
            this.btnClearImages1.Text = "Clear Images";
            this.btnClearImages1.UseVisualStyleBackColor = true;
            this.btnClearImages1.Click += new System.EventHandler(this.btnClearImages1_Click);
            // 
            // btnHistogram
            // 
            this.btnHistogram.Location = new System.Drawing.Point(986, 695);
            this.btnHistogram.MinimumSize = this.btnHistogram.Size;
            this.btnHistogram.Name = "btnHistogram";
            this.btnHistogram.Size = new System.Drawing.Size(150, 30);
            this.btnHistogram.TabIndex = 10;
            this.btnHistogram.Text = "Histogram";
            this.btnHistogram.UseVisualStyleBackColor = true;
            this.btnHistogram.Click += new System.EventHandler(this.btnHistogram_Click);
            // 
            // btnSepia
            // 
            this.btnSepia.Location = new System.Drawing.Point(754, 695);
            this.btnSepia.MinimumSize = this.btnSepia.Size;
            this.btnSepia.Name = "btnSepia";
            this.btnSepia.Size = new System.Drawing.Size(150, 30);
            this.btnSepia.TabIndex = 9;
            this.btnSepia.Text = "Sepia";
            this.btnSepia.UseVisualStyleBackColor = true;
            this.btnSepia.Click += new System.EventHandler(this.btnSepia_Click);
            // 
            // btnGrayscale
            // 
            this.btnGrayscale.Location = new System.Drawing.Point(517, 695);
            this.btnGrayscale.MinimumSize = this.btnGrayscale.Size;
            this.btnGrayscale.Name = "btnGrayscale";
            this.btnGrayscale.Size = new System.Drawing.Size(150, 30);
            this.btnGrayscale.TabIndex = 8;
            this.btnGrayscale.Text = "Grayscale";
            this.btnGrayscale.UseVisualStyleBackColor = true;
            this.btnGrayscale.Click += new System.EventHandler(this.btnGrayscale_Click);
            // 
            // btnInvert
            // 
            this.btnInvert.Location = new System.Drawing.Point(295, 695);
            this.btnInvert.MinimumSize = this.btnInvert.Size;
            this.btnInvert.Name = "btnInvert";
            this.btnInvert.Size = new System.Drawing.Size(150, 30);
            this.btnInvert.TabIndex = 7;
            this.btnInvert.Text = "Invert";
            this.btnInvert.UseVisualStyleBackColor = true;
            this.btnInvert.Click += new System.EventHandler(this.btnInvert_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(54, 695);
            this.btnCopy.MinimumSize = this.btnCopy.Size;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(150, 30);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnSaveImage1
            // 
            this.btnSaveImage1.Location = new System.Drawing.Point(829, 589);
            this.btnSaveImage1.MinimumSize = this.btnSaveImage1.Size;
            this.btnSaveImage1.Name = "btnSaveImage1";
            this.btnSaveImage1.Size = new System.Drawing.Size(150, 30);
            this.btnSaveImage1.TabIndex = 5;
            this.btnSaveImage1.Text = "Save Image";
            this.btnSaveImage1.UseVisualStyleBackColor = true;
            this.btnSaveImage1.Click += new System.EventHandler(this.btnSaveImage1_Click);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(218, 589);
            this.btnLoadImage.MinimumSize = this.btnLoadImage.Size;
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(150, 30);
            this.btnLoadImage.TabIndex = 4;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(848, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Output Image";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input Image";
            // 
            // pbOutputImage
            // 
            this.pbOutputImage.Location = new System.Drawing.Point(636, 69);
            this.pbOutputImage.MinimumSize = this.pbOutputImage.Size;
            this.pbOutputImage.Name = "pbOutputImage";
            this.pbOutputImage.Size = new System.Drawing.Size(500, 500);
            this.pbOutputImage.TabIndex = 1;
            this.pbOutputImage.TabStop = false;
            // 
            // pbInputImage
            // 
            this.pbInputImage.Location = new System.Drawing.Point(54, 69);
            this.pbInputImage.MinimumSize = this.pbInputImage.Size;
            this.pbInputImage.Name = "pbInputImage";
            this.pbInputImage.Size = new System.Drawing.Size(500, 500);
            this.pbInputImage.TabIndex = 0;
            this.pbInputImage.TabStop = false;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnSubtract);
            this.tabPage2.Controls.Add(this.pbSubtractedImage);
            this.tabPage2.Controls.Add(this.pbBackgroundImage);
            this.tabPage2.Controls.Add(this.btnClearImages2);
            this.tabPage2.Controls.Add(this.btnLoadBackground);
            this.tabPage2.Controls.Add(this.btnSaveImage2);
            this.tabPage2.Controls.Add(this.btnLoadForeground);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.pbForegroundImage);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.MinimumSize = this.tabPage2.Size;
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1192, 767);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Subtract Mode";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnSubtract
            // 
            this.btnSubtract.Location = new System.Drawing.Point(864, 637);
            this.btnSubtract.MinimumSize = this.btnSubtract.Size;
            this.btnSubtract.Name = "btnSubtract";
            this.btnSubtract.Size = new System.Drawing.Size(150, 30);
            this.btnSubtract.TabIndex = 26;
            this.btnSubtract.Text = "Subtract";
            this.btnSubtract.UseVisualStyleBackColor = true;
            this.btnSubtract.Click += new System.EventHandler(this.btnSubtract_Click);
            // 
            // pbSubtractedImage
            // 
            this.pbSubtractedImage.Location = new System.Drawing.Point(659, 117);
            this.pbSubtractedImage.MinimumSize = this.pbSubtractedImage.Size;
            this.pbSubtractedImage.Name = "pbSubtractedImage";
            this.pbSubtractedImage.Size = new System.Drawing.Size(500, 500);
            this.pbSubtractedImage.TabIndex = 25;
            this.pbSubtractedImage.TabStop = false;
            // 
            // pbBackgroundImage
            // 
            this.pbBackgroundImage.Location = new System.Drawing.Point(60, 395);
            this.pbBackgroundImage.MinimumSize = this.pbBackgroundImage.Size;
            this.pbBackgroundImage.Name = "pbBackgroundImage";
            this.pbBackgroundImage.Size = new System.Drawing.Size(350, 350);
            this.pbBackgroundImage.TabIndex = 24;
            this.pbBackgroundImage.TabStop = false;
            // 
            // btnClearImages2
            // 
            this.btnClearImages2.Location = new System.Drawing.Point(452, 16);
            this.btnClearImages2.MinimumSize = this.btnClearImages2.Size;
            this.btnClearImages2.Name = "btnClearImages2";
            this.btnClearImages2.Size = new System.Drawing.Size(150, 30);
            this.btnClearImages2.TabIndex = 23;
            this.btnClearImages2.Text = "Clear Images";
            this.btnClearImages2.UseVisualStyleBackColor = true;
            this.btnClearImages2.Click += new System.EventHandler(this.btnClearImages2_Click);
            // 
            // btnLoadBackground
            // 
            this.btnLoadBackground.Location = new System.Drawing.Point(452, 567);
            this.btnLoadBackground.MinimumSize = this.btnLoadBackground.Size;
            this.btnLoadBackground.Name = "btnLoadBackground";
            this.btnLoadBackground.Size = new System.Drawing.Size(150, 30);
            this.btnLoadBackground.TabIndex = 20;
            this.btnLoadBackground.Text = "Load Background";
            this.btnLoadBackground.UseVisualStyleBackColor = true;
            this.btnLoadBackground.Click += new System.EventHandler(this.btnLoadBackground_Click);
            // 
            // btnSaveImage2
            // 
            this.btnSaveImage2.Location = new System.Drawing.Point(864, 16);
            this.btnSaveImage2.MinimumSize = this.btnSaveImage2.Size;
            this.btnSaveImage2.Name = "btnSaveImage2";
            this.btnSaveImage2.Size = new System.Drawing.Size(150, 30);
            this.btnSaveImage2.TabIndex = 17;
            this.btnSaveImage2.Text = "Save Image";
            this.btnSaveImage2.UseVisualStyleBackColor = true;
            this.btnSaveImage2.Click += new System.EventHandler(this.btnSaveImage2_Click);
            // 
            // btnLoadForeground
            // 
            this.btnLoadForeground.Location = new System.Drawing.Point(452, 187);
            this.btnLoadForeground.MinimumSize = this.btnLoadForeground.Size;
            this.btnLoadForeground.Name = "btnLoadForeground";
            this.btnLoadForeground.Size = new System.Drawing.Size(150, 30);
            this.btnLoadForeground.TabIndex = 16;
            this.btnLoadForeground.Text = "Load Foreground";
            this.btnLoadForeground.UseVisualStyleBackColor = true;
            this.btnLoadForeground.Click += new System.EventHandler(this.btnLoadForeground_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(860, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 15;
            this.label3.Text = "Subtracted Image";
            // 
            // pbForegroundImage
            // 
            this.pbForegroundImage.Location = new System.Drawing.Point(60, 16);
            this.pbForegroundImage.MinimumSize = this.pbForegroundImage.Size;
            this.pbForegroundImage.Name = "pbForegroundImage";
            this.pbForegroundImage.Size = new System.Drawing.Size(350, 350);
            this.pbForegroundImage.TabIndex = 12;
            this.pbForegroundImage.TabStop = false;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Tabada Image Processor";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutputImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbInputImage)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSubtractedImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackgroundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbForegroundImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbOutputImage;
        private System.Windows.Forms.PictureBox pbInputImage;
        private System.Windows.Forms.PictureBox pbBackgroundImage;
        private System.Windows.Forms.PictureBox pbForegroundImage;
        private System.Windows.Forms.PictureBox pbSubtractedImage;
        private System.Windows.Forms.Button btnHistogram;
        private System.Windows.Forms.Button btnSepia;
        private System.Windows.Forms.Button btnGrayscale;
        private System.Windows.Forms.Button btnInvert;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnSaveImage1;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.Button btnClearImages1;
        private System.Windows.Forms.Button btnClearImages2;
        private System.Windows.Forms.Button btnLoadBackground;
        private System.Windows.Forms.Button btnSaveImage2;
        private System.Windows.Forms.Button btnLoadForeground;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnSubtract;
    }
}

