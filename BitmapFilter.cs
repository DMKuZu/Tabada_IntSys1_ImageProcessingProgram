using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Tabada_IntSys1_ImageProcessingProgram
{
    internal static class BitmapFilter
    {
        public static Bitmap Conv3x3(Bitmap b, ConvolutionMatrix m)
        {
            if (m.Factor == 0)
                throw new Exception("ConvolutionMatrix: Factor can not be zero");

            Bitmap bSrc = (Bitmap)b.Clone();
            Bitmap bResult = (Bitmap)b.Clone();

            BitmapData bmData = bResult.LockBits(new Rectangle(0, 0, bResult.Width, bResult.Height),
                                ImageLockMode.ReadWrite,
                                PixelFormat.Format24bppRgb);
            BitmapData bmSrc = bSrc.LockBits(new Rectangle(0, 0, bSrc.Width, bSrc.Height),
                               ImageLockMode.ReadWrite,
                               PixelFormat.Format24bppRgb);

            int stride = bmData.Stride;
            int stride2 = stride * 2;

            System.IntPtr Scan0 = bmData.Scan0;
            System.IntPtr SrcScan0 = bmSrc.Scan0;

            unsafe
            {
                byte* p = (byte*)(void*)Scan0;
                byte* pSrc = (byte*)(void*)SrcScan0;
                int nOffset = stride - bResult.Width * 3;
                int nWidth = bResult.Width - 2;
                int nHeight = bResult.Height - 2;
                int nPixel;
                for (int y = 0; y < nHeight; ++y)
                {
                    for (int x = 0; x < nWidth; ++x)
                    {
                        nPixel = ((((pSrc[2] * m.TopLeft) +
                            (pSrc[5] * m.TopMid) +
                            (pSrc[8] * m.TopRight) +
                            (pSrc[2 + stride] * m.MidLeft) +
                            (pSrc[5 + stride] * m.Pixel) +
                            (pSrc[8 + stride] * m.MidRight) +
                            (pSrc[2 + stride2] * m.BottomLeft) +
                            (pSrc[5 + stride2] * m.BottomMid) +
                            (pSrc[8 + stride2] * m.BottomRight))
                            / m.Factor) + m.Offset);
                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[5 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[1] * m.TopLeft) +
                            (pSrc[4] * m.TopMid) +
                            (pSrc[7] * m.TopRight) +
                            (pSrc[1 + stride] * m.MidLeft) +
                            (pSrc[4 + stride] * m.Pixel) +
                            (pSrc[7 + stride] * m.MidRight) +
                            (pSrc[1 + stride2] * m.BottomLeft) +
                            (pSrc[4 + stride2] * m.BottomMid) +
                            (pSrc[7 + stride2] * m.BottomRight))
                            / m.Factor) + m.Offset);
                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[4 + stride] = (byte)nPixel;

                        nPixel = ((((pSrc[0] * m.TopLeft) +
                                   (pSrc[3] * m.TopMid) +
                                   (pSrc[6] * m.TopRight) +
                                   (pSrc[0 + stride] * m.MidLeft) +
                                   (pSrc[3 + stride] * m.Pixel) +
                                   (pSrc[6 + stride] * m.MidRight) +
                                   (pSrc[0 + stride2] * m.BottomLeft) +
                                   (pSrc[3 + stride2] * m.BottomMid) +
                                   (pSrc[6 + stride2] * m.BottomRight))
                        / m.Factor) + m.Offset);
                        if (nPixel < 0) nPixel = 0;
                        if (nPixel > 255) nPixel = 255;
                        p[3 + stride] = (byte)nPixel;

                        p += 3;
                        pSrc += 3;
                    }
                    p += nOffset;
                    pSrc += nOffset;
                }
            }
            bResult.UnlockBits(bmData);
            bSrc.UnlockBits(bmSrc);
            return bResult;
        }
    }
}
