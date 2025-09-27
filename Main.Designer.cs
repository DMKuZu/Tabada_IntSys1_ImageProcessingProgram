namespace Tabada_IntSys1_ImageProcessingProgram
{
    partial class Main
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
            this.pbSource = new System.Windows.Forms.PictureBox();
            this.pbBackground = new System.Windows.Forms.PictureBox();
            this.pbOutput = new System.Windows.Forms.PictureBox();
            this.cbWebcamActivator = new System.Windows.Forms.CheckBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.processToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grayscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.histogramToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtractToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convolutionalKernelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blurringFIltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boxBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gaussianBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.weightedBlurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeDetectionFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sobelVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prewittToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prewittHorizontalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.prewittVerticalToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.laplacianToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpeningFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.standardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unsharpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edgeEnhancementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customFiltersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.embossToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLoadSource = new System.Windows.Forms.Button();
            this.btnLoadBackground = new System.Windows.Forms.Button();
            this.btnSaveOutput = new System.Windows.Forms.Button();
            this.btnClearImage = new System.Windows.Forms.Button();
            this.cblsDevices = new System.Windows.Forms.ComboBox();
            this.tmrOutputReload = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbSource
            // 
            this.pbSource.Location = new System.Drawing.Point(13, 36);
            this.pbSource.Name = "pbSource";
            this.pbSource.Size = new System.Drawing.Size(550, 550);
            this.pbSource.TabIndex = 0;
            this.pbSource.TabStop = false;
            // 
            // pbBackground
            // 
            this.pbBackground.Location = new System.Drawing.Point(638, 36);
            this.pbBackground.Name = "pbBackground";
            this.pbBackground.Size = new System.Drawing.Size(550, 550);
            this.pbBackground.TabIndex = 1;
            this.pbBackground.TabStop = false;
            // 
            // pbOutput
            // 
            this.pbOutput.Location = new System.Drawing.Point(321, 614);
            this.pbOutput.Name = "pbOutput";
            this.pbOutput.Size = new System.Drawing.Size(550, 550);
            this.pbOutput.TabIndex = 2;
            this.pbOutput.TabStop = false;
            // 
            // cbWebcamActivator
            // 
            this.cbWebcamActivator.AutoSize = true;
            this.cbWebcamActivator.Location = new System.Drawing.Point(12, 695);
            this.cbWebcamActivator.Name = "cbWebcamActivator";
            this.cbWebcamActivator.Size = new System.Drawing.Size(239, 24);
            this.cbWebcamActivator.TabIndex = 3;
            this.cbWebcamActivator.Text = "Activate/Deactivate Webcam";
            this.cbWebcamActivator.UseVisualStyleBackColor = true;
            this.cbWebcamActivator.CheckedChanged += new System.EventHandler(this.cbWebcamActivator_CheckedChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.processToolStripMenuItem,
            this.convolutionalKernelsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1200, 33);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // processToolStripMenuItem
            // 
            this.processToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.grayscaleToolStripMenuItem,
            this.invertToolStripMenuItem,
            this.sepiaToolStripMenuItem,
            this.histogramToolStripMenuItem,
            this.subtractToolStripMenuItem});
            this.processToolStripMenuItem.Name = "processToolStripMenuItem";
            this.processToolStripMenuItem.Size = new System.Drawing.Size(143, 29);
            this.processToolStripMenuItem.Text = "Process Image";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // grayscaleToolStripMenuItem
            // 
            this.grayscaleToolStripMenuItem.Name = "grayscaleToolStripMenuItem";
            this.grayscaleToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.grayscaleToolStripMenuItem.Text = "Grayscale";
            this.grayscaleToolStripMenuItem.Click += new System.EventHandler(this.grayscaleToolStripMenuItem_Click);
            // 
            // invertToolStripMenuItem
            // 
            this.invertToolStripMenuItem.Name = "invertToolStripMenuItem";
            this.invertToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.invertToolStripMenuItem.Text = "Invert";
            this.invertToolStripMenuItem.Click += new System.EventHandler(this.invertToolStripMenuItem_Click);
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.sepiaToolStripMenuItem.Text = "Sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.sepiaToolStripMenuItem_Click);
            // 
            // histogramToolStripMenuItem
            // 
            this.histogramToolStripMenuItem.Name = "histogramToolStripMenuItem";
            this.histogramToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.histogramToolStripMenuItem.Text = "Histogram";
            this.histogramToolStripMenuItem.Click += new System.EventHandler(this.histogramToolStripMenuItem_Click);
            // 
            // subtractToolStripMenuItem
            // 
            this.subtractToolStripMenuItem.Name = "subtractToolStripMenuItem";
            this.subtractToolStripMenuItem.Size = new System.Drawing.Size(198, 34);
            this.subtractToolStripMenuItem.Text = "Subtract";
            this.subtractToolStripMenuItem.Click += new System.EventHandler(this.subtractToolStripMenuItem_Click);
            // 
            // convolutionalKernelsToolStripMenuItem
            // 
            this.convolutionalKernelsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blurringFIltersToolStripMenuItem,
            this.edgeDetectionFiltersToolStripMenuItem,
            this.sharpeningFiltersToolStripMenuItem,
            this.customFiltersToolStripMenuItem});
            this.convolutionalKernelsToolStripMenuItem.Name = "convolutionalKernelsToolStripMenuItem";
            this.convolutionalKernelsToolStripMenuItem.Size = new System.Drawing.Size(189, 29);
            this.convolutionalKernelsToolStripMenuItem.Text = "Convolutional Filters";
            // 
            // blurringFIltersToolStripMenuItem
            // 
            this.blurringFIltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boxBlurToolStripMenuItem,
            this.gaussianBlurToolStripMenuItem,
            this.weightedBlurToolStripMenuItem});
            this.blurringFIltersToolStripMenuItem.Name = "blurringFIltersToolStripMenuItem";
            this.blurringFIltersToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.blurringFIltersToolStripMenuItem.Text = "Blurring Filters";
            // 
            // boxBlurToolStripMenuItem
            // 
            this.boxBlurToolStripMenuItem.Name = "boxBlurToolStripMenuItem";
            this.boxBlurToolStripMenuItem.Size = new System.Drawing.Size(190, 34);
            this.boxBlurToolStripMenuItem.Text = "Box";
            this.boxBlurToolStripMenuItem.Click += new System.EventHandler(this.boxBlurToolStripMenuItem_Click);
            // 
            // gaussianBlurToolStripMenuItem
            // 
            this.gaussianBlurToolStripMenuItem.Name = "gaussianBlurToolStripMenuItem";
            this.gaussianBlurToolStripMenuItem.Size = new System.Drawing.Size(190, 34);
            this.gaussianBlurToolStripMenuItem.Text = "Gaussian";
            this.gaussianBlurToolStripMenuItem.Click += new System.EventHandler(this.gaussianBlurToolStripMenuItem_Click);
            // 
            // weightedBlurToolStripMenuItem
            // 
            this.weightedBlurToolStripMenuItem.Name = "weightedBlurToolStripMenuItem";
            this.weightedBlurToolStripMenuItem.Size = new System.Drawing.Size(190, 34);
            this.weightedBlurToolStripMenuItem.Text = "Weighted";
            this.weightedBlurToolStripMenuItem.Click += new System.EventHandler(this.weightedBlurToolStripMenuItem_Click);
            // 
            // edgeDetectionFiltersToolStripMenuItem
            // 
            this.edgeDetectionFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobelToolStripMenuItem,
            this.prewittToolStripMenuItem,
            this.laplacianToolStripMenuItem});
            this.edgeDetectionFiltersToolStripMenuItem.Name = "edgeDetectionFiltersToolStripMenuItem";
            this.edgeDetectionFiltersToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.edgeDetectionFiltersToolStripMenuItem.Text = "Edge-Detection Filters";
            // 
            // sobelToolStripMenuItem
            // 
            this.sobelToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sobelHorizontalToolStripMenuItem,
            this.sobelVerticalToolStripMenuItem});
            this.sobelToolStripMenuItem.Name = "sobelToolStripMenuItem";
            this.sobelToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.sobelToolStripMenuItem.Text = "Sobel";
            // 
            // sobelHorizontalToolStripMenuItem
            // 
            this.sobelHorizontalToolStripMenuItem.Name = "sobelHorizontalToolStripMenuItem";
            this.sobelHorizontalToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.sobelHorizontalToolStripMenuItem.Text = "Horizontal";
            this.sobelHorizontalToolStripMenuItem.Click += new System.EventHandler(this.sobelHorizontalToolStripMenuItem_Click);
            // 
            // sobelVerticalToolStripMenuItem
            // 
            this.sobelVerticalToolStripMenuItem.Name = "sobelVerticalToolStripMenuItem";
            this.sobelVerticalToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.sobelVerticalToolStripMenuItem.Text = "Vertical";
            this.sobelVerticalToolStripMenuItem.Click += new System.EventHandler(this.sobelVerticalToolStripMenuItem_Click);
            // 
            // prewittToolStripMenuItem
            // 
            this.prewittToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prewittHorizontalToolStripMenuItem1,
            this.prewittVerticalToolStripMenuItem1});
            this.prewittToolStripMenuItem.Name = "prewittToolStripMenuItem";
            this.prewittToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.prewittToolStripMenuItem.Text = "Prewitt";
            // 
            // prewittHorizontalToolStripMenuItem1
            // 
            this.prewittHorizontalToolStripMenuItem1.Name = "prewittHorizontalToolStripMenuItem1";
            this.prewittHorizontalToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.prewittHorizontalToolStripMenuItem1.Text = "Horizontal";
            this.prewittHorizontalToolStripMenuItem1.Click += new System.EventHandler(this.prewittHorizontalToolStripMenuItem1_Click);
            // 
            // prewittVerticalToolStripMenuItem1
            // 
            this.prewittVerticalToolStripMenuItem1.Name = "prewittVerticalToolStripMenuItem1";
            this.prewittVerticalToolStripMenuItem1.Size = new System.Drawing.Size(270, 34);
            this.prewittVerticalToolStripMenuItem1.Text = "Vertical";
            this.prewittVerticalToolStripMenuItem1.Click += new System.EventHandler(this.prewittVerticalToolStripMenuItem1_Click);
            // 
            // laplacianToolStripMenuItem
            // 
            this.laplacianToolStripMenuItem.Name = "laplacianToolStripMenuItem";
            this.laplacianToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.laplacianToolStripMenuItem.Text = "Laplacian";
            this.laplacianToolStripMenuItem.Click += new System.EventHandler(this.laplacianToolStripMenuItem_Click);
            // 
            // sharpeningFiltersToolStripMenuItem
            // 
            this.sharpeningFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.standardToolStripMenuItem,
            this.unsharpToolStripMenuItem,
            this.edgeEnhancementToolStripMenuItem});
            this.sharpeningFiltersToolStripMenuItem.Name = "sharpeningFiltersToolStripMenuItem";
            this.sharpeningFiltersToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.sharpeningFiltersToolStripMenuItem.Text = "Sharpening Filters";
            // 
            // standardToolStripMenuItem
            // 
            this.standardToolStripMenuItem.Name = "standardToolStripMenuItem";
            this.standardToolStripMenuItem.Size = new System.Drawing.Size(265, 34);
            this.standardToolStripMenuItem.Text = "Standard";
            this.standardToolStripMenuItem.Click += new System.EventHandler(this.standardToolStripMenuItem_Click);
            // 
            // unsharpToolStripMenuItem
            // 
            this.unsharpToolStripMenuItem.Name = "unsharpToolStripMenuItem";
            this.unsharpToolStripMenuItem.Size = new System.Drawing.Size(265, 34);
            this.unsharpToolStripMenuItem.Text = "Unsharp";
            this.unsharpToolStripMenuItem.Click += new System.EventHandler(this.unsharpToolStripMenuItem_Click);
            // 
            // edgeEnhancementToolStripMenuItem
            // 
            this.edgeEnhancementToolStripMenuItem.Name = "edgeEnhancementToolStripMenuItem";
            this.edgeEnhancementToolStripMenuItem.Size = new System.Drawing.Size(265, 34);
            this.edgeEnhancementToolStripMenuItem.Text = "Edge Enhancement";
            this.edgeEnhancementToolStripMenuItem.Click += new System.EventHandler(this.edgeEnhancementToolStripMenuItem_Click);
            // 
            // customFiltersToolStripMenuItem
            // 
            this.customFiltersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.embossToolStripMenuItem});
            this.customFiltersToolStripMenuItem.Name = "customFiltersToolStripMenuItem";
            this.customFiltersToolStripMenuItem.Size = new System.Drawing.Size(288, 34);
            this.customFiltersToolStripMenuItem.Text = "Custom Filters";
            // 
            // embossToolStripMenuItem
            // 
            this.embossToolStripMenuItem.Name = "embossToolStripMenuItem";
            this.embossToolStripMenuItem.Size = new System.Drawing.Size(177, 34);
            this.embossToolStripMenuItem.Text = "Emboss";
            this.embossToolStripMenuItem.Click += new System.EventHandler(this.embossToolStripMenuItem_Click);
            // 
            // btnLoadSource
            // 
            this.btnLoadSource.Location = new System.Drawing.Point(13, 599);
            this.btnLoadSource.Name = "btnLoadSource";
            this.btnLoadSource.Size = new System.Drawing.Size(150, 60);
            this.btnLoadSource.TabIndex = 5;
            this.btnLoadSource.Text = "Load Source";
            this.btnLoadSource.UseVisualStyleBackColor = true;
            this.btnLoadSource.Click += new System.EventHandler(this.btnLoadSource_Click);
            // 
            // btnLoadBackground
            // 
            this.btnLoadBackground.Location = new System.Drawing.Point(1038, 599);
            this.btnLoadBackground.Name = "btnLoadBackground";
            this.btnLoadBackground.Size = new System.Drawing.Size(150, 60);
            this.btnLoadBackground.TabIndex = 6;
            this.btnLoadBackground.Text = "Load Background";
            this.btnLoadBackground.UseVisualStyleBackColor = true;
            this.btnLoadBackground.Click += new System.EventHandler(this.btnLoadBackground_Click);
            // 
            // btnSaveOutput
            // 
            this.btnSaveOutput.Location = new System.Drawing.Point(954, 896);
            this.btnSaveOutput.Name = "btnSaveOutput";
            this.btnSaveOutput.Size = new System.Drawing.Size(150, 60);
            this.btnSaveOutput.TabIndex = 7;
            this.btnSaveOutput.Text = "Save Output";
            this.btnSaveOutput.UseVisualStyleBackColor = true;
            this.btnSaveOutput.Click += new System.EventHandler(this.btnSaveOutput_Click);
            // 
            // btnClearImage
            // 
            this.btnClearImage.Location = new System.Drawing.Point(71, 916);
            this.btnClearImage.Name = "btnClearImage";
            this.btnClearImage.Size = new System.Drawing.Size(150, 60);
            this.btnClearImage.TabIndex = 8;
            this.btnClearImage.Text = "Clear Images";
            this.btnClearImage.UseVisualStyleBackColor = true;
            this.btnClearImage.Click += new System.EventHandler(this.btnClearImage_Click);
            // 
            // cblsDevices
            // 
            this.cblsDevices.FormattingEnabled = true;
            this.cblsDevices.Location = new System.Drawing.Point(12, 747);
            this.cblsDevices.Name = "cblsDevices";
            this.cblsDevices.Size = new System.Drawing.Size(300, 28);
            this.cblsDevices.TabIndex = 9;
            // 
            // tmrOutputReload
            // 
            this.tmrOutputReload.Interval = 1000;
            this.tmrOutputReload.Tick += new System.EventHandler(this.tmrOutputReload_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 1200);
            this.Controls.Add(this.cblsDevices);
            this.Controls.Add(this.btnClearImage);
            this.Controls.Add(this.btnSaveOutput);
            this.Controls.Add(this.btnLoadBackground);
            this.Controls.Add(this.btnLoadSource);
            this.Controls.Add(this.cbWebcamActivator);
            this.Controls.Add(this.pbOutput);
            this.Controls.Add(this.pbBackground);
            this.Controls.Add(this.pbSource);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MinimumSize = new System.Drawing.Size(1200, 1200);
            this.Name = "Main";
            this.Text = "Tabada Image Processor";
            ((System.ComponentModel.ISupportInitialize)(this.pbSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBackground)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbOutput)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbSource;
        private System.Windows.Forms.PictureBox pbBackground;
        private System.Windows.Forms.PictureBox pbOutput;
        private System.Windows.Forms.CheckBox cbWebcamActivator;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem processToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem grayscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem histogramToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtractToolStripMenuItem;
        private System.Windows.Forms.Button btnLoadSource;
        private System.Windows.Forms.Button btnLoadBackground;
        private System.Windows.Forms.Button btnSaveOutput;
        private System.Windows.Forms.Button btnClearImage;
        private System.Windows.Forms.ComboBox cblsDevices;
        private System.Windows.Forms.Timer tmrOutputReload;
        private System.Windows.Forms.ToolStripMenuItem convolutionalKernelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blurringFIltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem boxBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gaussianBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem weightedBlurToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeDetectionFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prewittToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem laplacianToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpeningFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem standardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unsharpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edgeEnhancementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customFiltersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem embossToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sobelVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prewittHorizontalToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem prewittVerticalToolStripMenuItem1;
    }
}