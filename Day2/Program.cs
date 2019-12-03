using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args[0];
            var fileData = File.ReadAllText(path).Split(",").Select(int.Parse).ToList();
            
            Console.WriteLine($"Part One: {ComputeIntCode(fileData.ToArray())[0]}");
            
            Console.WriteLine("What is the desired output for part 2?");
            Console.WriteLine($"Part Two: {ForceCompute(int.Parse(Console.ReadLine() ?? throw new ArgumentException()), fileData)}");
        }

        private enum Operation
        {
            Add = 1, Multiply = 2, Terminate = 99
        }

        private static int[] ComputeIntCode(int[] fileData)
        {
            var index = 0;
            while (fileData[index] != (int) Operation.Terminate)
            {
                switch ((Operation) fileData[index])
                {
                    case Operation.Add:
                        fileData[fileData[index + 3]] = fileData[fileData[index + 1]] + fileData[fileData[index + 2]];
                        index += 4;
                        break;
                    case Operation.Multiply:
                        fileData[fileData[index + 3]] = fileData[fileData[index + 1]] * fileData[fileData[index + 2]];
                        index += 4;
                        break;
                    case Operation.Terminate:
                        return fileData;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return fileData;
        }

        private static long ForceCompute(int desiredOutput, IEnumerable<int> fileData)
        {
            var initData = fileData.ToList();
            for (var noun = 0; noun <= 100; noun++)
            {
                for (var verb = 0; verb <= 100; verb++)
                {
                    var inputData = initData.ToArray();
                    inputData[1] = noun;
                    inputData[2] = verb;
                    var output = ComputeIntCode(inputData)[0];

                    if (output == desiredOutput)
                        return 100 * noun + verb;
                }
            }

            return -1;
        }
    }
}