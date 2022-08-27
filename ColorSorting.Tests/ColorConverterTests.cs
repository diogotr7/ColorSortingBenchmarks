using ColorSorting.Utils;
using Colourful;
using Xunit;

namespace ColorSorting.Tests
{
    public class ColorConverterTests
    {
        //meh, good enough
        const double tolerance = 0.1;
        const int size = 100;

        [Fact]
        public void EnsureThatRgbToXyzIsWithinToleranceOfColorful()
        {
            double highestDifference = 0;
            RGBColor[] colors = RandomColorGenerator.GetRandomRgbColors(size);

            for (int i = 0; i < colors.Length; i++)
            {
                var color = colors[i];
                var xyz1 = Mine.ColorConverter.RgbToXyz(color);
                var xyz2 = Colorful.ColorConverter.RgbToXyz(color);

                void UpdateDiff(double diff)
                {
                    if (diff > highestDifference)
                        highestDifference = diff;
                }

                var xdiff = Math.Abs(xyz1.X - xyz2.X);
                var ydiff = Math.Abs(xyz1.Y - xyz2.Y);
                var zdiff = Math.Abs(xyz1.Z - xyz2.Z);

                UpdateDiff(xdiff);
                UpdateDiff(ydiff);
                UpdateDiff(zdiff);
            }

            Assert.InRange(highestDifference, 0, tolerance);
        }

        [Fact]
        public void EnsureThatXyzToRgbIsWithinToleranceOfColorful()
        {
            double highestDifference = 0;
            XYZColor[] colors = RandomColorGenerator.GetRandomXyzColors(size);

            for (int i = 0; i < colors.Length; i++)
            {
                var color = colors[i];
                var rgb1 = Mine.ColorConverter.XyzToRgb(color);
                var rgb2 = Colorful.ColorConverter.XyzToRgb(color);

                void UpdateDiff(double diff)
                {
                    if (diff > highestDifference)
                        highestDifference = diff;
                }

                var rdiff = Math.Abs(rgb1.R - rgb2.R);
                var gdiff = Math.Abs(rgb1.G - rgb2.G);
                var bdiff = Math.Abs(rgb1.B - rgb2.B);

                UpdateDiff(rdiff);
                UpdateDiff(gdiff);
                UpdateDiff(bdiff);
            }
            
            Assert.InRange(highestDifference, 0, tolerance);
        }

        [Fact]
        public void EnsureThatXyzToLabIsWithinToleranceOfColorful()
        {
            double highestDifference = 0;
            XYZColor[] colors = RandomColorGenerator.GetRandomXyzColors(size);

            for (int i = 0; i < colors.Length; i++)
            {
                var color = colors[i];
                var lab1 = Mine.ColorConverter.XyzToLab(color);
                var lab2 = Colorful.ColorConverter.XyzToLab(color);

                void UpdateDiff(double diff)
                {
                    if (diff > highestDifference)
                        highestDifference = diff;
                }

                var rdiff = Math.Abs(lab1.L - lab2.L);
                var gdiff = Math.Abs(lab1.a - lab2.a);
                var bdiff = Math.Abs(lab1.b - lab2.b);

                UpdateDiff(rdiff);
                UpdateDiff(gdiff);
                UpdateDiff(bdiff);
            }

            Assert.InRange(highestDifference, 0, tolerance);
        }

        [Fact]
        public void EnsureThatLabToXyzIsWithinToleranceOfColorful()
        {
            double highestDifference = 0;
            LabColor[] colors = RandomColorGenerator.GetRandomLabColors(size);

            for (int i = 0; i < colors.Length; i++)
            {
                var color = colors[i];
                var lab1 = Mine.ColorConverter.LabToXyz(color);
                var lab2 = Colorful.ColorConverter.LabToXyz(color);
                
                void UpdateDiff(double diff)
                {
                    if (diff > highestDifference)
                        highestDifference = diff;
                }

                var rdiff = Math.Abs(lab1.X - lab2.X);
                var gdiff = Math.Abs(lab1.Y - lab2.Y);
                var bdiff = Math.Abs(lab1.Z - lab2.Z);

                UpdateDiff(rdiff);
                UpdateDiff(gdiff);
                UpdateDiff(bdiff);
            }

            Assert.InRange(highestDifference, 0, tolerance);
        }
    }
}