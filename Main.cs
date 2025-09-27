using System;
using AForge.Video.DirectShow;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

namespace Tabada_IntSys1_ImageProcessingProgram
{
    public partial class Main : Form
    {
        private Bitmap _source, _background, _output;
        private ImageProcessor _processor;
        private VideoCaptureDevice _vcd;
        private FilterInfoCollection _fic;
        private Bitmap _latestFrame;
        private readonly object _frameLock;
        private volatile bool _isProcessingOutputView;
        private ConvolutionMatrix _convMatx;

        private ProcessingMode _currentProcessingMode = ProcessingMode.None;
        private enum ProcessingMode
        {
            None,
            // Blurring
            BoxBlur,
            GaussianBlur,
            WeightedBlur,
            // Edge Detection
            SobelHorizontal,
            SobelVertical,
            PrewittHorizontal,
            PrewittVertical,
            Laplacian,
            // Sharpening
            Sharpen,
            UnsharpMask,
            EdgeEnhancement,
            // Embossing
            Emboss,
            // Other
            Copy,
            Grayscale,
            Invert,
            Sepia,
            Histogram,
            Subtract
        }
        public Main()
        {
            InitializeComponent();
            _source = null;
            _background = null;
            _output = null;
            _latestFrame = null;

            _convMatx = new ConvolutionMatrix();
            _isProcessingOutputView = false;
            _frameLock = new object();
            _processor = new ImageProcessor();
            _vcd = new VideoCaptureDevice();
            _fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo dev in _fic)
            {
                cblsDevices.Items.Add(dev.Name);
                cblsDevices.SelectedIndex = 0;
            }
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
                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.Copy;
                    return;
                }
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
                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.Grayscale;
                    return;
                }
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
                if (cbWebcamActivator.Checked)
                {   
                    _currentProcessingMode = ProcessingMode.Invert;
                    return;
                }
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
                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.Sepia;
                    return;
                }
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
                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.Histogram;
                    return;
                }
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
                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.Subtract;
                    return;
                }
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
            _currentProcessingMode = ProcessingMode.None;
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

        private void boxBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.BoxBlur;
                    return;
                }

                _convMatx.SetBoxBlur();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void gaussianBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.GaussianBlur;
                    return;
                }

                _convMatx.SetGaussianBlur();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void weightedBlurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.WeightedBlur;
                    return;
                }

                _convMatx.SetWeightedBlur();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void sobelHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.SobelHorizontal;
                    return;
                }

                _convMatx.SetSobelHorizontal();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void sobelVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.SobelVertical;
                    return;
                }

                _convMatx.SetSobelVertical();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void prewittHorizontalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.PrewittHorizontal;
                    return;
                }

                _convMatx.SetPrewittHorizontal();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void prewittVerticalToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.PrewittVertical;
                    return;
                }

                _convMatx.SetPrewittVertical();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.Laplacian;
                    return;
                }

                _convMatx.SetLaplacian();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.Sharpen;
                    return;
                }

                _convMatx.SetSharpen();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void unsharpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.UnsharpMask;
                    return;
                }

                _convMatx.SetUnsharpMask();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void edgeEnhancementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.EdgeEnhancement;
                    return;
                }

                _convMatx.SetEdgeEnhancement();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void embossToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (_source == null)
                    throw new Exception("Source image is not loaded.");

                if (cbWebcamActivator.Checked)
                {
                    _currentProcessingMode = ProcessingMode.Emboss;
                    return;
                }

                _convMatx.SetEmboss();
                _output = BitmapFilter.Conv3x3(_source, _convMatx);
                pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                pbOutput.Image = _output;
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void cbWebcamActivator_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (cbWebcamActivator.Checked)
                {
                    _vcd = new VideoCaptureDevice(_fic[cblsDevices.SelectedIndex].MonikerString);
                    _vcd.NewFrame += (s, ev) =>
                    {
                        lock (_frameLock)
                        {
                            _latestFrame?.Dispose();
                            _latestFrame = (Bitmap)ev.Frame.Clone();
                            pbSource.Image?.Dispose();
                            pbSource.SizeMode = PictureBoxSizeMode.Zoom;
                            pbSource.Image = _latestFrame;
                            _source = _latestFrame;
                        }
                    };
                    _vcd.Start();
                    tmrOutputReload.Start();
                }
                else
                {
                    _vcd.SignalToStop();
                    _vcd.WaitForStop();
                    tmrOutputReload.Stop();
                    _currentProcessingMode = ProcessingMode.None;
                }
            }
            catch (Exception ex)
            {
                ShowAlert(ex.Message);
            }
        }

        private void tmrOutputReload_Tick(object sender, EventArgs e)
        {
            if (_isProcessingOutputView || _currentProcessingMode == ProcessingMode.None)
                return;
            _isProcessingOutputView = true;
            Bitmap src = null;
            lock (_frameLock)
            {
                src = _latestFrame == null ? null : (Bitmap)_latestFrame.Clone();
            }
            if (src == null)
            {
                _isProcessingOutputView = false;
                return;
            }
            ThreadPool.QueueUserWorkItem(_ =>
            {
                Bitmap processed = null;
                try
                {
                    switch (_currentProcessingMode)
                    {
                        case ProcessingMode.Copy:
                            processed = _processor.ToCopy(src);
                            break;
                        case ProcessingMode.Grayscale:
                            processed = _processor.ToGrayScale(src);
                            break;
                        case ProcessingMode.Invert:
                            processed = _processor.ToInvert(src);
                            break;
                        case ProcessingMode.Sepia:
                            processed = _processor.ToSepia(src);
                            break;
                        case ProcessingMode.Histogram:
                            processed = _processor.ToHistogram(src);
                            break;
                        case ProcessingMode.Subtract:
                            if (_background != null)
                                processed = _processor.ToSubtract(src, _background);
                            break;
                        case ProcessingMode.BoxBlur:
                            _convMatx.SetBoxBlur();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                        case ProcessingMode.GaussianBlur:
                            _convMatx.SetGaussianBlur();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                        case ProcessingMode.WeightedBlur:
                            _convMatx.SetWeightedBlur();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                        case ProcessingMode.SobelHorizontal:
                            _convMatx.SetSobelHorizontal();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                        case ProcessingMode.SobelVertical:
                            _convMatx.SetSobelVertical();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                        case ProcessingMode.PrewittHorizontal:
                            _convMatx.SetPrewittHorizontal();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                        case ProcessingMode.PrewittVertical:
                            _convMatx.SetPrewittVertical();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                        case ProcessingMode.Laplacian:
                            _convMatx.SetLaplacian();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                        case ProcessingMode.Sharpen:
                            _convMatx.SetSharpen();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                        case ProcessingMode.UnsharpMask:
                            _convMatx.SetUnsharpMask();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                        case ProcessingMode.EdgeEnhancement:
                            _convMatx.SetEdgeEnhancement();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                        case ProcessingMode.Emboss:
                            _convMatx.SetEmboss();
                            processed = BitmapFilter.Conv3x3(src, _convMatx);
                            break;
                    }
                    if (processed != null)
                    {
                        pbOutput.Invoke((MethodInvoker)delegate
                        {
                            pbOutput.SizeMode = PictureBoxSizeMode.Zoom;
                            pbOutput.Image?.Dispose();
                            pbOutput.Image = processed;
                            _output?.Dispose();
                            _output = processed;
                        });
                    }
                    else
                    {
                        src.Dispose();
                    }
                }
                catch
                {
                    processed?.Dispose();
                    src.Dispose();
                }
                finally
                {
                    src?.Dispose();
                    _isProcessingOutputView = false;
                }
            });
        }


    }
}
