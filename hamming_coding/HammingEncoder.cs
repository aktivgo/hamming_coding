using System;
using System.Text;

namespace hamming_coding
{
    static class HammingEncoder
    {
        /// <summary>
        /// Считает количество контрольных байт(k)
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int CalculateCountOfControlBytes(int n)
        {
            int k = 1;

            while (Math.Pow(2, k) - k - 1 < n)
            {
                k++;
            }

            return k;
        }

        /// <summary>
        /// Инициализирует выходную строку(на места, кратные степеням 2, ставит 0, на остальные - символы исходного сообщения
        /// </summary>
        /// <param name="inputStr"></param>
        /// <param name="n"></param>
        /// <param name="k"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Кодирует исходное двоичное сообщение
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string Encode(string inputStr)
        {
            int n = inputStr.Length;
            int k = CalculateCountOfControlBytes(n);

            StringBuilder encode = new StringBuilder(InitEncode(inputStr, n, k));

            int pow = 0;
            for (int i = 0; i < n + k; i += (int)Math.Pow(2, pow++))
            {
                int sum = 0;
                for (int j = i; j < n + k; j += (int)Math.Pow(2, pow + 1))
                {
                    for (int l = 0; j + l < encode.Length && l < i + 1; l++)
                    {
                        sum += int.Parse(encode[j + l].ToString());
                    }
                }

                encode[i] = Convert.ToChar((sum % 2).ToString());
            }

            return encode.ToString();
        }
    }
}