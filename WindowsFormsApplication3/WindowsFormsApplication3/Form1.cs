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
        double iter = 0;
        bool num = false;
        int count = 0;
        double[] node = {0};
        double[] weight = { 0 };
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
            double result=0;
            double PL = 0;
            bool check = true;
            int number = 0;
            double lag = 1;
            double z =0;
            if (radioButton1.Checked == true)
            {
                s = 0;
                counter++;
                node = new double[1];
                node[0] = 0;
                weight = new double[1];
                weight[0] = 0;

            }
            if (radioButton2.Checked == true)
            {
                s = 1;
                counter++;
                node = new double[2];
                node[0] = -0.57735027;
                node[1] = 0.57735027;
                weight = new double[2];
                weight[0] = 1;
                weight[0] = 1;
            }
            if (radioButton3.Checked == true)
            {
                s = 2;
                counter++;
                node = new double[3];
                node[0] = -0.7745966;
                node[1] = 0;
                node[2] = 0.7745966;
                weight = new double[3];
                weight[0] = 0.555556;
                weight[1] = 0.888888889;
                weight[2] = 0.555555555;

            }
            else
                MessageBox.Show("Кажется, вы не выбрали S");
            num = double.TryParse(textBox4.Text, out iter);
            if (!num)
            {
                MessageBox.Show("К сожалению, вы ввели количество подынтегралов неправильно. Это нужно исправить");
                textBox4.Text = "";
            }
            else
                counter++;
            if (counter==2)
            {
                iter=(listx[listx.Count-1]-listx[0])/iter;
                for (double t = listx[0]; t <= listx[listx.Count - 1]; t = t + iter)
                {
                    result = 0;                 
                    for (int i = 0; i < s; i++)
                    {
                        double x = (t + t + iter) / 2 + (iter / 2) * node[i];
                        PL = 0;
                        if (x < listx[0] || x > listx[listx.Count - 1])
                            check = false;
                        if (check == true)
                        {
                            for (int p = 0; p < listx.Count - 2; p++)
                            {
                                if (listx[p] < x && listx[p + 2] > x)
                                {
                                    number = p;
                                    if (number + 3 > listx.Count)
                                    {
                                        number = number - (number + 3 - listx.Count);
                                    }
                                    break;
                                }
                            }
                            for (int p = number; p < 3 + number; p++)
                            {
                                lag = 1;
                                for (int j = number; j < 3 + number; j++)
                                {
                                    if (p != j)
                                    {
                                        lag *= (x - listx[j]) / (listx[p] - listx[j]);
                                    }
                                }
                                PL += lag * listy[p];
                            }
                            result += weight[i] * PL;

                        }
                        check = true;
                    }
                    result = result * (iter / 2);
                    z = z + result;
                    chart1.Series["Series1"].Points.AddXY(t, PL);
                }
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
