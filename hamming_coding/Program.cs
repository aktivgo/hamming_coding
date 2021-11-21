using System;

namespace hamming_coding
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            /*string input = Console.ReadLine();
            string encode = HammingEncoder.Encode(input);
            Console.WriteLine(encode);*/
            string decode = HammingDecoder.Decode("110");
            Console.WriteLine(decode);
        }
    }
}