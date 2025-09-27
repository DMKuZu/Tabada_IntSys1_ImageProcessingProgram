using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Tabada_IntSys1_ImageProcessingProgram
{
    internal class ImageProcessor
    {
        public ImageProcessor()
        {
        }

        // COpy, Grayscale, Invert, Sepia, Subtract, Histogram
        private static Bitmap convertTo24bpppRgb(Bitmap img)
        {
            Bitmap safeBmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            using (Graphics g = Graphics.FromImage(safeBmp))
            {
                g.DrawImage(img, 0, 0, img.Width, img.Height);
            }
            return safeBmp;
        }
        public Bitmap ToCopy(Bitmap bmp)
        {
            if (bmp == null)
                throw new Exception("Image Source is not available.");
            Bitmap src = convertTo24bpppRgb(bmp);
            Bitmap clone = new Bitmap(src.Width, src.Height, PixelFormat.Format24bppRgb);
            Rectangle rect = new Rectangle(0, 0, src.Width, src.Height);
            BitmapData srcData = src.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData cloneData = clone.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            int stride = srcData.Stride;
            int height = src.Height;
            int width = src.Width;
            unsafe
            {
                byte* srcPtr = (byte*)srcData.Scan0;
                byte* clonePtr = (byte*)cloneData.Scan0;
                for (int y = 0; y < height; y++)
                {
                    byte* srcRow = srcPtr + (y * stride);
                    byte* cloneRow = clonePtr + (y * stride);
                    for (int x = 0; x < width * 3; x++)
                    {
                        cloneRow[x] = srcRow[x];
                    }
                }
            }
            src.UnlockBits(srcData);
            clone.UnlockBits(cloneData);
            return clone;
        }

        public Bitmap ToGrayScale(Bitmap bmp)
        {
            if (bmp == null)
                throw new Exception("Image Source is not available.");
            Bitmap src = convertTo24bpppRgb(bmp);
            Bitmap clone = (Bitmap)src.Clone();
            Rectangle rect = new Rectangle(0, 0, clone.Width, clone.Height);
            BitmapData bmpData = clone.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmpData.Stride;
            int height = clone.Height;
            int width = clone.Width;
            unsafe
            {
                byte* ptr = (byte*)bmpData.Scan0;
                for (int y = 0; y < height; y++)
                {
                    byte* row = ptr + (y * stride);
                    for (int x = 0; x < width * 3; x += 3)
                    {
                        byte b = row[x];
                        byte g = row[x + 1];
                        byte r = row[x + 2];

                        byte gray = (byte)((r + g + b) / 3);
                        row[x] = gray;
                        row[x + 1] = gray;
                        row[x + 2] = gray;
                    }
                }
            }
            clone.UnlockBits(bmpData);
            return clone;
        }

        public Bitmap ToInvert(Bitmap bmp)
        {
            if (bmp == null)
                throw new Exception("Image Source is not available.");
            Bitmap src = convertTo24bpppRgb(bmp);
            Bitmap clone = (Bitmap)src.Clone();
            Rectangle rect = new Rectangle(0, 0, clone.Width, clone.Height);
            BitmapData bmpData = clone.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmpData.Stride;
            int height = clone.Height;
            int width = clone.Width;
            unsafe
            {
                byte* ptr = (byte*)bmpData.Scan0;
                for (int y = 0; y < height; y++)
                {
                    byte* row = ptr + (y * stride);
                    for (int x = 0; x < width * 3; x += 3)
                    {
                        byte b = row[x];
                        byte g = row[x + 1];
                        byte r = row[x + 2];

                        row[x] = (byte)(255 - b);
                        row[x + 1] = (byte)(255 - g);
                        row[x + 2] = (byte)(255 - r);
                    }
                }
            }
            clone.UnlockBits(bmpData);
            return clone;
        }

        public Bitmap ToSepia(Bitmap bmp)
        {
            if (bmp == null)
                throw new Exception("Image Source is not available.");
            Bitmap src = convertTo24bpppRgb(bmp);
            Bitmap clone = (Bitmap)src.Clone();
            Rectangle rect = new Rectangle(0, 0, clone.Width, clone.Height);
            BitmapData bmpData = clone.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int stride = bmpData.Stride;
            int height = clone.Height;
            int width = clone.Width;
            unsafe
            {
                byte* ptr = (byte*)bmpData.Scan0;
                for (int y = 0; y < height; y++)
                {
                    byte* row = ptr + (y * stride);
                    for (int x = 0; x < width * 3; x += 3)
                    {
                        byte b = row[x];
                        byte g = row[x + 1];
                        byte r = row[x + 2];

                        int tr = (int)(0.393 * r + 0.769 * g + 0.189 * b);
                        int tg = (int)(0.349 * r + 0.686 * g + 0.168 * b);
                        int tb = (int)(0.272 * r + 0.534 * g + 0.131 * b);

                        row[x + 2] = (byte)(tr > 255 ? 255 : tr);
                        row[x + 1] = (byte)(tg > 255 ? 255 : tg);
                        row[x] = (byte)(tb > 255 ? 255 : tb);
                    }
                }
            }
            clone.UnlockBits(bmpData);
            return clone;
        }
        public Bitmap ToHistogram(Bitmap bmp)
        {
            if (bmp == null)
                throw new Exception("Image Source is not available.");
            Bitmap src = convertTo24bpppRgb(bmp);
            // Calculate histogram
            int[] histogram = new int[256];
            Rectangle origRect = new Rectangle(0, 0, src.Width, src.Height);
            BitmapData origData = src.LockBits(origRect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            int origStride = origData.Stride;

            unsafe
            {
                byte* origPtr = (byte*)origData.Scan0;
                for (int y = 0; y < src.Height; y++)
                {
                    byte* row = origPtr + (y * origStride);
                    for (int x = 0; x < src.Width * 3; x += 3)
                    {
                        byte b = row[x];
                        byte g = row[x + 1];
                        byte r = row[x + 2];
                        int gray = (r + g + b) / 3;
                        histogram[gray]++;
                    }
                }
            }
            src.UnlockBits(origData);

            // Create histogram image for 350x350 pbOutput
            int histWidth = 350;
            int histHeight = 350;
            Bitmap histBmp = new Bitmap(histWidth, histHeight, PixelFormat.Format24bppRgb);

            // Find max value for scaling
            int max = 1;
            for (int i = 0; i < 256; i++)
                if (histogram[i] > max) max = histogram[i];

            using (Graphics g = Graphics.FromImage(histBmp))
            {
                g.Clear(Color.White);
                Pen axisPen = new Pen(Color.Black, 2);
                // Draw axes
                g.DrawLine(axisPen, 40, histHeight - 40, histWidth - 20, histHeight - 40); // X axis
                g.DrawLine(axisPen, 40, histHeight - 40, 40, 20); // Y axis

                // Draw X axis labels (0, 128, 255)
                g.DrawString("0", SystemFonts.DefaultFont, Brushes.Black, 40, histHeight - 30);
                g.DrawString("128", SystemFonts.DefaultFont, Brushes.Black, 40 + ((histWidth - 60) * 128 / 255), histHeight - 30);
                g.DrawString("255", SystemFonts.DefaultFont, Brushes.Black, histWidth - 30, histHeight - 30);

                // Draw Y axis labels (0, max)
                g.DrawString("0", SystemFonts.DefaultFont, Brushes.Black, 10, histHeight - 40);
                g.DrawString(max.ToString(), SystemFonts.DefaultFont, Brushes.Black, 10, 20);

                // Draw histogram bars
                int barWidth = (histWidth - 60) / 256;
                for (int i = 0; i < 256; i++)
                {
                    int x = 40 + i * barWidth;
                    int h = (int)((histogram[i] / (float)max) * (histHeight - 60));
                    g.DrawLine(Pens.Black, x, histHeight - 40, x, histHeight - 40 - h);
                }
            }

            return histBmp;
        }

        public Bitmap ToSubtract(Bitmap front, Bitmap back)
        {
            if (front == null || back == null)
                throw new Exception("Foreground or Background image is not available.");

            Bitmap frontSrc = convertTo24bpppRgb(front);
            Bitmap backSrc = convertTo24bpppRgb(back);

            int width = Math.Min(frontSrc.Width, backSrc.Width);
            int height = Math.Min(frontSrc.Height, backSrc.Height);

            Bitmap frontClone = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Bitmap backClone = new Bitmap(width, height, PixelFormat.Format24bppRgb);

            using (Graphics g = Graphics.FromImage(frontClone))
                g.DrawImage(frontSrc, 0, 0, width, height);
            using (Graphics g = Graphics.FromImage(backClone))
                g.DrawImage(backSrc, 0, 0, width, height);

            Bitmap result = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            Rectangle rect = new Rectangle(0, 0, width, height);
            BitmapData resultData = result.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
            BitmapData frontData = frontClone.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            BitmapData backData = backClone.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);

            int stride = resultData.Stride;
            int greenGray = (0 + 255 + 0) / 3;
            int threshold = 5;

            unsafe
            {
                byte* resultPtr = (byte*)resultData.Scan0;
                byte* frontPtr = (byte*)frontData.Scan0;
                byte* backPtr = (byte*)backData.Scan0;
                for (int y = 0; y < height; y++)
                {
                    byte* resultRow = resultPtr + (y * stride);
                    byte* frontRow = frontPtr + (y * frontData.Stride);
                    byte* backRow = backPtr + (y * backData.Stride);
                    for (int x = 0; x < width * 3; x += 3)
                    {
                        int r = frontRow[x + 2];
                        int g = frontRow[x + 1];
                        int b = frontRow[x];
                        int grayFG = (r + g + b) / 3;
                        int subtractValue = Math.Abs(grayFG - greenGray);
                        if (subtractValue > threshold)
                        {
                            resultRow[x] = frontRow[x];
                            resultRow[x + 1] = frontRow[x + 1];
                            resultRow[x + 2] = frontRow[x + 2];
                        }
                        else
                        {
                            resultRow[x] = backRow[x];
                            resultRow[x + 1] = backRow[x + 1];
                            resultRow[x + 2] = backRow[x + 2];
                        }
                    }
                }
            }
            result.UnlockBits(resultData);
            frontClone.UnlockBits(frontData);
            backClone.UnlockBits(backData);
            return result;
        }
    }

}
