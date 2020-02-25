using System;
using System.Linq;

namespace Magic_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i < nums.Length; i++)
            {
                int currentNum = nums[i];
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (currentNum + nums[j] == sum)
                    {
                        Console.WriteLine(currentNum + " " + nums[j]);
                    }

                }
            }

        }
    }
}
