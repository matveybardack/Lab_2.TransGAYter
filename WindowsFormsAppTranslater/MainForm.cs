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
        private int ValueCheckBase(int base_n, TextBox textBox)
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
        /// Функция, обрабатывающая нажатие кнопки пользователем
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonResult_Click(object sender, EventArgs e)
        {
            //Замена точек на запятые
            PointsReplacing();
            //Если все поля формы заполнены
            if (textEnterNumber.Text != "" && textEnterQ.Text != "" && textEnterP.Text != "")
            {
                string number;
                int base_q = 2;
                int base_p = 2;
                number = textEnterNumber.Text; //Ввод самого числа
                base_q = ValueCheckBase(base_q, textEnterQ); //Ввод основания P
                base_p = ValueCheckBase(base_p, textEnterP); //Ввод основания Q
                if (base_q >= base_p && base_p >= 2) //Если основания соответствуют условиям
                {
                    //TODO: тест, в котором проверяется, совпадает ли введённое число и исходное основание
                    //TODO: тут должен быть сам перевод с выводом результата
                }
                else
                {
                    string errorText = "Неверный ввод. \nОснование итоговой СС должно быть не меньше исходной.";
                    ErrorForm formError = new ErrorForm(errorText);
                    formError.ShowDialog();
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
