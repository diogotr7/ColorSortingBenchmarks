using SkiaSharp;
using Colourful;
using ColorSorting.Utils;

namespace ColorSorting.Image
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int size = 500;
            RGBColor[] colors = RandomColorGenerator.GetRandomRgbColors(size);
            var old = GetBitmap(colors);
            SaveImage("before.png", old);

            Span<RGBColor> sorted = stackalloc RGBColor[size];
            Mine.ColorSorter.Sort(colors, sorted);
            var a = GetBitmap(sorted.ToArray());
            
            SaveImage("after.png", a);
        }

        private static SKBitmap GetBitmap(RGBColor[] colors)
        {
            SKBitmap bitmap = new SKBitmap(colors.Length, colors.Length / 4);

            for (int col = 0; col < bitmap.Width; col++)
            {
                var colColor = colors[col];
                var skColor = new SKColor(
                    (byte)(colColor.R * 255d),
                    (byte)(colColor.G * 255d),
                    (byte)(colColor.B * 255d));
                for (int row = 0; row < bitmap.Height; row++)
                {
                    bitmap.SetPixel(col, row, skColor);
                }
            }

            return bitmap;
        }

        private static void SaveImage(string path, SKBitmap bitmap)
        {
            using (Stream s = File.Open(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                SKData d = SKImage.FromBitmap(bitmap).Encode(SKEncodedImageFormat.Png, 100);
                d.SaveTo(s);
            }
        }
    }
}