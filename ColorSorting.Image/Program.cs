using SkiaSharp;
using Colourful;
using ColorSorting.Utils;
using System.Diagnostics;

namespace ColorSorting.Image
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int size = 2000;

            RGBColor[] colors = RandomColorGenerator.GetRandomRgbColors(size);
            var old = GetBitmap(colors);
            SaveImage("before.png", old);

            Mine(colors);
            Colorful(colors);
        }

        private static void Colorful(RGBColor[] colors)
        {
            var sorted = ColorSorting.Colorful.ColorSorter.Sort(colors);
            SaveImage("colorful.png", GetBitmap(sorted));
        }

        private static void Mine(RGBColor[] colors)
        {
            Span<RGBColor> sorted = stackalloc RGBColor[colors.Length];
            ColorSorting.Mine.ColorSorter.Sort(colors, sorted);
            SaveImage("mine.png", GetBitmap(sorted.ToArray()));
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