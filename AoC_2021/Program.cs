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
            var input = File.ReadAllLines($"Day{DateTime.Now.Day}.txt").Select(int.Parse).ToList();

            int One() => Day_1_Part_1(input);
            int Two() => Day_1_Part_2(input);

            Console.WriteLine($"Part One: {One()}\nPart Two: {Two()}");
            Console.ReadLine();
        }

        public static int Day_2_Part_1(List<int> input)
        {
            int count = 0;

            return count;
        }

        public static int Day_2_Part_2(List<int> input)
        {
            int count = 0;

            return count;
        }

        public static int Day_1_Part_1(List<int> input)
        {
            int count = 0;
            for (int i = 1; i < input.Count(); i++)
            {
                if (input[i] > input[i - 1])
                    count++;
            }
            return count;
        }

        public static int Day_1_Part_2(List<int> input)
        {
            int count = 0;
            int a = 0;
            int b = 0;

            for (int i = 0; i < input.Count(); i++)
            {
                if (i + 2 < input.Count())
                    a = input[i] + input[i + 1] + input[i + 2];
                if (i + 3 < input.Count())
                    b = input[i + 1] + input[i + 2] + input[i + 3];
                if (b > a)
                    count++;
            }
            return count;
        }
    }
}
