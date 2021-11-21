using System;
using System.Linq;
using System.Text;

namespace hamming_coding
{
    public static class HammingDecoder
    {
        private static int ToDecimal(string binary)
        {
            int number = int.Parse(binary);
            int result = 0;

            int pow = 0;
            while (number != 0)
            {
                result += (int)(number % 10 * Math.Pow(2, pow));
                number /= 10;
            }

            return result;
        }

        public static string Decode(string inputStr)
        {
            StringBuilder decode = new StringBuilder(inputStr);
            string error = "";

            int pow = 0;
            for (int i = 0; i < inputStr.Length; i += (int)Math.Pow(2, pow++))
            {
                int sum = 0;
                for (int j = i; j < inputStr.Length; j += (int)Math.Pow(2, pow + 1))
                {
                    for (int l = 0; j + l < inputStr.Length && l < i + 1; l++)
                    {
                        sum += int.Parse(inputStr[j + l].ToString());
                    }
                }

                error += sum % 2;
            }

            char[] arr = error.ToCharArray();
            Array.Reverse(arr);
            error = new string(arr);

            int errorIndex = ToDecimal(error);

            decode[errorIndex] = decode[errorIndex] == '1' ? '0' : '1';

            // Удаление контрольных байт

            return decode.ToString();
        }
    }
}