using System;

namespace hamming_coding
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            string input;

            while (true)
            {
                Console.Write("1. Закодировать\n2. Декодировать\n0. Выход\nВыберите пункт меню: ");
                input = Console.ReadLine();

                switch (int.Parse(input ?? string.Empty))
                {
                    case 0:
                    {
                        return;
                    }
                    case 1:
                    {
                        Console.Write("Введите строку: ");
                        input = Console.ReadLine();
                        string encode = HammingEncoder.Encode(input);
                        Console.WriteLine("Закодированная строка: " + encode + "\n");
                    }
                        break;
                    case 2:
                    {
                        Console.Write("Введите строку: ");
                        input = Console.ReadLine();
                        string decode = HammingDecoder.Decode(input);
                        Console.WriteLine("Раскодированная строка: " + decode + "\n");
                    }
                        break;
                    default:
                    {
                        Console.WriteLine("Попробуйте ещё раз\n");
                    }
                        break;
                }
            }
        }
    }
}