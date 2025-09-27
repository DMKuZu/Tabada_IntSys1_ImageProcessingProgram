using System;
using System.Drawing;
using System.Linq;

namespace Tabada_IntSys1_ImageProcessingProgram
{
    internal class BasicProcessor
    {
        private Bitmap _inputImage, _outputImage;
        public BasicProcessor() 
        { 
            _inputImage = null;
            _outputImage = null;
        }

        private void SetInput(Bitmap bmp)
        {
            _inputImage = bmp;
        }
        private void SetOutput(Bitmap bmp)
        {
            _outputImage = bmp;
        }

        public void OnLoadImage(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return;

            SetInput(new Bitmap(filePath));
        }
        public bool isOutputNull()
        {
            return _outputImage == null;
        }
        public void OnSaveImage(string filePath) 
        {
            if (string.IsNullOrEmpty(filePath) || _outputImage == null)
                return;
            
            _outputImage.Save(filePath);
        }

        public void OnClear()
        {
            _inputImage = null;
            _outputImage = null;
        }

        public Bitmap OnCopy(Action<int> reportProgress = null)
        {
            if (_inputImage == null)
                return null;
            
            Bitmap bmp = new Bitmap(_inputImage.Width, _inputImage.Height);
            int total = _inputImage.Height;
            for (int y = 0; y < _inputImage.Height; y++)
            {
                for (int x = 0; x < _inputImage.Width; x++)
                {
                    System.Drawing.Color pixel = _inputImage.GetPixel(x, y);
                    bmp.SetPixel(x, y, pixel);
                }
                reportProgress?.Invoke((int)((y + 1) * 100.0 / total));
            }

            SetOutput(bmp);
            return _outputImage;
        }

        public Bitmap OnInvert(Action<int> reportProgress = null)
        {
            if (_inputImage == null)
                return null;

            Bitmap bmp = new Bitmap(_inputImage.Width, _inputImage.Height);
            int total = _inputImage.Height;
            for (int y = 0; y < _inputImage.Height; y++)
            {
                for (int x = 0; x < _inputImage.Width; x++)
                {
                    System.Drawing.Color pixel = _inputImage.GetPixel(x, y);
                    int r = 255 - pixel.R;
                    int g = 255 - pixel.G;
                    int b = 255 - pixel.B;
                    bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(r, g, b));
                }
                reportProgress?.Invoke((int)((y + 1) * 100.0 / total));
            }

            SetOutput(bmp);
            return _outputImage;
        }

        public Bitmap OnGrayScale(Action<int> reportProgress = null)
        {
            if (_inputImage == null)
                return null;

            Bitmap bmp = new Bitmap(_inputImage.Width, _inputImage.Height);
            int total = _inputImage.Height;
            for (int y = 0; y < _inputImage.Height; y++)
            {
                for (int x = 0; x < _inputImage.Width; x++)
                {
                    System.Drawing.Color pixel = _inputImage.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(gray, gray, gray));
                }
                reportProgress?.Invoke((int)((y + 1) * 100.0 / total));
            }

            SetOutput(bmp);
            return _outputImage;
        }
        
        public Bitmap OnSepia(Action<int> reportProgress = null)
        {
            if (_inputImage == null)
                return null;

            Bitmap bmp = new Bitmap(_inputImage.Width, _inputImage.Height);
            int total = _inputImage.Height;
            for (int y = 0; y < _inputImage.Height; y++)
            {
                for (int x = 0; x < _inputImage.Width; x++)
                {
                    System.Drawing.Color pixel = _inputImage.GetPixel(x, y);

                    int tr = (int)(0.393 * pixel.R + 0.769 * pixel.G + 0.189 * pixel.B);
                    int tg = (int)(0.349 * pixel.R + 0.686 * pixel.G + 0.168 * pixel.B);
                    int tb = (int)(0.272 * pixel.R + 0.534 * pixel.G + 0.131 * pixel.B);

                    int r = Math.Min(255, tr);
                    int g = Math.Min(255, tg);
                    int b = Math.Min(255, tb);

                    bmp.SetPixel(x, y, System.Drawing.Color.FromArgb(r, g, b));
                }
                reportProgress?.Invoke((int)((y + 1) * 100.0 / total));
            }

            SetOutput(bmp);
            return _outputImage;
        }

        /*public Bitmap OnHistogram()
        {
            if (_inputImage == null)
                return null;
            int width = 256;
            int height = 100;

            Bitmap bmp = new Bitmap(width, height);
            int[] histogram = new int[256];
            for (int y = 0; y < _inputImage.Height; y++)
            {
                for (int x = 0; x < _inputImage.Width; x++)
                {
                    System.Drawing.Color pixel = _inputImage.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    histogram[gray]++;
                }
            }
            int max = histogram.Max();
            for (int x = 0; x < width; x++)
            {
                int h = (int)((histogram[x] / (float)max) * height);
                for (int y = height - 1; y >= height - h; y--)
                {
                    bmp.SetPixel(x, y, System.Drawing.Color.Black);
                }
            }
            SetOutput(bmp);
            return _outputImage;
        }*/
        public Bitmap OnHistogram()
        {
            if (_inputImage == null)
                return null;
            int histWidth = 256;
            int histHeight = 120; // Extra space for labels

            // Create histogram image as before
            Bitmap histBmp = new Bitmap(histWidth, histHeight);
            int[] histogram = new int[256];
            for (int y = 0; y < _inputImage.Height; y++)
            {
                for (int x = 0; x < _inputImage.Width; x++)
                {
                    System.Drawing.Color pixel = _inputImage.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    histogram[gray]++;
                }
            }
            int max = histogram.Max();
            using (Graphics g = Graphics.FromImage(histBmp))
            {
                g.Clear(Color.White);

                // Draw histogram bars
                for (int x = 0; x < histWidth; x++)
                {
                    int h = (int)((histogram[x] / (float)max) * 100);
                    g.DrawLine(Pens.Black, x, histHeight - 20, x, histHeight - 20 - h);
                }

                // Draw X axis
                g.DrawLine(Pens.Black, 0, histHeight - 20, histWidth - 1, histHeight - 20);

                // Draw Y axis
                g.DrawLine(Pens.Black, 0, histHeight - 20, 0, 0);

                // Draw X axis markers and labels (0, 64, 128, 192, 255)
                int[] xLabels = { 0, 64, 128, 192, 255 };
                foreach (int label in xLabels)
                {
                    int x = label;
                    g.DrawLine(Pens.Gray, x, histHeight - 20, x, histHeight - 15);
                    g.DrawString(label.ToString(), new Font("Arial", 7), Brushes.Black, x - 10, histHeight - 15);
                }

                // Draw Y axis markers and labels (0, max/2, max)
                int[] yLabels = { 0, max / 2, max };
                for (int i = 0; i < yLabels.Length; i++)
                {
                    int y = histHeight - 20 - (int)((yLabels[i] / (float)max) * 100);
                    g.DrawLine(Pens.Gray, 0, y, 5, y);
                    g.DrawString(yLabels[i].ToString(), new Font("Arial", 7), Brushes.Black, 7, y - 7);
                }

                // Axis titles
                g.DrawString("Gray Level", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, histWidth / 2 - 30, histHeight - 10);
                g.DrawString("Frequency", new Font("Arial", 8, FontStyle.Bold), Brushes.Black, 0, 0);
            }

            // Scale the histogram image to 500x500 for the PictureBox
            Bitmap scaledBmp = new Bitmap(500, 420);
            using (Graphics g = Graphics.FromImage(scaledBmp))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.Clear(Color.White);
                g.DrawImage(histBmp, 0, 0, 500, 420);
            }

            SetOutput(scaledBmp);
            return _outputImage;
        }
    }
}
