using Colourful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSorting.Colorful;

public static class ColorSorter
{
    private static readonly CIEDE2000ColorDifference _difference = new();

    public static RGBColor[] Sort(RGBColor[] swatch)
    {
        var sorted = new List<RGBColor>(swatch.Length);
        var unvisited = new List<RGBColor>(swatch.Length);

        var current = swatch.MinBy(sel => _difference.ComputeDifference(ColorConverter.RgbToLab(sel), new LabColor()));
        unvisited.AddRange(swatch);
        unvisited.Remove(current);
        sorted.Add(current);

        while (unvisited.Count > 0)
        {
            var nearest = unvisited[0];
            var nearestDistance = double.MaxValue;
            foreach (var color in unvisited)
            {
                var distance = _difference.ComputeDifference(ColorConverter.RgbToLab(color), ColorConverter.RgbToLab(current));
                if (distance < nearestDistance)
                {
                    nearest = color;
                    nearestDistance = distance;
                }
            }
            current = nearest;
            unvisited.Remove(current);
            sorted.Add(current);
        }
        return sorted.ToArray();
    }
}
