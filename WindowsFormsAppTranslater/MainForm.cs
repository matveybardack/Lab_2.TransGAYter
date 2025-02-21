using ClassLibraryNumbers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsAppTranslater
{
    public partial class MainForm: Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Функция которая заменяет все точки(если они есть) в вводе пользователя на запятые
        /// </summary>
        private void PointsReplacing()
        {
            if (textEnterNumber.Text.Contains('.'))
            {
                string newText = "";
                for (int i = 0; i < textEnterNumber.Text.Length; i++)
                {
                    if (textEnterNumber.Text[i] == '.')
                    {
                        newText += ',';
                    }
                    else
                    {
                        newText += textEnterNumber.Text[i];
                    }
                }
                textEnterNumber.Text = newText;
            }

        }
        /// <summary>
        /// Функция проверки ввода, при успешном вводе функция возвращает введенное основание СС
        /// Иначе вернет -1
        /// </summary>
        /// <param name="base_n"></param>
        /// <returns name="base_n"></returns>
        private int ValueCheckBase(int base_n, System.Windows.Forms.TextBox textBox)
        {
            try
            {
                base_n = int.Parse(textBox.Text);
                if (base_n < 2 || base_n > 36)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                string errorText = "Неверный ввод. \nВведите целое положительное число от 2 до 36.";
                ErrorForm formError = new ErrorForm(errorText);
                formError.ShowDialog();
                return -1;
            }
            return base_n;
        }
        /// <summary>
        /// Метод для получения количества чисел после запятой
        /// </summary>
        /// <param name="number"></param>
        /// <returns>количество чисел после запятой</returns>
        private int GetDecimalDigitsCount()
        {
            int count = 0;
            try
            {
                count = int.Parse(textCount.Text);
                if (count < 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                string errorText = "Неверный ввод. \nВведите целое положительное число.";
                ErrorForm formError = new ErrorForm(errorText);
                formError.ShowDialog();
                return -1;
            }
            return count;
        }
        /// <summary>
        /// Проверка, совпадает ли введённое число с указанным исходным основанием СС
        /// </summary>
        /// <param name="number">число в виде строки</param>
        /// <param name="base_n">основание на которое проверяется</param>
        /// <returns>True или False</returns>
        private Boolean IsAlphabet(string number, int base_n)
        {
            string[] alphabet = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
            //string alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            for (int i = base_n; i < alphabet.Length; i++)
            {
                if (number.Contains(alphabet[i]))
                {
                    string errorText = "Неверный ввод. \nИсходное основание СС не соответствует числу.";
                    ErrorForm formError = new ErrorForm(errorText);
                    formError.ShowDialog();
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Функция, обрабатывающая нажатие кнопки пользователем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResult_Click(object sender, EventArgs e)
        {
            //Замена точек на запятые
            PointsReplacing();
            //Если все поля формы заполнены
            if (textEnterNumber.Text != "" && textEnterQ.Text != "" && textEnterP.Text != "" && textCount.Text != "")
            {
                string number;
                int base_q = 2;
                int base_p = 2;
                number = textEnterNumber.Text; //Ввод самого числа
                base_q = ValueCheckBase(base_q, textEnterQ); //Ввод основания P
                base_p = ValueCheckBase(base_p, textEnterP); //Ввод основания Q
                int count = GetDecimalDigitsCount(); //Сколько чисел после запятой
                if (base_q >= 2 && base_p >= 2 && count >= 0) //Если основания соответствуют условиям
                {
                    //тест, в котором проверяется, совпадает ли введённое число и исходное основание
                    if (IsAlphabet(number, base_p))
                    {
                        string result = ClassNumbers.ConvertNumberToAnotherNumberSystem(number, base_p, base_q, count);
                        labelResult.Text = result;
                    }
                }
            }
            //Если не все поля заполнены
            else
            {
                string errorText = "Неверный ввод. \nВсе поля должны быть заполнены.";
                ErrorForm formError = new ErrorForm(errorText);
                formError.ShowDialog();
            }
        }

        private void labelResult_Click(object sender, EventArgs e)
        {

        }
    }
}
