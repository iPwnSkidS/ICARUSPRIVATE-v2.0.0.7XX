using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ShitarusPrivate.ToggleSwitch
{
    public static class ImageHelper
    {
        private static float[][] _colorMatrixElements = new float[5][]
        {
            new float[5] { 0.299f, 0.299f, 0.299f, 0f, 0f },
            new float[5] { 0.587f, 0.587f, 0.587f, 0f, 0f },
            new float[5] { 0.114f, 0.114f, 0.114f, 0f, 0f },
            new float[5] { 0f, 0f, 0f, 1f, 0f },
            new float[5] { 0f, 0f, 0f, 0f, 1f }
        };

        private static ColorMatrix _grayscaleColorMatrix = new ColorMatrix(_colorMatrixElements);

        public static ImageAttributes GetGrayscaleAttributes()
        {
            ImageAttributes imageAttributes = new ImageAttributes();
            imageAttributes.SetColorMatrix(_grayscaleColorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            return imageAttributes;
        }

        public static Size RescaleImageToFit(Size imageSize, Size canvasSize)
        {
            double val = (double)canvasSize.Width / (double)imageSize.Width;
            double val2 = (double)canvasSize.Height / (double)imageSize.Height;
            double num = Math.Min(val, val2);
            int height = Convert.ToInt32((double)imageSize.Height * num);
            int width = Convert.ToInt32((double)imageSize.Width * num);
            Size result = new Size(width, height);
            if (result.Width > canvasSize.Width || result.Height > canvasSize.Height)
            {
                throw new Exception("ImageHelper.RescaleImageToFit - Resize failed!");
            }
            return result;
        }
    }
}
