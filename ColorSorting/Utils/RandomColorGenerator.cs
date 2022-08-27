using Colourful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSorting.Utils
{
    public static class RandomColorGenerator
    {
        private static readonly Random _random = new();

        public static RGBColor[] GetRandomRgbColors(int length)
        {
            var ret = new RGBColor[length];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = new RGBColor(_random.NextDouble(), _random.NextDouble(), _random.NextDouble());
            }

            return ret;
        }

        public static XYZColor[] GetRandomXyzColors(int length)
        {
            var ret = new XYZColor[length];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = new XYZColor(_random.NextDouble(), _random.NextDouble(), _random.NextDouble());
            }

            return ret;
        }

        public static LabColor[] GetRandomLabColors(int length)
        {
            var ret = new LabColor[length];

            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = new LabColor(_random.Next(100), _random.Next(200) - 100, _random.Next(200) - 100);
            }

            return ret;
        }
    }
}
