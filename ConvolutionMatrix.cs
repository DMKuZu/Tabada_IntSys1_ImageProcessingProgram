using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace Tabada_IntSys1_ImageProcessingProgram
{
    internal class ConvolutionMatrix
    {
        public int TopLeft = 0, TopMid = 0, TopRight = 0;
        public int MidLeft = 0, Pixel = 1, MidRight = 0;
        public int BottomLeft = 0, BottomMid = 0, BottomRight = 0;
        public int Factor = 1;
        public int Offset = 0;

        public void SetBoxBlur()
        {
            TopLeft = TopMid = TopRight = MidLeft = Pixel = MidRight = BottomLeft = BottomMid = BottomRight = 1;
            Factor = 9;
            Offset = 0;
        }
        public void SetGaussianBlur()
        {
            TopLeft = 1; TopMid = 2; TopRight = 1;
            MidLeft = 2; Pixel = 4; MidRight = 2;
            BottomLeft = 1; BottomMid = 2; BottomRight = 1;
            Factor = 16;
            Offset = 0;
        }
        public void SetWeightedBlur()
        {
            TopLeft = 0; TopMid = 1; TopRight = 0;
            MidLeft = 1; Pixel = 4; MidRight = 1;
            BottomLeft = 0; BottomMid = 1; BottomRight = 0;
            Factor = 8;
            Offset = 0;
        }
        public void SetSharpen()
        {
            TopLeft = 0; TopMid = -1; TopRight = 0;
            MidLeft = -1; Pixel = 5; MidRight = -1;
            BottomLeft = 0; BottomMid = -1; BottomRight = 0;
            Factor = 1;
            Offset = 0;
        }
        public void SetUnsharpMask()
        {
            TopLeft = -1; TopMid = -1; TopRight = -1;
            MidLeft = -1; Pixel = 9; MidRight = -1;
            BottomLeft = -1; BottomMid = -1; BottomRight = -1;
            Factor = 1;
            Offset = 0;
        }
        public void SetEdgeEnhancement()
        {
            TopLeft = 0; TopMid = 1; TopRight = 0;
            MidLeft = 1; Pixel = -4; MidRight = 1;
            BottomLeft = 0; BottomMid = 1; BottomRight = 0;
            Factor = 1;
            Offset = 0;
        }
        public void SetEmboss()
        {
            TopLeft = -2; TopMid = -1; TopRight = 0;
            MidLeft = -1; Pixel = 1; MidRight = 1;
            BottomLeft = 0; BottomMid = 1; BottomRight = 2;
            Factor = 1;
            Offset = 128;
        }
        public void SetSobelHorizontal()
        {
            TopLeft = -1; TopMid = -2; TopRight = -1;
            MidLeft = 0; Pixel = 0; MidRight = 0;
            BottomLeft = 1; BottomMid = 2; BottomRight = 1;
            Factor = 1;
            Offset = 0;
        }
        public void SetSobelVertical()
        {
            TopLeft = -1; TopMid = 0; TopRight = 1;
            MidLeft = -2; Pixel = 0; MidRight = 2;
            BottomLeft = -1; BottomMid = 0; BottomRight = 1;
            Factor = 1;
            Offset = 0;
        }
        public void SetPrewittHorizontal()
        {
            TopLeft = -1; TopMid = -1; TopRight = -1;
            MidLeft = 0; Pixel = 0; MidRight = 0;
            BottomLeft = 1; BottomMid = 1; BottomRight = 1;
            Factor = 1;
            Offset = 0;
        }
        public void SetPrewittVertical()
        {
            TopLeft = -1; TopMid = 0; TopRight = 1;
            MidLeft = -1; Pixel = 0; MidRight = 1;
            BottomLeft = -1; BottomMid = 0; BottomRight = 1;
            Factor = 1;
            Offset = 0;
        }
        public void SetLaplacian()
        {
            TopLeft = 0; TopMid = -1; TopRight = 0;
            MidLeft = -1; Pixel = 4; MidRight = -1;
            BottomLeft = 0; BottomMid = -1; BottomRight = 0;
            Factor = 1;
            Offset = 0;
        }
    }
}
