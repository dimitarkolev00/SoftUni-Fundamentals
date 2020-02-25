using System;
using System.Linq;

namespace Zig_Zag
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] arrOne = new int[n];
            int[] arrTwo = new int[n];

            for (int i = 0; i < n; i++)
            {
                int[] nums = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                if ((i + 1) % 2 != 0)
                {
                    arrOne[i] = nums[0];
                    arrTwo[i] = nums[1];
                }
                else
                {
                    arrOne[i] = nums[1];
                    arrTwo[i] = nums[0];
                }
            }
            Console.WriteLine(string.Join(" ", arrOne));
            Console.WriteLine(string.Join(" ", arrTwo));
        }
    }
}
