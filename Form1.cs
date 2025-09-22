using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Tabada_IntSys1_ImageProcessingProgram
{
    public partial class MainForm : Form
    {
        private BasicProcessor _basicProcessor;
        private SubtractProcessor _subtractProcessor;
        public MainForm()
        {
            InitializeComponent();
            _basicProcessor = new BasicProcessor();
            _subtractProcessor = new SubtractProcessor();
        }

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
            var image = _basicProcessor.OnCopy();

            SetOutputPictureBox(image);
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            var image = _basicProcessor.OnInvert();

            SetOutputPictureBox(image);
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            var image = _basicProcessor.OnGrayScale();

            SetOutputPictureBox(image);
        }

        private void btnSepia_Click(object sender, EventArgs e)
        {
            var image = _basicProcessor.OnSepia();

            SetOutputPictureBox(image);
        }

        private void btnHistogram_Click(object sender, EventArgs e)
        {
            var image = _basicProcessor.OnHistogram();

            SetOutputPictureBox(image);
        }



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
            var image = _subtractProcessor.OnSubtract();

            SetSubtractPictureBox(image);
        }
    }
}
