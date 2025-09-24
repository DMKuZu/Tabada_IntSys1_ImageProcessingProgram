using AForge.Video;
using AForge.Video.DirectShow;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tabada_IntSys1_ImageProcessingProgram
{
    internal class VideoProcessor
    {
        private VideoCaptureDevice _vcd;
        private FilterInfoCollection _fic;
        private Bitmap _latestFrame;
        private DateTime _lastFrameTime = DateTime.MinValue;
        private readonly object _frameLock = new object();

        public event Action<Bitmap> FrameReady;

        // setup combobox with available video devices
        public VideoProcessor(ComboBox cb)
        {
            _vcd = new VideoCaptureDevice();
            _fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo dev in _fic)
            {
                cb.Items.Add(dev.Name);
                cb.SelectedIndex = 0;
            }
        }

        public void OnActivate(int selectedIndex)
        {
            OnDeactivate();
            _vcd = new VideoCaptureDevice(_fic[selectedIndex].MonikerString);

            // Try to set 30 FPS if supported
            foreach (var cap in _vcd.VideoCapabilities)
            {
                if (cap.AverageFrameRate == 30)
                {
                    _vcd.VideoResolution = cap;
                    break;
                }
            }

            _vcd.NewFrame += (s, e) =>
            {
                var now = DateTime.Now;
                if ((now - _lastFrameTime).TotalMilliseconds < 33) // ~30 FPS
                    return;
                _lastFrameTime = now;

                lock (_frameLock)
                {
                    _latestFrame?.Dispose();
                    _latestFrame = (Bitmap)e.Frame.Clone();
                    FrameReady?.Invoke((Bitmap)_latestFrame.Clone());
                }
            };
            _vcd.Start();
        }

        public void OnDeactivate()
        {
            if (_vcd != null && _vcd.IsRunning)
            {
                _vcd.SignalToStop();
                _vcd.WaitForStop();
            }
        }

        public Bitmap ToGrayscale(Bitmap src)
        {
            Bitmap bmp = new Bitmap(src.Width, src.Height);
            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color pixel = src.GetPixel(x, y);
                    int gray = (pixel.R + pixel.G + pixel.B) / 3;
                    bmp.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }
            return bmp;
        }
        public Bitmap ToInvert(Bitmap src)
        {
            Bitmap bmp = new Bitmap(src.Width, src.Height);
            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color pixel = src.GetPixel(x, y);
                    int r = 255 - pixel.R;
                    int g = 255 - pixel.G;
                    int b = 255 - pixel.B;
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return bmp;
        }
        public Bitmap ToSepia(Bitmap src)
        {
            Bitmap bmp = new Bitmap(src.Width, src.Height);
            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color pixel = src.GetPixel(x, y);
                    int tr = (int)(0.393 * pixel.R + 0.769 * pixel.G + 0.189 * pixel.B);
                    int tg = (int)(0.349 * pixel.R + 0.686 * pixel.G + 0.168 * pixel.B);
                    int tb = (int)(0.272 * pixel.R + 0.534 * pixel.G + 0.131 * pixel.B);
                    int r = Math.Min(255, tr);
                    int g = Math.Min(255, tg);
                    int b = Math.Min(255, tb);
                    bmp.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }
            return bmp;
        }
        public Bitmap ToSubtract(Bitmap src, Bitmap background = null)
        {
            // Use the same logic as SubtractProcessor.OnSubtract, but src is foreground, background is optional
            if (src == null)
                return null;

            int width = src.Width;
            int height = src.Height;
            if (background != null)
            {
                width = Math.Max(src.Width, background.Width);
                height = Math.Max(src.Height, background.Height);
            }

            Color colorToSubtract = Color.FromArgb(0, 255, 0); // green
            int greyCTS = (colorToSubtract.R + colorToSubtract.G + colorToSubtract.B) / 3;
            int threshold = 5;

            Bitmap bmp = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color fgPixel = Color.Black;
                    Color bgPixel = Color.Black;
                    if (x < src.Width && y < src.Height)
                        fgPixel = src.GetPixel(x, y);
                    if (background != null && x < background.Width && y < background.Height)
                        bgPixel = background.GetPixel(x, y);
                    int greyFG = (fgPixel.R + fgPixel.G + fgPixel.B) / 3;
                    int subtractValue = Math.Abs(greyFG - greyCTS);

                    if (x < src.Width && y < src.Height && subtractValue > threshold)
                        bmp.SetPixel(x, y, fgPixel);
                    else if (background != null && x < background.Width && y < background.Height)
                        bmp.SetPixel(x, y, bgPixel);
                    else
                        bmp.SetPixel(x, y, Color.Black);
                }
            }
            return bmp;
        }
        public Bitmap GetLatestFrame()
        {
            lock (_frameLock)
            {
                if (_latestFrame != null)
                    return (Bitmap)_latestFrame.Clone();
                return null;
            }
        }

    }
}
