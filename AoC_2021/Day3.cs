using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2021
{
    class Day3
    {
        public Day3()
        {
            var input = File.ReadAllLines($"Day3.txt").ToList();
            Part1(input);
            Part2(input);
        }
        private void Part1(List<string> input)
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

            Console.WriteLine($"D3_P1: {power}");
        }
        private void Part2(List<string> input)
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

            Console.WriteLine($"D3_P1: {lsRating}\n");
        }
    }
}
