using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        double a = 0;
        double b = 0;
        double step = 0;
        double y = 0;
        int s = 100;
        int iter = 0;
        bool num = false;
        int count = 0;
        List<double> listx = new List<double>();
        List<double> listy = new List<double>();
        List<double> listxy = new List<double>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            count = 0;
            num = double.TryParse(textBox1.Text, out a);
            if (!num)
            {
                MessageBox.Show("К сожалению, вы ошиблись, и \"а\" не число! Исправьте, пожалуйста");
                textBox1.Text = "";
                count++;
            }
            if (a<=0&&count==0)
            {
                MessageBox.Show("Упс! В формуле десятичный логарифм, а  значит никаких отрицательных значений! Исправьте, пожалуйста, переменную \"a\"");
                textBox1.Text = "";
                count++;
            }
            num = double.TryParse(textBox2.Text, out b);
            if (!num)
            {
                MessageBox.Show("К сожалению, вы ошиблись, и \"b\" не число! Исправьте, пожалуйста");
                textBox2.Text = "";
                count++;
            }
            if (b <= 0&&count==0)
            {
                MessageBox.Show("Упс! В формуле десятичный логарифм, а значит никаких отрицательных значений! Исправьте, пожалуйста, переменную \"b\"");
                textBox2.Text = "";
                count++;
            }
            num = double.TryParse(textBox3.Text, out step);
            if (!num)
            {
                MessageBox.Show("К сожалению, вы ошиблись, и ввели в поле \"Шаг\" не число! Исправьте, пожалуйста");
                textBox3.Text = "";
                count++;
            }
            if (count==0)
            {
                if (step == 0)
                {
                    MessageBox.Show("Извинте, но так ничего не получится. Шаг не должен быть равен нулю");
                    textBox3.Text = "";
                    count++;
                }
                if (count==0)
                {
                    if (step<0.000000001)
                    {
                        MessageBox.Show("Вы ввели слишком маленький шаг. Возможно неадекватное поведение программы");
                    }
                }
            }
            if (count == 0)
            {
                StreamWriter wr = new StreamWriter("output.txt");
                wr.WriteLine("   x    ||     y");
                if (b < a)
                {
                    double g = b;
                    b = a;
                    a = g;
                }
                for (double i = a; i <= b + 0.01; i += step)
                {
                    listx.Add(i);
                    listxy.Add(i);
                    y = Math.Round(Math.Pow(i, 2) * Math.Pow(Math.Sin(i*Math.Log10(i)), 3), 4);
                    listy.Add(y);
                    listxy.Add(y);
                }
                for (int i = 0; i < listxy.Count; i += 2)
                {
                    wr.WriteLine("   {0}   ||   {1}   ", Math.Round(listxy[i], 2), listxy[i + 1]);
                }
                wr.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "output.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int counter = 0;
            if (radioButton1.Checked == true)
            {
                s = 0;
                counter++;
            }
            if (radioButton2.Checked == true)
            {
                s = 1;
                counter++;
            }
            if (radioButton3.Checked == true)
            {
                s = 2;
                counter++;
            }
            else
                MessageBox.Show("Кажется, вы не выбрали S");
            num = int.TryParse(textBox4.Text, out iter);
            if (!num)
            {
                MessageBox.Show("К сожалению, вы ввели количество подынтегралов неправильно. Это нужно исправить");
                textBox4.Text = "";
            }
            else
                counter++;
            if (counter==2)
            {

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
