using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2021
{
    class Day2
    {

        public Day2()
        {
            var input = File.ReadAllLines($"Day2.txt").ToList();
            Part1(input);
            Part2(input);
        }
        private void Part1(List<string> input)
        {
            int forward = 0;
            int depth = 0;

            for (int i = 0; i < input.Count(); i++)
            {
                var e = input[i].Split(' ');
                if (e[0] == "forward")
                {
                    forward += int.Parse(e[1]);
                }

                if (e[0] == "down")
                {
                    depth += int.Parse(e[1]);
                }

                if (e[0] == "up")
                {
                    depth -= int.Parse(e[1]);
                }
            }


            var a = forward * depth;

            Console.WriteLine($"D2_P1: {a}");
        }

        private void Part2(List<string> input)
        {
            int forward = 0;
            int depth = 0;
            int aim = 0;


            for (int i = 0; i < input.Count(); i++)
            {
                var e = input[i].Split(' ');
                if (e[0] == "forward")
                {
                    forward += int.Parse(e[1]);
                    depth += aim * int.Parse(e[1]);
                }

                if (e[0] == "down")
                {
                    aim += int.Parse(e[1]);
                }

                if (e[0] == "up")
                {
                    aim -= int.Parse(e[1]);
                }
            }


            var a = forward * depth;

            Console.WriteLine($"D2_P2: {a}\n");
        }
    }
}
