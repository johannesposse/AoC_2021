using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AoC_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "Day1.txt";
            var input = File.ReadAllLines(filePath).ToList();
            var entries = new List<int>();

            for (int i = 0; i < input.Count; i++)
                entries.Add(int.Parse(input[i]));

            DayOnePartOne(entries);
            DayOnePartTwo(entries);
            DayTwoPartOne(entries);
            DayTwoPartTwo(entries);

            Console.ReadLine();
        }

        public static void DayTwoPartOne(List<int> entries)
        {
            int count = 0;

            Console.WriteLine(count);
        }

        public static void DayTwoPartTwo(List<int> entries)
        {
            int count = 0;

            Console.WriteLine(count);
        }

        public static void DayOnePartOne(List<int> entries)
        {
            int count = 0;
            for (int i = 1; i < entries.Count(); i++)
            {
                if (entries[i] > entries[i - 1])
                    count++;
            }
            Console.WriteLine(count);
        }

        public static void DayOnePartTwo(List<int> entries)
        {
            int count = 0;
            int a = 0;
            int b = 0;

            for (int i = 0; i < entries.Count(); i++)
            {
                if (i + 2 < entries.Count())
                    a = entries[i] + entries[i + 1] + entries[i + 2];
                if (i + 3 < entries.Count())
                    b = entries[i + 1] + entries[i + 2] + entries[i + 3];
                if (b > a)
                    count++;
            }
            Console.WriteLine(count);
        }
    }
}
