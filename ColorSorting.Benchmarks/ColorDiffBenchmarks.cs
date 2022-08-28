using BenchmarkDotNet.Attributes;
using Colourful;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSorting.Benchmarks;

[ShortRunJob]
[MemoryDiagnoser]
public class ColorDiffBenchmarks
{
    [ParamsSource(nameof(LeftSource))]
    public LabColor Left { get; set; }

    [ParamsSource(nameof(RightSource))]
    public LabColor Right { get; set; }

    public IEnumerable<LabColor> LeftSource { get; } = new LabColor[]
    {
    Mine.ColorConverter.RgbToLab(new RGBColor(1,0,0)),
    Mine.ColorConverter.RgbToLab(new RGBColor(0,1,0)),
    };

    public IEnumerable<LabColor> RightSource { get; } = new LabColor[]
    {
    Mine.ColorConverter.RgbToLab(new RGBColor(1,1,0)),
    Mine.ColorConverter.RgbToLab(new RGBColor(0,1,1)),
    };

    [Benchmark]
    public double DiffMine()
    {
        return Mine.CIEDE2000.ComputeDifference(Left, Right);
    }

    private static readonly CIEDE2000ColorDifference _diff = new();

    [Benchmark]
    public double DiffColorful()
    {
        return _diff.ComputeDifference(Left, Right);
    }
}
