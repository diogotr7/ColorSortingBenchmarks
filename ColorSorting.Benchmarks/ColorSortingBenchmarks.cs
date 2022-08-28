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
    private readonly RGBColor[] _colors = RandomColorGenerator.GetRandomRgbColors(1000);

    [Benchmark]
    public void Mine()
    {
        Span<RGBColor> result = stackalloc RGBColor[1000];
        ColorSorting.Mine.ColorSorter.Sort(_colors, result);
    }

    [Benchmark]
    public void Colorful()
    {
        var sorted = ColorSorting.Colorful.ColorSorter.Sort(_colors);
    }
}
