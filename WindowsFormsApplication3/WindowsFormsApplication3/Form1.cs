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
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication3
{
    public partial class Численное : Form
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
        List<double> listx_v1 = new List<double>();
        List<double> listy_v1 = new List<double>();
        public Численное()
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
            StreamWriter wr = new StreamWriter("output.txt",false);
            chart1.Series["Series1"].Points.Clear();
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
            if (a==b)
            {
                MessageBox.Show("a u b не должны быть одинаковыми");
                a = b = 0;
                textBox1.Text = textBox1.Text = "0";
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
                    MessageBox.Show("Извинuте, но так ничего не получится. Шаг не должен быть равен нулю");
                    textBox3.Text = "";
                    count++;
                }
                if (count==0)
                {
                    if (step<0.000000001)
                    {
                        MessageBox.Show("Вы ввели слишком маленький шаг. Возможно неадекватное поведение программы");
                        count++;
                    }
                }
                if((b-a)/step>10000)
                {
                    MessageBox.Show("Количество точек должно быть меньше, чем 10000");
                    count++;
                }
            }
            if (count == 0)
            {
                
                wr.WriteLine("x\ty");
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
                    wr.WriteLine("{0}\t{1}", Math.Round(listxy[i], 2), listxy[i + 1]);
                }
                
            }
            listx.Clear();
            listy.Clear();
            listxy.Clear();
            wr.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "output.txt");
        }
        private void button3_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("output.txt");
            String text = sr.ReadToEnd();
            sr.Close();
            List<string> listt = new List<string>();
            string[] tables = new string[text.Split('\t',' ','\n','\r').Length];
            tables = text.Split('\t', ' ', '\n','\r');
            for (int i = 0; i < tables.Length;i++ )
            {
                if (tables[i]!=""&&i>1)
                {
                    listt.Add(tables[i]);
                }
            }
            for (int i = 0; i < listt.Count; i++)
            {
                if (i % 2 == 0)
                    listx_v1.Add(double.Parse(listt[i]));
                if (i % 2 != 0)
                    listy_v1.Add(double.Parse(listt[i]));

            }
            bool go = true;
            if (listx_v1.Count<5)
            {
                MessageBox.Show("Введено слишком мало точек для расчёта.Их должно быть как минимум 6");
                go = false;
            }
            chart1.Series["Series1"].Points.Clear();
            int counter = 0;
            double result=0;
            double PL = 0;
            bool check = true;
            int number = 0;
            double lag = 1;
            double z =0;
            if (radioButton1.Checked == true)
            {
                s = 1;
                counter++;
                node = new double[1];
                node[0] = 0;
                weight = new double[1];
                weight[0] = 2;
            }
            if (radioButton2.Checked == true)
            {
                s = 2;
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
                s = 3;
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
            if (radioButton1.Checked == false && radioButton2.Checked == false)
            {
                if (radioButton3.Checked == false)
                {
                    MessageBox.Show("Кажется, вы не выбрали S");
                    go = false;
                }
                
            }
            num = double.TryParse(textBox4.Text, out iter);
            if (!num)
            {
                MessageBox.Show("К сожалению, вы ввели количество подынтегралов неправильно. Это нужно исправить");
                go = false;
                textBox4.Text = "";
            }
            if (double.Parse(textBox4.Text) >= 100000)
            {
                MessageBox.Show("Вы ввели слишком большое количество подынтегралов. Программа может зависнуть!");
                go = false;
            }
            if ( double.Parse(textBox4.Text) < 0)
            {
                MessageBox.Show("Вы ввели отриательное количество подынтегралов. Не надо так");
                go = false;
            }
            else
                counter++;
            if (counter==2&&go==true)
            {
                iter=(listx_v1[listx_v1.Count-1]-listx_v1[0])/iter;
                for (double t = listx_v1[0]; t <= listx_v1[listx_v1.Count - 1]; t = t + iter)
                {
                    result = 0;                 
                    for (int i = 0; i < s; i++)
                    {
                        double x = (t + t + iter) / 2 + (iter / 2) * node[i];
                        PL = 0;
                        if (x < listx_v1[0] || x > listx_v1[listx_v1.Count - 1])
                            check = false;
                        if (check == true)
                        {
                            for (int p = 0; p < listx_v1.Count - 2; p++)
                            {
                                if (listx_v1[p] < x && listx_v1[p + 2] > x)
                                {
                                    number = p;
                                    if (number + 3 > listx_v1.Count)
                                    {
                                        number = number - (number + 3 - listx_v1.Count);
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
                                        lag *= (x - listx_v1[j]) / (listx_v1[p] - listx_v1[j]);
                                    }
                                }
                                PL += lag * listy_v1[p];
                            }
                            result += weight[i] * PL;

                        }
                        check = true;
                    }
                    result = result * (iter / 2);
                    z = z + result;
                    chart1.Series["Series1"].Points.AddXY(t, PL);
                }
                chart1.Series["Series1"].ChartType = SeriesChartType.Line;
                label7.Text = "Интеграл равен " + Math.Round(z,4).ToString();
            }
            listx_v1.Clear();
            listy_v1.Clear();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Численное_Load(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
