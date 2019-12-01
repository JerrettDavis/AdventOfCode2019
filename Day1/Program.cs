using System;
using System.IO;
using Day1.Utilities;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandLineParser = new CommandLineParser();
            var options = commandLineParser.Parse(args);
            var fileData = File.ReadAllText(options.Input);
            var fileParser = new FileParser();
            var parsedData = fileParser.Parse(fileData);
            var computer = new ModuleComputer(parsedData);
            
            Console.WriteLine("Part 1 (without accounting for additional fuel): " + computer.ComputePartOne());
            Console.WriteLine("Part 2 (with additional fuel): " + computer.ComputePartTwo());
        }
    }
}