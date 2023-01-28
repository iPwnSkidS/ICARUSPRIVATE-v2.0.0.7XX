using System.Drawing;

namespace ShitarusPrivate.JCS
{
    public static class GraphicsExtensionMethods
    {
        public static Color ToGrayScale(this Color originalColor)
        {
            if (originalColor.Equals(Color.Transparent))
            {
                return originalColor;
            }
            int num = (int)((double)(int)originalColor.R * 0.299 + (double)(int)originalColor.G * 0.587 + (double)(int)originalColor.B * 0.114);
            return Color.FromArgb(num, num, num);
        }
    }
}
