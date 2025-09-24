using System;
using System.Drawing;

namespace Tabada_IntSys1_ImageProcessingProgram
{
    internal class SubtractProcessor
    {
        private Bitmap _foreground, _background, _outputImage;
        public SubtractProcessor()
        {
            _foreground = null;
            _background = null;
            _outputImage = null;
        }
        
        private void SetForeground(Bitmap bmp)
        {
            _foreground = bmp;
        }
        private void SetBackground(Bitmap bmp)
        {
            _background = bmp;
        }
        private void SetOutput(Bitmap bmp)
        {
            _outputImage = bmp;
        }

        public Bitmap OnLoadForeground(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return null;

            SetForeground(new Bitmap(filePath));
            return _foreground;
        }
        public Bitmap OnLoadBackground(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return null;

            SetBackground(new Bitmap(filePath));
            return _background;
        }
        public bool isOutputNull()
        {
            return _outputImage == null;
        }
        public Bitmap OnSaveImage(string filePath)
        {
            if (string.IsNullOrEmpty(filePath) || _outputImage == null)
                return null;

            _outputImage.Save(filePath);
            return _outputImage;
        }
        public void OnClear()
        {
            _foreground = null;
            _background = null;
            _outputImage = null;
        }

        public Bitmap OnSubtract(Action<int> reportProgress = null)
        {
            if (_foreground == null || _background == null)
                return null;

            int width = Math.Max(_foreground.Width, _background.Width);
            int height = Math.Max(_foreground.Height, _background.Height);

            Color colorToSubtract = Color.FromArgb(0,255,0); // green 
            int greyCTS = (colorToSubtract.R + colorToSubtract.G + colorToSubtract.B) / 3;
            int threshold = 5; // Adjust this threshold as needed

            Bitmap bmp = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color fgPixel = Color.Black;
                    Color bgPixel = Color.Black;
                    if (x < _foreground.Width && y < _foreground.Height)
                        fgPixel = _foreground.GetPixel(x, y);
                    if (x < _background.Width && y < _background.Height)
                        bgPixel = _background.GetPixel(x, y);
                    int greyFG = (fgPixel.R + fgPixel.G + fgPixel.B) / 3;
                    int subtractValue = Math.Abs(greyFG - greyCTS);

                    if(x < _foreground.Width && y < _foreground.Height && subtractValue > threshold)
                        bmp.SetPixel(x, y, fgPixel);
                    else if(x < _background.Width && y < _background.Height)
                        bmp.SetPixel(x, y, bgPixel);
                    else
                        bmp.SetPixel(x, y, Color.Black);
                }
                reportProgress?.Invoke((int)((y + 1) * 100.0 / height));
            }

            SetOutput(bmp);
            return _outputImage;
        }
    }
}
