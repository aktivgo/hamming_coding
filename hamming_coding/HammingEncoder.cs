using System;
using System.Linq;
using System.Text;

namespace hamming_coding
{
    static class HammingEncoder
    {
        private static int CalculateCountOfControlBytes(int n)
        {
            int k = 1;

            while (Math.Pow(2, k) - k - 1 < n)
            {
                k++;
            }

            return k;
        }

        private static string InitEncode(string inputStr, int n, int k)
        {
            string encode = "";

            int index = 0;
            int pow = 0;
            for (int i = 0; i < n + k; i++)
            {
                if ((i + 1) % Math.Pow(2, pow) == 0)
                {
                    encode += "0";
                    pow++;
                    continue;
                }

                encode += inputStr[index++];
            }

            return encode;
        }

        public static string Encode(string inputStr)
        {
            int n = inputStr.Length;
            int k = CalculateCountOfControlBytes(n);

            StringBuilder encode = new StringBuilder(InitEncode(inputStr, n, k));

            int pow = 0;
            for (int i = 0; i < n + k; i += (int) Math.Pow(2, pow++))
            {
                int sum = 0;
                for (int j = i; j < n + k; j += i + 2)
                {
                    if (j % 2 == 1)
                    {
                        continue;
                    }

                    sum += int.Parse(encode[j].ToString());
                }

                encode.Remove(i, 1);
                encode.Insert(i, sum % 2);
            }

            return encode.ToString();
        }
    }
}