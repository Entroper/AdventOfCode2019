using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    public class Problem1
    {
        public static int Part1()
        {
            var lines = File.ReadAllLines("inputs/Problem1.txt");
            var masses = lines.Select(line => int.Parse(line));

            return masses.Sum(mass => mass / 3 - 2);
        }

        public static int Part2()
        {
            var lines = File.ReadAllLines("inputs/Problem1.txt");
            var masses = lines.Select(line => int.Parse(line));

            return masses.Sum(mass => GetTotalFuel(mass));
        }
        public static int GetTotalFuel(int mass)
        {
            int total = 0;
            while (mass > 0)
            {
                mass /= 3;
                mass -= 2;
                if (mass > 0)
                    total += mass;
            }

            return total;
        }
    }
}
