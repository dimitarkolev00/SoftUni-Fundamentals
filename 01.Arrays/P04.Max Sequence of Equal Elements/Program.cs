using System;
using System.Linq;

namespace Max_Sequence_of_Equal_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            int count = 1;
            int num = arr[0];

            int bestCount = 1;
            int bestNum = arr[0];


            for (int i = 0; i < arr.Length - 1; i++)
            {
                int element = arr[i];
                int nextElement = arr[i + 1];

                if (element == nextElement)
                {
                    count++;
                }
                else
                {
                    count = 1;
                    num = nextElement;
                }
                if (count > bestCount)
                {
                    bestCount = count;
                    bestNum = num;
                }
            }
            for (int i = 0; i < bestCount; i++)
            {
                Console.Write(bestNum + " ");
            }
        }
    }
}
