using System;
using System.Collections.Generic;
using System.Linq;

namespace Day1.Utilities
{
    public class FileParser
    {
        public IEnumerable<int> Parse(string fileData)
        {
            return fileData.Split("\n").Where(i => !string.IsNullOrWhiteSpace(i)).Select(i =>
            {
                if (!int.TryParse(i, out var parsed))
                {
                    throw new ArgumentException("Invalid input data");
                }
                return parsed;
            });
        }
    }
}