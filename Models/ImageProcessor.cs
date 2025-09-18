using System.IO;
using System.Linq;
using Avalonia.Media.Imaging;
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
        
        
        public void DrawHistogram(int width = 350, int height = 200)
        {
            if (_original == null) return;
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

            var info = new SKImageInfo(width, height);
            using var surface = SKSurface.Create(info);
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.White);

            int max = hist.Max();
            float barWidth = (float)(width - 40) / hist.Length; // leave margin for axis
            float offsetX = 30;
            float offsetY = 20;

            // gradient-like colors for bars
            using var barPaint = new SKPaint
            {
                IsAntialias = false,
                Style = SKPaintStyle.Fill
            };

            using var axisPaint = new SKPaint
            {
                Color = SKColors.Black,
                StrokeWidth = 1.5f,
                IsAntialias = true,
                Style = SKPaintStyle.Stroke
            };

            using var textPaint = new SKPaint
            {
                Color = SKColors.Black,
                TextSize = 9,  // smaller font
                IsAntialias = true
            };

            // Draw axes
            canvas.DrawLine(offsetX, 0, offsetX, height - offsetY, axisPaint);
            canvas.DrawLine(offsetX, height - offsetY, width, height - offsetY, axisPaint);

            // Draw histogram bars with varying colors
            for (int i = 0; i < hist.Length; i++)
            {
                float h = (float)hist[i] / max * (height - offsetY - 10);

                // choose color: blue → green → red gradient
                barPaint.Color = new SKColor(
                    (byte)(i),              // red grows with bin
                    (byte)(255 - i),        // green decreases
                    (byte)(128 + (i / 2))); // blue shifts

                canvas.DrawRect(offsetX + i * barWidth, (height - offsetY) - h, barWidth, h, barPaint);
            }

            // X-axis labels (0, 64, 128, 192, 255)
            int[] xLabels = { 0, 64, 128, 192, 255 };
            foreach (var label in xLabels)
            {
                float x = offsetX + label * barWidth;
                canvas.DrawText(label.ToString(), x - 8, height - 5, textPaint);
            }

            // Y-axis max label
            canvas.DrawText(max.ToString(), 2, 12, textPaint);

            using var image = surface.Snapshot();
            _current = SKBitmap.FromImage(image);
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
