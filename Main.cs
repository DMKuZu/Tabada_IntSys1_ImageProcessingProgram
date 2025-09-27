using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tabada_IntSys1_ImageProcessingProgram
{
    public partial class Main : Form
    {
        private Bitmap _source, _background, _output;
        private ImageProcessor _processor;
        public Main()
        {
            InitializeComponent();
            _source = null;
            _background = null;
            _output = null;
            _processor = new ImageProcessor();
        }
        private void ShowAlert(string message, string title = "Alert")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                _output = _processor.ToCopy(_source);

                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;

            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void grayscaleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                _output = _processor.ToGrayScale(_source);

                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;

            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void invertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                _output = _processor.ToInvert(_source);

                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;

            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                _output = _processor.ToSepia(_source);

                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;

            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void histogramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                _output = _processor.ToHistogram(_source);

                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;

            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void subtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null || _background == null)
                    throw new Exception("Source or Background image is not loaded.");

                _output = _processor.ToSubtract(_source,_background);

                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;

            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void btnClearImage_Click(object sender, EventArgs e)
        {
            _source = null;
            _background = null;
            _output = null;
            pbSource.Image = null;
            pbBackground.Image = null;
            pbOutput.Image = null;
        }

        private static Bitmap convertTo24bpppRgb(Bitmap img)
        {
            Bitmap safeBmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(safeBmp))
            {
                g.DrawImage(img, 0, 0, img.Width, img.Height);
            }
            return safeBmp;
        }
        private void btnLoadSource_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg"
            };

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                string filePath = dialog.FileName;

                Bitmap bmp = new Bitmap(filePath);
                _source = new Bitmap(convertTo24bpppRgb(bmp));
                bmp.Dispose();

                pbSource.SizeMode = PictureBoxSizeMode.Zoom;
                pbSource.Image = _source;
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

                Bitmap bmp = new Bitmap(filePath);
                _background = new Bitmap(convertTo24bpppRgb(bmp));
                bmp.Dispose();

                pbBackground.SizeMode = PictureBoxSizeMode.Zoom;
                pbBackground.Image = _background;
            }
        }

        private void btnSaveOutput_Click(object sender, EventArgs e)
        {
            try
            {
                if (_output == null)
                    throw new Exception("Image output is not available.");

                var dialog = new SaveFileDialog
                {
                    Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg"
                };

                DialogResult result = dialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    string filePath = dialog.FileName;

                    _output.Save(filePath);
                }
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void cbWebcamActivator_CheckedChanged(object sender, EventArgs e)
        {

        }


        private void tmrOutputReload_Tick(object sender, EventArgs e)
        {

        }
    }
}
