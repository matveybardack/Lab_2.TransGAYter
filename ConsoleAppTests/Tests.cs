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
        static void Main(string[] args)
        {
            //временнный тест (проверял свой код) удалить
            string a = Console.ReadLine();

            try
            {
                for (int i = 0; i < ClassNumbers.StringToMasOfNumbers(a)[0].Length; i++)
                    Console.Write(ClassNumbers.StringToMasOfNumbers(a)[0][i]);
                Console.WriteLine();
                for (int i = 0; i < ClassNumbers.StringToMasOfNumbers(a)[1].Length; i++)
                    Console.Write(ClassNumbers.StringToMasOfNumbers(a)[1][i]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(Convert.ToString(10));
        }
    }
}
