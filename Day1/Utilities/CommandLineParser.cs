using System;
using System.Linq;

namespace Day1.Utilities
{
    public class CommandLineParser
    {
        public CommandLineOptions Parse(string[] args)
        {
            if (!args.Any(a => a.Contains("/input", StringComparison.InvariantCultureIgnoreCase)))
                throw new ArgumentException("No input parameter provided");

            var inputParam = args.First(a => a.StartsWith("/input", StringComparison.InvariantCultureIgnoreCase));
            if (inputParam.IndexOf(":", StringComparison.Ordinal) == -1)
                throw new ArgumentException("Input parameter is malformed");

            return new CommandLineOptions(inputParam.Substring(inputParam.IndexOf(":", StringComparison.Ordinal) + 1));
        }
    }
}