using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2021
{
    class Day5
    {
        public Day5()
        {
            var input = File.ReadAllLines($"Day5.txt").ToList();
            Part1(input);
            Part2(input);
        }

        private void Part1(List<string> input)
        {
            int[,] bottom = new int[1000, 1000];
            for (int i = 0; i < input.Count; i++)
            {
                var e = input[i].Split(',', ' ', '-', '>').Where(x => x != "").Select(int.Parse).ToArray(); //09 19 29 39 49 59
                var range = new List<int>();


                if (e[0] == e[2])
                {
                    if (e[1] < e[3])
                    {
                        for (int o = e[1]; o <= e[3]; o++)
                        {
                            range.Add(o);
                        }
                    }
                    else
                    {
                        for (int o = e[1]; o >= e[3]; o--)
                        {
                            range.Add(o);
                        }
                    }

                    foreach (var r in range)
                    {
                        bottom[r, e[0]]++;
                    }
                }
                else if (e[1] == e[3])
                {

                    if (e[0] < e[2])
                    {
                        for (int j = e[0]; j <= e[2]; j++)
                        {
                            range.Add(j);
                        }
                    }
                    else
                    {
                        for (int j = e[0]; j >= e[2]; j--)
                        {
                            range.Add(j);
                        }
                    }

                    foreach (var r in range)
                    {
                        bottom[e[1], r]++;
                    }
                }

                range.Clear();
            }
            var points = 0;

            for (int k = 0; k < 1000; k++)
            {
                for (int l = 0; l < 1000; l++)
                {
                    if (bottom[k, l] >= 2)
                        points++;
                }

            }
            Console.WriteLine($"D5_P1: {points}");

        }

        private void Part2(List<string> input)
        {
            int[,] bottom = new int[1000, 1000];
            for (int i = 0; i < input.Count; i++)
            {
                var e = input[i].Split(',', ' ', '-', '>').Where(x => x != "").Select(int.Parse).ToArray(); //09 19 29 39 49 59
                var verticalRange = new List<int>();
                var diagonalRange = new List<int>();
                var startCol = 0;
                var startRow = 0;
                var endCol = 0;
                var endRow = 0;


                if (e[0] == e[2])
                {
                    if (e[1] < e[3])
                    {
                        for (int o = e[1]; o <= e[3]; o++)
                        {
                            verticalRange.Add(o);
                        }
                    }
                    else
                    {
                        for (int o = e[1]; o >= e[3]; o--)
                        {
                            verticalRange.Add(o);
                        }
                    }

                    foreach (var r in verticalRange)
                    {
                        bottom[r, e[0]]++;
                    }
                }
                else if (e[1] == e[3])
                {

                    if (e[0] < e[2])
                    {
                        for (int j = e[0]; j <= e[2]; j++)
                        {
                            verticalRange.Add(j);
                        }
                    }
                    else
                    {
                        for (int j = e[0]; j >= e[2]; j--)
                        {
                            verticalRange.Add(j);
                        }
                    }

                    foreach (var r in verticalRange)
                    {
                        bottom[e[1], r]++;
                    }
                }
                else
                {
                    startCol = e[0];
                    startRow = e[1];
                    endCol = e[2];
                    endRow = e[3];

                    if (startRow >= endRow & startCol >= endCol)
                    {
                        while (startCol >= endCol | startRow >= endRow)
                        {

                            bottom[startRow, startCol]++;
                            startCol--;
                            startRow--;
                        }
                    }

                    else if (startCol >= endCol & startRow <= endRow)
                    {
                        while (startCol >= endCol | startRow <= endRow)
                        {

                            bottom[startRow, startCol]++;
                            startCol--;
                            startRow++;
                        }
                    }

                    else if (startCol <= endCol & startRow <= endRow)
                    {
                        while (startCol <= endCol & startRow <= endRow)
                        {
                            bottom[startRow, startCol]++;
                            startCol++;
                            startRow++;
                        }
                    }

                    else if (startCol <= endCol & startRow >= endRow)
                    {
                        while (startCol <= endCol & startRow >= endRow)
                        {
                            bottom[startRow, startCol]++;
                            startCol++;
                            startRow--;
                        }
                    }
                }

                verticalRange.Clear();
            }
            var points = 0;

            //var result = "";

            for (int k = 0; k < 1000; k++)
            {
                for (int l = 0; l < 1000; l++)
                {
                    if (bottom[k, l] >= 2)
                        points++;

                    //if (bottom[k, l] == 0)
                    //    result += ". ";
                    //else
                    //    result += bottom[k, l] + " ";


                }
                //result += "\n";
            }
            //Console.WriteLine(result);
            Console.WriteLine($"D5_P2: {points}");
        }
    }
}
