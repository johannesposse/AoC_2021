using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2021
{
    class Day4
    {
        public Day4()
        {
            var input = File.ReadAllLines($"Day4.txt").ToList();
            Part1(input);
            Part2(input);
        }
        private void Part1(List<string> input)
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
                            Console.WriteLine($"D4_P1: {result}");
                            return;
                        }
                    }
                    j += 5;
                }
                drawnNumbers++;
            }
        }

        private void Part2(List<string> input)
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
                                Console.WriteLine($"D4_P2: {result2}\n");
                                return;

                            }
                        }
                    }
                    j += 5;
                }
                drawnNumbers++;

            }
        }
    }
        
}
