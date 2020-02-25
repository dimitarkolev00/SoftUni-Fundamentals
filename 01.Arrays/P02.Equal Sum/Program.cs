using System;
using System.Linq;

namespace Equal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int l = input.Length;
            int[,] result = new int[2, l];
            int sumLeft = 0;
            int sumRight = 0;

            if (input.Length == 1)
            {
                Console.WriteLine(0);
            }
            else
            {
                for (int i = 0; i < l; i++)
                {
                    Array.Clear(result, 0, result.Length);
                    sumLeft = 0;
                    sumRight = 0;

                    for (int row = 0; row < result.GetLength(0); row++)
                    {
                        //left numbers
                        if (row == 0 && i > 0)
                        {
                            for (int colLeft = 0; colLeft <= Math.Max(i - 1, 0); colLeft++)
                            {
                                {
                                    result[row, colLeft] = input[colLeft];
                                    sumLeft += result[row, colLeft];
                                }
                            }
                        }
                        //right numbers
                        if (row == 1 && i < input.Length - 1)
                        {
                            for (int colRight = i + 1; colRight < l; colRight++)
                            {
                                result[row, colRight] = input[colRight];
                                sumRight += result[row, colRight];
                            }
                        }
                    }

                    if (sumLeft == sumRight)
                    {
                        Console.WriteLine(i);
                        return;
                    }
                }
                Console.WriteLine("no");
            }
        }
    }
}
