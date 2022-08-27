using Colourful;

namespace ColorSorting.Mine;

public static class ColorConverter
{
    public static XYZColor RgbToXyz(in RGBColor rgb)
    {
        var R = rgb.R;
        var G = rgb.G;
        var B = rgb.B;

        if (R > 0.04045)
            R = Math.Pow((R + 0.055) / 1.055, 2.4);
        else
            R /= 12.92;

        if (G > 0.04045)
            G = Math.Pow((G + 0.055) / 1.055, 2.4);
        else
            G /= 12.92;

        if (B > 0.04045)
            B = Math.Pow((B + 0.055) / 1.055, 2.4);
        else
            B /= 12.92;

        var X = R * 0.4124 + G * 0.3576 + B * 0.1805;
        var Y = R * 0.2126 + G * 0.7152 + B * 0.0722;
        var Z = R * 0.0193 + G * 0.1192 + B * 0.9505;

        return new XYZColor(X, Y, Z);
    }

    public static RGBColor XyzToRgb(in XYZColor xyz)
    {
        var R = xyz.X * 3.2406 + xyz.Y * -1.5372 + xyz.Z * -0.4986;
        var G = xyz.X * -0.9689 + xyz.Y * 1.8758 + xyz.Z * 0.0415;
        var B = xyz.X * 0.0557 + xyz.Y * -0.2040 + xyz.Z * 1.0570;

        if (R > 0.0031308)
            R = 1.055 * Math.Pow(R, 1 / 2.4) - 0.055;
        else
            R = 12.92 * R;

        if (G > 0.0031308)
            G = 1.055 * Math.Pow(G, 1 / 2.4) - 0.055;
        else
            G = 12.92 * G;

        if (B > 0.0031308)
            B = 1.055 * Math.Pow(B, 1 / 2.4) - 0.055;
        else
            B = 12.92 * B;

        return new RGBColor(R, G, B);
    }

    static readonly double LabReferenceX = Illuminants.D65.X;
    static readonly double LabReferenceY = Illuminants.D65.Y;
    static readonly double LabReferenceZ = Illuminants.D65.Z;

    public static LabColor XyzToLab(in XYZColor xyz)
    {
        double X = xyz.X / LabReferenceX;
        double Y = xyz.Y / LabReferenceY;
        double Z = xyz.Z / LabReferenceZ;

        if (X > 0.008856)
            X = Math.Pow(X, 1d / 3d);
        else
            X = 7.787 * X + 16 / 116d;

        if (Y > 0.008856)
            Y = Math.Pow(Y, 1d / 3d);
        else
            Y = 7.787 * Y + 16 / 116d;

        if (Z > 0.008856)
            Z = Math.Pow(Z, 1d / 3d);
        else
            Z = 7.787 * Z + 16 / 116d;

        var L = 116d * Y - 16d;
        var a = 500d * (X - Y);
        var b = 200d * (Y - Z);

        return new LabColor(L, a, b);
    }

    public static XYZColor LabToXyz(in LabColor lab)
    {
        const double Kappa = 24389d / 27d;
        var Y = (lab.L + 16) / 116d;
        var X = lab.a / 500d + Y;
        var Z = Y - lab.b / 200d;

        if (X > 0.206893d)
            X = Pow3(X);
        else
            X = (X - (16 / 116)) / 7.787;

        if (Y > 0.206893d)
            Y = Pow3(Y);
        else
            Y = (Y - (16 / 116)) / 7.787;

        if (Z > 0.206893d)
            Z = Pow3(Z);
        else
            Z = (Z - (16 / 116)) / 7.787;

        X *= LabReferenceX;
        Y *= LabReferenceY;
        Z *= LabReferenceZ;

        return new XYZColor(X, Y, Z);
    }

    public static LabColor RgbToLab(in RGBColor rgb)
    {
        return XyzToLab(RgbToXyz(rgb));
    }

    public static RGBColor LabToRgb(in LabColor lab)
    {
        return XyzToRgb(LabToXyz(lab));
    }

    private static double Pow3(in double x)
    {
        return x * x * x;
    }
}
