using System;

namespace hamming_coding
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(HammingEncoder.Encode(input));
        }
    }
}