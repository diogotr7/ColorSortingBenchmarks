using ColorSorting;
using Colourful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSorting.Mine;

public static class ColorSorter
{
    public static void Sort(Span<RGBColor> rgbColors, Span<RGBColor> result)
    {
        if (rgbColors.Length != result.Length)
        {
            throw new ArgumentException("Input and output arrays must be the same length");
        }

        Span<LabColor> input = stackalloc LabColor[rgbColors.Length];
        for (int i = 0; i < input.Length; i++)
        {
            input[i] = ColorConverter.RgbToLab(rgbColors[i]);
        }

        Span<bool> visited = stackalloc bool[input.Length];
        int amountVisited = 0;

        var minDistanceToBlack = double.MaxValue;
        var closestToBlack = new LabColor();
        var closestToBlackIndex = int.MaxValue;
        for (int i = 0; i < input.Length; i++)
        {
            var testColor = input[i];

            var testDistance = CIEDE2000.ComputeDifference(testColor, new LabColor());
            if (testDistance < minDistanceToBlack)
            {
                minDistanceToBlack = testDistance;
                closestToBlack = testColor;
                closestToBlackIndex = i;
            }
        }

        result[amountVisited++] = ColorConverter.LabToRgb(closestToBlack);
        visited[closestToBlackIndex] = true;

        while (amountVisited < input.Length)
        {
            LabColor nearest = new LabColor();
            double nearestDistance = double.MaxValue;
            int chosen = int.MaxValue;

            for (int i = 0; i < input.Length; i++)
            {
                //we visited this color already, skip.
                if (visited[i])
                    continue;

                var color = input[i];

                var distance = CIEDE2000.ComputeDifference(color, closestToBlack);
                if (distance < nearestDistance)
                {
                    nearest = color;
                    nearestDistance = distance;
                    chosen = i;
                }
            }
            closestToBlack = nearest;

            result[amountVisited] = ColorConverter.LabToRgb(closestToBlack);
            if (chosen != int.MaxValue)
                visited[chosen] = true;

            amountVisited++;
        }
    }
}
