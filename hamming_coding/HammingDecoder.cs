using System;
using System.Linq;
using System.Text;

namespace hamming_coding
{
    public static class HammingDecoder
    {
        /// <summary>
        /// Переводит из двоичной в десятичную сс
        /// </summary>
        /// <param name="binary"></param>
        /// <returns></returns>
        private static int ToDecimal(string binary)
        {
            int number = int.Parse(binary);
            int result = 0;

            int pow = 0;
            while (number != 0)
            {
                result += (int)(number % 10 * Math.Pow(2, pow++));
                number /= 10;
            }

            return result;
        }

        /// <summary>
        /// Считает четность единиц
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        private static string CalculateError(string inputStr)
        {
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

            return error;
        }

        /// <summary>
        /// Удаляет контрольные байты
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static string DeleteControlBytes(string input)
        {
            string decode = "";

            int pow = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (i + 1 != (int)Math.Pow(2, pow))
                {
                    decode += input[i];
                }
                else
                {
                    pow++;
                }
            }

            return decode;
        }

        /// <summary>
        /// Декодирует входное двоичное сообщение
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string Decode(string inputStr)
        {
            StringBuilder input = new StringBuilder(inputStr);

            string error = CalculateError(inputStr);
            char[] arr = error.ToCharArray();
            Array.Reverse(arr);
            error = new string(arr);

            int errorIndex = ToDecimal(error) - 1;

            if (errorIndex != -1)
            {
                input[errorIndex] = input[errorIndex] == '1' ? '0' : '1';
            }
            
            string decode = DeleteControlBytes(input.ToString());
            return decode;
        }
    }
}