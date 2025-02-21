using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryNumbers;

namespace ConsoleAppTests
{
    class Tests
    {
        static void Main()
        {
            // "111,5" from 10 to 16
            // "12,2" from 3 to 4
            // "71,62" from 8 to 2
            // "ZS,V" from 36 to 10
            string[] number = new string[] { "111,5", "12,2", "71,62", "ZS,V" };
            int[] from = new int[] { 10, 3, 8, 36 };
            int[] to = new int[] { 16, 4, 2, 10 };
            // Массив с правильными ответами
            string[] myTests = new string[] { "6F,80", "11,222", "111001,11001", "1288,86111" };
            // Массив с ответами программы
            string[] results = new string[4];
            // Заполнение массива с ответами программы
            results[0] = ClassNumbers.ConvertNumberToAnotherNumberSystem("111,5", 10, 16, 2);
            results[1] = ClassNumbers.ConvertNumberToAnotherNumberSystem("12,2", 3, 4, 3);
            results[2] = ClassNumbers.ConvertNumberToAnotherNumberSystem("71,62", 8, 2, 5);
            results[3] = ClassNumbers.ConvertNumberToAnotherNumberSystem("ZS,V", 36, 10, 5);
            // Сравнение ответов программы с ответами, полученными вручную
            for (int i = 0; i < myTests.Length; i++)
            {
                if (myTests[i] == results[i])
                    Console.WriteLine("Ответ корректен. {0} из {1} в {2} = {3}", number[i], from[i], to[i], results[i]);
                else
                    Console.WriteLine("Ответ некорректен. {0} из {1} в {2} = {3}", number[i], from[i], to[i], results[i]);
            }
        }
    }
}
