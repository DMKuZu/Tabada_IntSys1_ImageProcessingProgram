using Microsoft.Win32;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace Tabada_IntSys1_ImageProcessingProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private Bitmap? _image, _foreground, _background, _basicOutput, _subtractOutput;
        private BitmapImage? image, foreground, background, basicOutput, subtractOutput;

        // Helper
        private static BitmapSource? BitmapToImageSource(Bitmap? bitmap)
        {
            if (bitmap == null) return null;

            using (var memory = new MemoryStream())
            {
                bitmap.Save(memory, ImageFormat.Png);
                memory.Position = 0;

                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memory;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();

                return bitmapImage;
            }
        }

        // Miscellaneous
        private void LoadImage(object sender, RoutedEventArgs e) 
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filePath = dialog.FileName;

                // Store for processing
                _image = new Bitmap(filePath);

                // Store for display
                image = BitmapToImageSource(_image) as BitmapImage;

                // Render image
                InputImage.Source = image;
            }
        }
        private void LoadForeground(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filePath = dialog.FileName;

                // Store for processing
                _foreground = new Bitmap(filePath);

                // Store for display
                foreground = BitmapToImageSource(_image) as BitmapImage;

                // Render image
                InputImage.Source = foreground;
            }
        }
        private void LoadBackground(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Image Files|*.png;*.jpg;*.jpeg"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filePath = dialog.FileName;

                // Store for processing
                _background = new Bitmap(filePath);

                // Store for display
                background = BitmapToImageSource(_image) as BitmapImage;

                // Render image
                InputImage.Source = background;
            }
        }
        private void SaveBasicOutput(object sender, RoutedEventArgs e)
        {
            if (_basicOutput == null) return;

            var dialog = new SaveFileDialog
            {
                Filter = "PNG Image|*.png|JPEG Image|*.jpg"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filePath = dialog.FileName;

                var format = filePath.EndsWith(".jpg") ? ImageFormat.Jpeg : ImageFormat.Png;
                _basicOutput.Save(filePath, format);
            }
        }
        private void SaveSubtractOutput(object sender, RoutedEventArgs e)
        {
            if (_subtractOutput == null) return;

            var dialog = new SaveFileDialog
            {
                Filter = "PNG Image|*.png|JPEG Image|*.jpg"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                string filePath = dialog.FileName;

                var format = filePath.EndsWith(".jpg") ? ImageFormat.Jpeg : ImageFormat.Png;
                _subtractOutput.Save(filePath, format);
            }
        }
        private void ClearBasicImages(object sender, RoutedEventArgs e)
        {
            _image = null;
            _basicOutput = null;
            image = null;
            basicOutput = null;
            InputImage.Source = null;
            OutputImage.Source = null;
        }
        private void ClearSubtractImages(object sender, RoutedEventArgs e)
        {
            _foreground = null;
            _background = null;
            _subtractOutput = null;
            foreground = null;
            background = null;
            subtractOutput = null;
            ForegroundImage.Source = null;
            BackgroundImage.Source = null;
            SubtractOutputImage.Source = null;
        }

        // Basic Mode
        private void Copy(object sender, RoutedEventArgs e)
        {
            if (_image == null) return;

            Bitmap output = new Bitmap(_image.Width, _image.Height);

            for (int y = 0; y < _image.Height; y++)
            {
                for (int x = 0; x < _image.Width; x++)
                {
                    System.Drawing.Color pixel = _image.GetPixel(x, y);
                    output.SetPixel(x, y, pixel);
                }
            }

            _basicOutput = output;
            basicOutput = BitmapToImageSource(output) as BitmapImage;

            // Render Image
            OutputImage.Source = basicOutput;
        }
        private void Invert(object sender, RoutedEventArgs e)
        {
            if (_image == null) return;

            Bitmap output = new Bitmap(_image.Width, _image.Height);

            for (int y = 0; y < _image.Height; y++)
            {
                for (int x = 0; x < _image.Width; x++)
                {
                    System.Drawing.Color pixel = _image.GetPixel(x, y);
                    int r = 255 - pixel.R;
                    int g = 255 - pixel.G;
                    int b = 255 - pixel.B;
                    output.SetPixel(x, y, System.Drawing.Color.FromArgb(r, g, b));
                }
            }

            _basicOutput = output;
            basicOutput = BitmapToImageSource(output) as BitmapImage;

            // Render image
            OutputImage.Source = basicOutput;
        }
        private void GrayScale(object sender, RoutedEventArgs e)
        {
            if (_image == null) return;

            Bitmap output = new Bitmap(_image.Width, _image.Height);

            for (int y = 0; y < _image.Height; y++)
            {
                for (int x = 0; x < _image.Width; x++)
                {
                    System.Drawing.Color pixel = _image.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    output.SetPixel(x, y, System.Drawing.Color.FromArgb(gray, gray, gray));
                }
            }

            _basicOutput = output;
            basicOutput = BitmapToImageSource(output) as BitmapImage;

            // Render image
            OutputImage.Source = basicOutput;
        }
        private void Sepia(object sender, RoutedEventArgs e)
        {
            if (_image == null) return;

            Bitmap output = new Bitmap(_image.Width, _image.Height);

            for (int y = 0; y < _image.Height; y++)
            {
                for (int x = 0; x < _image.Width; x++)
                {
                    System.Drawing.Color pixel = _image.GetPixel(x, y);
                    int tr = (int)(0.393 * pixel.R + 0.769 * pixel.G + 0.189 * pixel.B);
                    int tg = (int)(0.349 * pixel.R + 0.686 * pixel.G + 0.168 * pixel.B);
                    int tb = (int)(0.272 * pixel.R + 0.534 * pixel.G + 0.131 * pixel.B);

                    int r = Math.Min(255, tr);
                    int g = Math.Min(255, tg);
                    int b = Math.Min(255, tb);

                    output.SetPixel(x, y, System.Drawing.Color.FromArgb(r, g, b));
                }
            }

            _basicOutput = output;
            basicOutput = BitmapToImageSource(output) as BitmapImage;

            // Render image
            OutputImage.Source = basicOutput;
        }
        private void Histogram(object sender, RoutedEventArgs e)
        {
            if (_image == null) return;

            int width = 350;
            int height = 200;

            // Calculate histogram
            int[] hist = new int[256];
            for (int y = 0; y < _image.Height; y++)
            {
                for (int x = 0; x < _image.Width; x++)
                {
                    var color = _image.GetPixel(x, y);
                    int gray = (color.R + color.G + color.B) / 3;
                    hist[gray]++;
                }
            }

            // Create bitmap for histogram
            Bitmap histBitmap = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(histBitmap))
            {
                g.Clear(Color.White);

                int max = hist.Max();
                float barWidth = (float)(width - 40) / hist.Length;
                float offsetX = 30;
                float offsetY = 20;

                // Draw axes
                using (var axisPen = new Pen(Color.Black, 1.5f))
                {
                    g.DrawLine(axisPen, offsetX, 0, offsetX, height - offsetY);
                    g.DrawLine(axisPen, offsetX, height - offsetY, width, height - offsetY);
                }

                // Draw histogram bars
                for (int i = 0; i < hist.Length; i++)
                {
                    float h = (float)hist[i] / max * (height - offsetY - 10);
                    Color barColor = Color.FromArgb(i, 255 - i, 128 + (i / 2));
                    using (var barBrush = new SolidBrush(barColor))
                    {
                        g.FillRectangle(barBrush, offsetX + i * barWidth, (height - offsetY) - h, barWidth, h);
                    }
                }

                // X-axis labels
                int[] xLabels = { 0, 64, 128, 192, 255 };
                using (var textBrush = new SolidBrush(Color.Black))
                using (var font = new Font("Arial", 9))
                {
                    foreach (var label in xLabels)
                    {
                        float x = offsetX + label * barWidth;
                        g.DrawString(label.ToString(), font, textBrush, x - 8, height - 15);
                    }
                    // Y-axis max label
                    g.DrawString(max.ToString(), font, textBrush, 2, 2);
                }
            }

            // Display histogram in OutputImage
            _basicOutput = histBitmap;
            basicOutput = BitmapToImageSource(histBitmap) as BitmapImage;
            OutputImage.Source = basicOutput;
        }

        // Subtract Mode
        private void Subtract(object sender, RoutedEventArgs e)
        {

        }
    }
}