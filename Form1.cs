using System;
using System.Drawing;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace Tabada_IntSys1_ImageProcessingProgram
{
    public partial class MainForm : Form
    {
        private BasicProcessor _basicProcessor;
        private SubtractProcessor _subtractProcessor;
        private VideoProcessor _videoProcessor;

        private enum WebcamProcessMode { None, Grayscale, Invert, Sepia, Subtract }
        private WebcamProcessMode _webcamMode = WebcamProcessMode.None;

        private Timer progressResetTimer;
        private Timer outputViewTimer;

        public MainForm()
        {
            InitializeComponent();
            InitializeProgressResetTimer();
            InitializeOutputViewTimer();
            _basicProcessor = new BasicProcessor();
            _subtractProcessor = new SubtractProcessor();
            _videoProcessor = new VideoProcessor(comboBox1);
            _videoProcessor.FrameReady += (bmp) =>
            {
                Bitmap webcamBmp = (Bitmap)bmp.Clone();
                // Always update pbWebcamView on the UI thread
                if (pbWebcamView.InvokeRequired)
                    pbWebcamView.Invoke(new Action(() => {
                        pbWebcamView.Image?.Dispose();
                        pbWebcamView.Image = webcamBmp;
                    }));
                else
                {
                    pbWebcamView.Image?.Dispose();
                    pbWebcamView.Image = webcamBmp;
                }
                // No processing for pbOutputView here!
            };
            //SetDefaultImages();
        }
        private void SetDefaultImages()
        {
            string defaultInputPath = System.IO.Path.Combine(Application.StartupPath, "..\\..\\..\\static\\Input.jpeg");
            string defaultForegroundPath = System.IO.Path.Combine(Application.StartupPath, "..\\..\\..\\static\\Foreground.PNG");
            string defaultBackgroundPath = System.IO.Path.Combine(Application.StartupPath, "..\\..\\..\\static\\Background.jpg");

            SetInputPictureBox(new Bitmap(defaultInputPath));
            SetForegroundPictureBox(new Bitmap(defaultForegroundPath));
            SetBackgroundPictureBox(new Bitmap(defaultBackgroundPath));
        }
        private void SetProgress(int percent)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new Action(() => progressBar1.Value = percent));
            }
            else
            {
                progressBar1.Value = percent;
            }
        }
        private void ResetProgress()
        {
            SetProgress(0);
        }
        //
        // Basic Tab
        //
        private void SetInputPictureBox(Bitmap bmp)
        {
            pbInputImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbInputImage.Image = bmp;
        }
        private void SetOutputPictureBox(Bitmap bmp)
        {
            pbOutputImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbOutputImage.Image = bmp;
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg"
            };

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = dialog.FileName;

                var image = new Bitmap(filePath);
                _basicProcessor.OnLoadImage(filePath);

                SetInputPictureBox(image);
            }
        }

        private void btnSaveImage1_Click(object sender, EventArgs e)
        {
            if (_basicProcessor.isOutputNull())
                return;

            var dialog = new SaveFileDialog
            {
                Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg"
            };

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = dialog.FileName;
                _basicProcessor.OnSaveImage(filePath);
            }
        }

        private void btnClearImages1_Click(object sender, EventArgs e)
        {
            _basicProcessor.OnClear();
            SetInputPictureBox(null);
            SetOutputPictureBox(null);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            ResetProgress();
            var image = _basicProcessor.OnCopy(SetProgress);
            SetProgress(100);
            progressResetTimer.Start();
            SetOutputPictureBox(image);
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            ResetProgress();
            var image = _basicProcessor.OnInvert(SetProgress);
            SetProgress(100);
            progressResetTimer.Start();
            SetOutputPictureBox(image);
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            ResetProgress();
            var image = _basicProcessor.OnGrayScale(SetProgress);
            SetProgress(100);
            progressResetTimer.Start();
            SetOutputPictureBox(image);
        }

        private void btnSepia_Click(object sender, EventArgs e)
        {
            ResetProgress();
            var image = _basicProcessor.OnSepia(SetProgress);
            SetProgress(100);
            progressResetTimer.Start();
            SetOutputPictureBox(image);
        }

        private void btnHistogram_Click(object sender, EventArgs e)
        {
            var image = _basicProcessor.OnHistogram();

            SetOutputPictureBox(image);
        }
        //
        // Subtract Tab
        //
        private void SetForegroundPictureBox(Bitmap bmp)
        {
            pbForegroundImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbForegroundImage.Image = bmp;
        }
        private void SetBackgroundPictureBox(Bitmap bmp)
        {
            pbBackgroundImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbBackgroundImage.Image = bmp;
        }
        private void SetSubtractPictureBox(Bitmap bmp)
        {
            pbSubtractedImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbSubtractedImage.Image = bmp;
        }

        private void btnLoadForeground_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg"
            };

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = dialog.FileName;

                var image = new Bitmap(filePath);
                _subtractProcessor.OnLoadForeground(filePath);

                SetForegroundPictureBox(image);
            }
        }

        private void btnLoadBackground_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg"
            };

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = dialog.FileName;

                var image = new Bitmap(filePath);
                _subtractProcessor.OnLoadBackground(filePath);

                SetBackgroundPictureBox(image);
            }
        }

        private void btnSaveImage2_Click(object sender, EventArgs e)
        {
            if (_subtractProcessor.isOutputNull())
                return;

            var dialog = new SaveFileDialog
            {
                Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg"
            };

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = dialog.FileName;
                _subtractProcessor.OnSaveImage(filePath);
            }
        }

        private void btnClearImages2_Click(object sender, EventArgs e)
        {
            _subtractProcessor.OnClear();
            SetForegroundPictureBox(null);
            SetBackgroundPictureBox(null);
            SetSubtractPictureBox(null);
        }

        private void btnSubtract_Click(object sender, EventArgs e)
        {
            ResetProgress();
            var image = _subtractProcessor.OnSubtract(SetProgress);
            SetProgress(100);
            progressResetTimer.Start();
            SetSubtractPictureBox(image);
        }
        //
        // Webcam Tab
        //
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                _videoProcessor.OnActivate(comboBox1.SelectedIndex);
                outputViewTimer.Start();
            }
            else
            {
                _videoProcessor.OnDeactivate();
                outputViewTimer.Stop();
            }
        }

        private void btnWebcamGrayscale_Click(object sender, EventArgs e)
        {
            _webcamMode = WebcamProcessMode.Grayscale;
            outputViewTimer.Stop();
            outputViewTimer.Start();
        }

        private void btnWebcamInvert_Click(object sender, EventArgs e)
        {
            _webcamMode = WebcamProcessMode.Invert;
            outputViewTimer.Stop();
            outputViewTimer.Start();
        }

        private void btnWebcamSepia_Click(object sender, EventArgs e)
        {
            _webcamMode = WebcamProcessMode.Sepia;
            outputViewTimer.Stop();
            outputViewTimer.Start();
        }

        private void btnWebcamSubtract_Click(object sender, EventArgs e)
        {
            _webcamMode = WebcamProcessMode.Subtract;
            outputViewTimer.Stop();
            outputViewTimer.Start();
        }
        private void btnWebcamClearEffects_Click(object sender, EventArgs e)
        {
            _webcamMode = WebcamProcessMode.None;
            outputViewTimer.Stop();
            if (pbOutputView.Image != null)
            {
                pbOutputView.Image.Dispose();
                pbOutputView.Image = null;
            }
        }

        private void InitializeProgressResetTimer()
        {
            progressResetTimer = new Timer();
            progressResetTimer.Interval = 1000; // 1 second
            progressResetTimer.Tick += ProgressResetTimer_Tick;
        }

        private void InitializeOutputViewTimer()
        {
            outputViewTimer = new Timer();
            outputViewTimer.Interval = 2000; // 2 second
            outputViewTimer.Tick += OutputViewTimer_Tick;
        }

        private void ProgressResetTimer_Tick(object sender, EventArgs e)
        {
            progressResetTimer.Stop();
            ResetProgress();
        }

        private void OutputViewTimer_Tick(object sender, EventArgs e)
        {
            // Only process if a webcam mode is selected
            if (_webcamMode == WebcamProcessMode.None)
                return;

            Bitmap src = _videoProcessor.GetLatestFrame();
            if (src == null)
                return;

            Bitmap processed = null;
            switch (_webcamMode)
            {
                case WebcamProcessMode.Grayscale:
                    processed = _videoProcessor.ToGrayscale(src);
                    break;
                case WebcamProcessMode.Invert:
                    processed = _videoProcessor.ToInvert(src);
                    break;
                case WebcamProcessMode.Sepia:
                    processed = _videoProcessor.ToSepia(src);
                    break;
                case WebcamProcessMode.Subtract:
                    processed = _videoProcessor.ToSubtract(src, null); // no background for webcam
                    break;
            }
            src.Dispose();
            if (processed != null)
            {
                pbOutputView.Image = processed;
            }
        }
    }
}
