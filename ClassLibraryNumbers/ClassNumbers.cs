using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryNumbers
{
    /// <summary>
    /// Библиотека классов для перевода чисел из различных систем счисления (не менее 2) в другую (не более 36)
    /// 
    /// Перевод целой части в 10-ичную систему счисления
    /// Перевод дробной части в 10-ичную систему счисления
    /// 
    /// Перевод целой части из 10-ичной в другую
    /// Перевод дробной части из 10-ичной в другую
    /// 
    /// Перевод всего числа в 10-ичную
    /// Перевод всего числа из 10-ичной в другую
    /// Перевод чисел в различные системы счисления
    /// 
    /// Перевод символа в число (для любой системы счисления)
    /// Приведение всех цифр(букв) к десятичной записи
    /// </summary>
    public static class ClassNumbers
    {
        //объявление констант
        public const char MinDig = '0';
        public const char MaxDig = '9';
        public const char MinSym = 'A';
        public const char MaxSym = 'Z';
        
        /// <summary>
        /// Делит строку на целую часть до запятой и дробную после
        /// </summary>
        /// <param name="N">Вещественное число</param>
        /// <returns></returns>
        /// <exception cref="Exception">Неверный ввод, если строка не является числом</exception>
        public static string[] DevideToIntFrac(string N)
        {
            string[] Int_Frac;

            if (N.Split(',').Length == 2)
            {
                Int_Frac = N.Split(',');
                return Int_Frac;
            }
            else if (N.Split(',').Length == 1)
            {
                Int_Frac = new string[2];
                Int_Frac[0] = N.Split(',')[0];
                Int_Frac[1] = "0";
                return Int_Frac;
            }
            else
            {
                throw new Exception("Неверный ввод");
            }
        }

        /// <summary>
        /// Переводит символ в число, используя алфавит систем счислений
        /// </summary>
        /// <param name="num">символ</param>
        /// <returns>число в десятичной системе счисления</returns>
        /// <exception cref="Exception">если символа нет в алфавите выдаст исключение "Неверный ввод"</exception>
        public static int CharToNum(char num)
        {
            num = char.ToUpper(num);

            if ('0' <= num && num <= '9')
                return num - '0';
            else if (num >= 'A' && num <= 'Z')
                return num - 'A' + 10;
            else
                throw new Exception("Неверный ввод");
        }

        /// <summary>
        /// Преобразует строку в массив из двух массивов: массив цифр целой части и массив цифр дробной части
        /// </summary>
        /// <param name="N">число в строковом формате</param>
        /// <returns>Массив из двух массивов</returns>
        public static int [][] StringToMasOfNumbers (string N)
        {
            string[] Int_Frac;

            Int_Frac = DevideToIntFrac(N);

            int[][] MasOfNum = new int[2][];

            char[] Int = Int_Frac[0].ToCharArray();
            char[] Frac = Int_Frac[1].ToCharArray();
            int[] Ints = new int[Int.Length];
            int[] Fracs = new int[Frac.Length];

            for (int i = 0; i < Int_Frac[0].Length; i++)
                    Ints[i] = CharToNum(Int[i]);

            for (int i = 0; i < Int_Frac[1].Length; i++)
                Fracs[i] = CharToNum(Frac[i]);

            MasOfNum[0] = Ints;
            MasOfNum[1] = Fracs;

            return MasOfNum;
        }


    }
}
