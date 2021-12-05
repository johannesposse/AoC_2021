using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AoC_2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //var input = File.ReadAllLines($"Day{DateTime.Now.Day}.txt").Select(int.Parse).ToList();

            //var input = File.ReadAllLines($"Day{DateTime.Now.Day}.txt").ToList();
            var input = File.ReadAllLines($"Day4.txt").ToList();
            //string[] input;

            //foreach (var e in entries)
            //{
            //    input = e.Split(' ');
            //}


            //int One() => Day_2_Part_2(input);
            //int Two() => Day_2_Part_2(input);

            Day_4_Part_2(input);
            //int Two() => Day_2_Part_2(input);

            //Console.WriteLine($"Part One: {One()}\nPart Two: {Two()}");
            Console.ReadLine();
        }

        public static void Day_4_Part_1(List<string> input)
        {
            var boardArray = new int[5, 5];

            var numbers = input[0].Split(',').Select(int.Parse).ToList();
            int drawnNumbers = 5;

            for (int i = 2; i < input.Count; i++) //2-6
            {

                for (int j = 2; j < input.Count; j++)
                {
                    var board = input.GetRange(j, 5).ToArray();
                    var num = numbers.GetRange(0, drawnNumbers).ToArray();

                    for (int k = 0; k < board.Length; k++)
                    {
                        var row = board[k].Split(' ').Where(x => x != "").ToArray();
                        boardArray[k, 0] = int.Parse(row[0]);
                        boardArray[k, 1] = int.Parse(row[1]);
                        boardArray[k, 2] = int.Parse(row[2]);
                        boardArray[k, 3] = int.Parse(row[3]);
                        boardArray[k, 4] = int.Parse(row[4]);
                    }

                    for (int l = 0; l < 5; l++)
                    {
                        var countRow = num.Select(x =>
                        x == boardArray[l, 0] |
                        x == boardArray[l, 1] |
                        x == boardArray[l, 2] |
                        x == boardArray[l, 3] |
                        x == boardArray[l, 4]
                        );

                        var countColumn = num.Select(x =>
                        x == boardArray[0, l] |
                        x == boardArray[1, l] |
                        x == boardArray[2, l] |
                        x == boardArray[3, l] |
                        x == boardArray[4, l]
                        );

                        if (countRow.Count(x => x == true) == 5 | countColumn.Count(x => x == true) == 5)
                        {
                            var tempBoard = boardArray.Cast<int>().ToArray();
                            var unmarkedNumbers = tempBoard.Where(x => !num.Contains(x)).Sum();
                            var result = unmarkedNumbers * num.LastOrDefault();
                        }
                    }
                    j += 5;
                }
                drawnNumbers++;
            }
        }

        public static void Day_4_Part_2(List<string> input)
        {
            var boardArray = new int[5, 5];

            var numbers = input[0].Split(',').Select(int.Parse).ToList();
            int drawnNumbers = 5;
            var lastBoard = new List<string>();

            for (int i = 2; i < input.Count; i++) //2-6
            {

                for (int j = 2; j < input.Count; j++)
                {
                    var board = input.GetRange(j, 5).ToArray();
                    var num = numbers.GetRange(0, drawnNumbers).ToArray();


                    for (int k = 0; k < board.Length; k++)
                    {
                        var row = board[k].Split(' ').Where(x => x != "").ToArray();
                        boardArray[k, 0] = int.Parse(row[0]);
                        boardArray[k, 1] = int.Parse(row[1]);
                        boardArray[k, 2] = int.Parse(row[2]);
                        boardArray[k, 3] = int.Parse(row[3]);
                        boardArray[k, 4] = int.Parse(row[4]);
                    }

                    for (int l = 0; l < 5; l++)
                    {
                        var countRow = num.Select(x =>
                        x == boardArray[l, 0] |
                        x == boardArray[l, 1] |
                        x == boardArray[l, 2] |
                        x == boardArray[l, 3] |
                        x == boardArray[l, 4]
                        );

                        var countColumn = num.Select(x =>
                        x == boardArray[0, l] |
                        x == boardArray[1, l] |
                        x == boardArray[2, l] |
                        x == boardArray[3, l] |
                        x == boardArray[4, l]
                        );

                        if (num.Last() == 13)
                        {

                        }

                        if (countRow.Count(x => x == true) == 5 | countColumn.Count(x => x == true) == 5)
                        {

                            var tempBoard = boardArray.Cast<int>().ToArray();
                            var unmarkedNumbers = tempBoard.Where(x => !num.Contains(x)).Sum();
                            var result = unmarkedNumbers * num.LastOrDefault();

                            string s = "";

                            foreach (var t in tempBoard)
                            {
                                s += t + ",";
                            }

                            if (!lastBoard.Contains(s))
                            {
                                lastBoard.Add(s);
                            }

                            if (lastBoard.Count() == 100)
                            {
                                var r = lastBoard.Last().Split(",").Where(x => x != "").Select(int.Parse);
                                var unmarkedNumbers2 = r.Where(x => !num.Contains(x)).Sum();
                                var result2 = unmarkedNumbers * num.LastOrDefault();

                            }
                        }
                    }
                    j += 5;
                }
                drawnNumbers++;

            }
        }

        public static int Day_3_Part_1(List<string> input)
        {
            int length = input[0].Length;
            var bits = new StringBuilder();
            var epsilonRateString = new StringBuilder();



            for (int i = 0; i < length; i++)
            {
                var zero = input.Select(x => x.Substring(i, 1) == "0").Where(x => x == true).Count();
                var one = input.Select(x => x.Substring(i, 1) == "1").Where(x => x == true).Count();

                if (zero > one)
                {
                    bits.Append("0");
                }
                else
                {
                    bits.Append("1");
                }
            }

            for (int i = 0; i < bits.Length; i++)
            {
                if (bits[i] == '1')
                {
                    epsilonRateString.Append("0");
                }
                else
                {
                    epsilonRateString.Append("1");
                }
            }

            int gammaRate = Convert.ToInt32(bits.ToString(), 2);
            int epsilonRate = Convert.ToInt32(epsilonRateString.ToString(), 2);
            int power = gammaRate * epsilonRate;

            return power;
        }

        public static int Day_3_Part_2(List<string> input)
        {
            int length = input[0].Length;
            var ogr = input;
            var csr = input;

            for (int j = 0; j < ogr.Count(); j++)
            {
                for (int i = 0; i < length; i++)
                {

                    if (ogr.Count() > 1)
                    {
                        var zero = ogr.Select(x => x.Substring(i, 1) == "0").Where(x => x == true).Count();
                        var one = ogr.Select(x => x.Substring(i, 1) == "1").Where(x => x == true).Count();

                        if (zero > one)
                        {
                            ogr = ogr.Where(x => x.Substring(i, 1) == "0").ToList();
                        }
                        else if (zero == one)
                        {
                            ogr = ogr.Where(x => x.Substring(i, 1) == "1").ToList();
                        }
                        else
                        {
                            ogr = ogr.Where(x => x.Substring(i, 1) == "1").ToList();
                        }
                    }
                }
            }

            for (int j = 0; j < csr.Count(); j++)
            {
                for (int i = 0; i < length; i++)
                {
                    if (csr.Count() > 1)
                    {
                        var zero = csr.Select(x => x.Substring(i, 1) == "0").Where(x => x == true).Count();
                        var one = csr.Select(x => x.Substring(i, 1) == "1").Where(x => x == true).Count();

                        if (zero < one)
                        {
                            csr = csr.Where(x => x.Substring(i, 1) == "0").ToList();
                        }
                        else if (zero == one)
                        {
                            csr = csr = csr.Where(x => x.Substring(i, 1) == "0").ToList();
                        }
                        else
                        {
                            csr = csr.Where(x => x.Substring(i, 1) == "1").ToList();
                        }
                    }

                }
            }



            int ogRating = Convert.ToInt32(ogr[0].ToString(), 2);
            int csRarting = Convert.ToInt32(csr[0].ToString(), 2);
            int lsRating = ogRating * csRarting;

            return lsRating;
        }

        public static int Day_2_Part_2(List<string> input)
        {
            int count = 0;
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

            return count;
        }

        public static int Day_2_Part_1(List<string> input)
        {
            int count = 0;
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
