using System.IO;
using SkiaSharp;

namespace Tabada_ImageProcessing_Program.Models;
    public class ImageProcessor
    {
        private SKBitmap? _current; // this is the output
        private SKBitmap? _original;

        public SKBitmap? LoadImage(string path)
        {
            using var stream = File.OpenRead(path);
            _original = SKBitmap.Decode(stream);
            return _original;
        }

        public void Reset()
        {
            _current = null;
            _original = null;
        }

        public SKBitmap? GetImage() => _current;

        public void SaveImage(string path)
        {
            if (_current == null) return;
            using var image = SKImage.FromBitmap(_current);
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using var stream = File.OpenWrite(path);
            data.SaveTo(stream);
        }

        public void Copy()
        {
            _current = _original;
        }

        public void Grayscale()
        {
            if (_original == null) return;

            var bmp = new SKBitmap(_original.Width, _original.Height);
            using var canvas = new SKCanvas(bmp);
            var paint = new SKPaint
            {
                ColorFilter = SKColorFilter.CreateColorMatrix(new float[]
                {
                    0.299f, 0.587f, 0.114f, 0, 0, // Red
                    0.299f, 0.587f, 0.114f, 0, 0, // Green
                    0.299f, 0.587f, 0.114f, 0, 0, // Blue
                    0,      0,      0,      1, 0  // Alpha
                })
            };
            canvas.DrawBitmap(_original, 0, 0, paint);
            canvas.Flush();
            _current = bmp;
        }

        public int[] Histogram()
        {
            if (_original == null) return new int[256];
            var hist = new int[256];
            for (int y = 0; y < _original.Height; y++)
            {
                for (int x = 0; x < _original.Width; x++)
                {
                    var color = _original.GetPixel(x, y);
                    int gray = (color.Red + color.Green + color.Blue) / 3;
                    hist[gray]++;
                }
            }
            return hist;
        }

        public void Sepia()
        {
            if (_original == null) return;

            var bmp = new SKBitmap(_original.Width, _original.Height);
            using var canvas = new SKCanvas(bmp);
            var paint = new SKPaint
            {
                ColorFilter = SKColorFilter.CreateColorMatrix(new float[]
                {
                    0.393f, 0.769f, 0.189f, 0, 0,
                    0.349f, 0.686f, 0.168f, 0, 0,
                    0.272f, 0.534f, 0.131f, 0, 0,
                    0,      0,      0,      1, 0
                })
            };
            canvas.DrawBitmap(_original, 0, 0, paint);
            canvas.Flush();
            _current = bmp;
        }

        public void Invert()
        {
            if (_original == null) return;

            var bmp = new SKBitmap(_original.Width, _original.Height);
            for (int y = 0; y < _original.Height; y++)
            {
                for (int x = 0; x < _original.Width; x++)
                {
                    var color = _original.GetPixel(x, y);
                    var inverted = new SKColor(
                        (byte)(255 - color.Red),
                        (byte)(255 - color.Green),
                        (byte)(255 - color.Blue),
                        color.Alpha
                    );
                    bmp.SetPixel(x, y, inverted);
                }
            }
            _current = bmp;
        }
    }
