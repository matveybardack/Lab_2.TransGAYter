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

        /// <summary>
        /// Перевод целой части в десятеричную систему счисления
        /// </summary>
        /// <param name="Ints">массив цифр числа</param>
        /// <param name="I">система счисления</param>
        /// <returns>целое число в десятеричной системе счисления</returns>
        public static int ConvertIntsToDecimal(int[] Ints, int I)
        {
            int decimalint = 0;
            
            for (int i = 0; i < Ints.Length; i++)
                decimalint = decimalint * I + Ints[i];
            return decimalint;
        }

        /// <summary>
        /// Перевод дробной части в десятеричную систему счисления
        /// </summary>
        /// <param name="Fracs">массив цифр числа</param>
        /// <param name="I">система счисления</param>
        /// <returns>дробное число в десятеричной системе счисления</returns>
        public static double ConvertFracsToDecimal(int[] Fracs, int I)
        {
            double decimalfrac = 0;
            double p = 1.0 / I;

            for (int i = Fracs.Length - 1; i >= 0; i--)
                decimalfrac = (decimalfrac + Fracs[i]) * p;
            return decimalfrac;
        }

        /// <summary>
        /// Перевод целой части числа из десятиричной в заданную систему счисления
        /// </summary>
        /// <param name="decimalint">целая часть числа</param>
        /// <param name="I">система счислению, в которую нужно перевести</param>
        /// <returns>строковое представление дробной части числа</returns>
        public static string ConvertIntsDecimalToI(int decimalint, int I)
        {
            string numsys = "";

            do
            {
                if (decimalint % I > 9)
                    numsys = Convert.ToString(Convert.ToChar('A' + (decimalint % I) - 10)) + numsys;
                else
                    numsys = Convert.ToString(decimalint % I) + numsys;
                decimalint /= I;
            }
            while (decimalint > 0);

                return numsys;
        }

        /// <summary>
        /// Перевод дробной части числа из десятиричной в заданную систему счисления
        /// </summary>
        /// <param name="decimalfrac">дробная часть числа</param>
        /// <param name="I">система счислению, в которую нужно перевести</param>
        /// <param name="k">кол-во знаков после запятой</param>
        /// <returns>строковое представление дробной части числа</returns>
        public static string ConvertFracsDecimalToI(double decimalfrac, int I, int k)
        {
            string numsys = "";

            for (int i = 0; i < k; i++)
            {
                int intpart = (int)Math.Truncate((double)(decimalfrac * I));
                decimalfrac = decimalfrac * I - intpart;

                if (intpart > 9)
                    numsys = Convert.ToString(Convert.ToChar('A' + intpart - 10)) + numsys;
                else
                    numsys = numsys + Convert.ToString(intpart);
            }

            return numsys;
        }

        /// <summary>
        /// Перевод вещ. числа из одной системы счисления в другую
        /// </summary>
        /// <param name="num">переводимое число</param>
        /// <param name="J">система счисления вводимого числа</param> 
        /// <param name="I">система счисления в которую нада перевести</param>
        /// <param name="k">кол-во знаков после запятой</param>
        /// <returns>строковое представление переведённого числа</returns>
        public static string ConvertNumberToAnotherNumberSystem(string num, int J, int I, int k)
        {
            string result = "";
            int[] ints = StringToMasOfNumbers(num)[0];
            int[] fracs = StringToMasOfNumbers(num)[1];
            int decint = ConvertIntsToDecimal(ints, J);
            double decfrac = ConvertFracsToDecimal(fracs, J);
            string strint = ConvertIntsDecimalToI(decint, I);
            string strfrac = ConvertFracsDecimalToI(decfrac, I, k);
            if (k == 0)
                result = strint;
            else
                result = strint + "," + strfrac;
            return result;
        }
    }
}
