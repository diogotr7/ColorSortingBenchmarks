using Colourful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSorting.Colorful
{
    public static class ColorConverter
    {
        private static readonly IColorConverter<RGBColor, XYZColor> _rgbToXyz = new ConverterBuilder().FromRGB(RGBWorkingSpaces.sRGB).ToXYZ(Illuminants.D65).Build();
        private static readonly IColorConverter<XYZColor, RGBColor> _xyzToRgb = new ConverterBuilder().FromXYZ(Illuminants.D65).ToRGB(RGBWorkingSpaces.sRGB).Build();
        private static readonly IColorConverter<XYZColor, LabColor> _xyzToLab = new ConverterBuilder().FromXYZ(Illuminants.D65).ToLab(Illuminants.D65).Build();
        private static readonly IColorConverter<LabColor, XYZColor> _labToXyz = new ConverterBuilder().FromLab(Illuminants.D65).ToXYZ(Illuminants.D65).Build();
        private static readonly IColorConverter<RGBColor, LabColor> _rgbToLab = new ConverterBuilder().FromRGB(RGBWorkingSpaces.sRGB).ToLab(Illuminants.D65).Build();
        private static readonly IColorConverter<LabColor, RGBColor> _labToRgb = new ConverterBuilder().FromLab(Illuminants.D65).ToRGB(RGBWorkingSpaces.sRGB).Build();

        public static XYZColor RgbToXyz(in RGBColor rgb)
        {
            return _rgbToXyz.Convert(rgb);
        }

        public static RGBColor XyzToRgb(in XYZColor xyz)
        {
            return _xyzToRgb.Convert(xyz);
        }

        public static LabColor XyzToLab(in XYZColor xyz)
        {
            return _xyzToLab.Convert(xyz);
        }

        public static XYZColor LabToXyz(in LabColor lab)
        {
            return _labToXyz.Convert(lab);
        }

        public static LabColor RgbToLab(in RGBColor rgb)
        {
            return _rgbToLab.Convert(rgb);
        }

        public static RGBColor LabToRgb(in LabColor lab)
        {
            return _labToRgb.Convert(lab);
        }
    }
}
