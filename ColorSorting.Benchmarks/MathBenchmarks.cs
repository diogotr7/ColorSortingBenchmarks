using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ColorSorting.Benchmarks
{
    public class MathBenchmarks
    {
        private readonly float radF = 0;
        private readonly float degF = 0;

        private readonly double radD = 0;
        private readonly double degD = 0;

        [Benchmark]
        public float RadianToDegree()
        {
            const float oneEightyOverPi = 57.2957795131f;
            return radF * oneEightyOverPi;
        }
        [Benchmark]
        public float DegreeToRadian()
        {
            const float piOverOneEighty = 0.01745329251f;
            return degF * piOverOneEighty;
        }
        [Benchmark]
        public float NormalizeDegree()
        {
            return (degF + 360f) % 360f;
        }

        private const float TwoPIF= 2 * MathF.PI;
        [Benchmark]
        public float RadianToDegreeOld()
        {
            var deg = 360 * (radF / TwoPIF);
            return deg;
        }
        [Benchmark]
        public float DegreeToRadianOld()
        {
            var rad = TwoPIF * (degF / 360f);
            return rad;
        }
        [Benchmark]
        public float NormalizeDegreeOld()
        {
            var d = degF % 360f;
            return d >= 0 ? d : d + 360f;
        }

        [Benchmark]
        public double RadianToDegreeDouble()
        {
            const double oneEightyOverPi = 57.2957795131f;
            return radD * oneEightyOverPi;
        }
        [Benchmark]
        public double DegreeToRadianDouble()
        {
            const double piOverOneEighty = 0.01745329251f;
            return degD * piOverOneEighty;
        }
        [Benchmark]
        public double NormalizeDegreeDouble()
        {
            return (degD + 360f) % 360f;
        }

        private const double TwoPI = 2 * Math.PI;
        [Benchmark]
        public double RadianToDegreeDoubleOld()
        {
            var deg = 360 * (radD / TwoPI);
            return deg;
        }
        [Benchmark]
        public double DegreeToRadianDoubleOld()
        {
            var rad = TwoPI * (degD / 360f);
            return rad;
        }
        [Benchmark]
        public double NormalizeDegreeDoubleOld()
        {
            var d = degD % 360f;
            return d >= 0 ? d : d + 360f;
        }
    }
}
