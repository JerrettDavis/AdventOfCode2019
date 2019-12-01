using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1
{
    public class ModuleComputer
    {
        private readonly IList<int> _modules;

        public ModuleComputer(IEnumerable<int> modules)
        {
            _modules = modules.ToList();
        }
        public long ComputePartOne()
        {
            return _modules.Sum(module => (long) Math.Floor(module / 3.0) - 2);
        }

        public long ComputePartTwo()
        {
            return _modules.Sum(module =>
            {
                var weight = (int) Math.Floor(module / 3.0) - 2;
                var fuel = ComputeFuel(weight, 0);

                return weight + fuel;
            });
        }

        private static int ComputeFuel(int weight, int fuel)
        {
            while (true)
            {
                var comp = (int) Math.Floor(weight / 3.0) - 2;
                if (comp <= 0) return fuel;

                weight = comp;
                fuel += comp;
            }
        }
    }
}