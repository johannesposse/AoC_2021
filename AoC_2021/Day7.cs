using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2021
{
    class Day7
    {
        public Day7()
        {
            var input = File.ReadAllLines($"Day7.txt").ToList();
            Part1(input);
            Part2(input);
        }

        private void Part1(List<string> input)
        {
            var entries = input[0].Split(',').Select(int.Parse).ToList();
            var max = entries.Max();
            var min = entries.Min();
            var fuel = 0;
            var minFuel = int.MaxValue;


            for (int i = min; i <= max; i++)
            {
                for (int j = 0; j < entries.Count; j++)
                {
                    if (entries[j] > min)
                        fuel += entries[j] - min;
                    else
                        fuel += min - entries[j];
                }
                min++;
                if (fuel < minFuel)
                    minFuel = fuel;
                fuel = 0;
            }

            Console.WriteLine($"\nD7_P1: {minFuel}");
        }

        private void Part2(List<string> input)
        {
            var entries = input[0].Split(',').Select(int.Parse).ToList();
            var max = entries.Max();
            var min = entries.Min();
            var fuel = 0;
            var minFuel = int.MaxValue;
            var ex = 1;

            for (int i = min; i <= max; i++)
            {
                for (int j = 0; j < entries.Count; j++)
                {
                    if (entries[j] > min)
                    {
                        for (int k = min; k < entries[j]; k++)
                        {
                            fuel += ex;
                            ex++;
                        }
                    }
                    else
                    {
                        for (int l = min; l > entries[j]; l--)
                        {
                            fuel += ex;
                            ex++;
                        }
                        
                    }
                    ex = 1;
                }
                
                min++;
                if (fuel < minFuel)
                    minFuel = fuel;
                fuel = 0;
            }

            Console.WriteLine($"D7_P2: {minFuel}");
        }
    }
}
