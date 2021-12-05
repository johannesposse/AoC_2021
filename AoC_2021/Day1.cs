using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2021
{
    class Day1
    {
        public Day1()
        {
            var input = File.ReadAllLines($"Day1.txt").ToList();
            Part1(input);
            Part2(input);
        }

        private void Part1(List<string> input)
        {
            var entries = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                entries.Add(int.Parse(input[i]));
            }

            int count = 0;
            for (int i = 1; i < entries.Count(); i++)
            {
                if (entries[i] > entries[i - 1])
                    count++;
            }

            Console.WriteLine($"D1_P1: {count}");
        }

        private void Part2(List<string> input)
        {
            var entries = new List<int>();

            for (int i = 0; i < input.Count; i++)
            {
                entries.Add(int.Parse(input[i]));
            }

            int count = 0;
            int a = 0;
            int b = 0;

            for (int i = 0; i < entries.Count(); i++)
            {
                if (i + 2 < entries.Count())
                    a = entries[i] + entries[i + 1] + entries[i + 2];
                if (i + 3 < input.Count())
                    b = entries[i + 1] + entries[i + 2] + entries[i + 3];
                if (b > a)
                    count++;
            }
            Console.WriteLine($"D1_P2: {count}\n");

        }
    }
}
