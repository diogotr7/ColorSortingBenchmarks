using BenchmarkDotNet.Attributes;
using ColorSorting.Utils;
using Colourful;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSorting.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser]
public class ColorSortingBenchmarks
{
    //private static readonly IColorConverter<RGBColor, LabColor> _rgbToLab = new ConverterBuilder().FromRGB().ToLab().Build();
    //private static readonly IColorConverter<LabColor, RGBColor> _labToRgb = new ConverterBuilder().FromLab().ToRGB().Build();
    //private static readonly CIEDE2000ColorDifference _difference = new ();
    //private static readonly RGBColor[] span = RandomColorGenerator.GetRandomRgbColors(1000);

    //[Benchmark]
    //public void BenchNew()
    //{
    //    Span<RGBColor> sorted = stackalloc RGBColor[1000];
    //    ColorSorter.Sort(span, sorted);

    //}

    //public void SortNew(in Span<LabColor> result, in Span<LabColor> input)
    //{
    //    Span<bool> visited = stackalloc bool[input.Length];
    //    int amountVisited = 0;

    //    var minDistanceToBlack = double.MaxValue;
    //    var closestToBlack = new LabColor();
    //    var closestToBlackIndex = int.MaxValue;
    //    for (int i = 0; i < input.Length; i++)
    //    {
    //        var testColor = input[i];

    //        var testDistance = GetDistance(testColor, new LabColor());
    //        if (testDistance < minDistanceToBlack)
    //        {
    //            minDistanceToBlack = testDistance;
    //            closestToBlack = testColor;
    //            closestToBlackIndex = i;
    //        }
    //    }

    //    result[amountVisited++] = closestToBlack;
    //    visited[closestToBlackIndex] = true;

    //    while (amountVisited < input.Length)
    //    {
    //        LabColor nearest = new LabColor();
    //        double nearestDistance = double.MaxValue;
    //        int chosen = int.MaxValue;

    //        for (int i = 0; i < input.Length; i++)
    //        {
    //            //we visited this color already, skip.
    //            if (visited[i])
    //                continue;

    //            var color = input[i];

    //            var distance = GetDistance(color, closestToBlack);
    //            if (distance < nearestDistance)
    //            {
    //                nearest = color;
    //                nearestDistance = distance;
    //                chosen = i;
    //            }
    //        }
    //        closestToBlack = nearest;

    //        result[amountVisited] = closestToBlack;
    //        if (chosen != int.MaxValue)
    //            visited[chosen] = true;

    //        amountVisited++;
    //    }
    //}

    //[Benchmark]
    //public void BenchOld()
    //{

    //    var sorted = SortOld(span.ToArray());

    //    int i = sorted.Length;
    //}

    //private RGBColor[] SortOld(RGBColor[] swatch)
    //{
    //    var sorted = new List<RGBColor>(swatch.Length);
    //    var unvisited = new List<RGBColor>(swatch.Length);

    //    var current = swatch[0];
    //    unvisited.AddRange(swatch);
    //    unvisited.Remove(current);
    //    sorted.Add(current);

    //    while (unvisited.Count > 0)
    //    {
    //        var nearest = unvisited[0];
    //        var nearestDistance = double.MaxValue;
    //        foreach (var color in unvisited)
    //        {
    //            var distance = GetDistance(color, current);
    //            if (distance < nearestDistance)
    //            {
    //                nearest = color;
    //                nearestDistance = distance;
    //            }
    //        }
    //        current = nearest;
    //        unvisited.Remove(current);
    //        sorted.Add(current);
    //    }
    //    return sorted.ToArray();
    //}

    //private static double GetDistance(RGBColor color, RGBColor current)
    //{
    //    //return _difference.ComputeDifference(_rgbToLab.Convert(color), _rgbToLab.Convert(current));
    //    return _difference.ComputeDifference(ColorConverter.RgbToLab(color), ColorConverter.RgbToLab(current));
    //}

    //private static double GetDistance(in LabColor a, in LabColor b)
    //{
    //    return _difference.ComputeDifference(a, b);
    //}
}
