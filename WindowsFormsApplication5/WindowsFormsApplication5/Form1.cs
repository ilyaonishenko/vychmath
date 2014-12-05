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
using System.Collections;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        int check = 0;
        bool num = false;
        double h = 0;
        double t_v1 = 0;
        double y_1 = 0; // y1
        double y_2 = 0;
        double y10 = 0;
        double y20 = 0;
        double y11 = 0;
        double y22 = 0;
        double from = 0;
        double to = 0;
        int k = 4;
        bool Silv = false;
        bool Kutte = false;
        double k1 = 0, k2 = 0, k3 = 0, k4 = 0;
        double q1 = 0, q2 = 0, q3 = 0, q4 = 0;
        //from Slava
        double[,] Matrix;
        double[,] Sobstvennie_chisla;
        double[,] Sobsvennie_vectora;
        double t;
        double Y1;
        double Y2;
        double C1;
        double C2;
        double y1;
        double y2;
        // from me
        List<double> tArray = new List<double>();
        List<double> wArray = new List<double>();
        List<double> w1Array = new List<double>();
        List<double> y1Array = new List<double>();
        List<double> y2Array = new List<double>();
        public Form1()
        {
            InitializeComponent();
        }
        public delegate double Function(double t, double y); //declare a delegate that takes a double and returns
        //double
        public  void runge(double a, double b, double value,double value2, double step, Function f,Function f1)
        {
            double t, w, k1, k2, k3, k4;
            double w1, q1, q2, q3, q4;
            t = a;
            w = value;
            w1 = value2;
            for (int i = 0; i < (b - a) / step; i++)
            {
                /*if (i == 0)
                {
                    t = a + i * step;
                    w = 1;
                    w1 = 1;

                }
                else
                {*/
                    k1 = step * f(t, w);
                    q1 = step * f1(t, w1);
                    k2 = step * f(t + step / 2, w + k1 / 2);
                    q2 = step * f1(t + step / 2, w1 + q1 / 2);
                    k3 = step * f(t + step / 2, w + k2 / 2);
                    q3 = step * f1(t + step / 2, w1 + q2 / 2);
                    k4 = step * f(t + step, w + k3);
                    q4 = step * f1(t + step, w1 + q3);
                    w = w + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                    w1 = w1 + (q1 + 2 * q2 + 2 * q3 + q4) / 6;
                    t = a + i * step;
                //}
                tArray.Add(t);
                wArray.Add(w);
                w1Array.Add(w1);
                //Console.WriteLine("{0} {1} ", t, w);
            }
            StreamWriter sw = new StreamWriter("output1.txt", false);
            for (int i = 0; i < tArray.Count; i++)
                sw.WriteLine("{0}\t{1}\t{2}",tArray[i],wArray[i],w1Array[i]);
            sw.Close();
        }
        public double func1(double y1,double y2)
        {
            return 4 * y1 - 2 * y2;
        }
        public double func2(double y1,double y2)
        {
            return 3 * y1 + 4 * y2;
        }
        public double Runge(double k1, double k2, double k3, double k4, double bef)
        {
            return bef + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
        }
        public double rounding(double val, int k)
        {
            return Math.Round((Math.Pow(10, k) * val)) / Math.Pow(10,k);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            check = 0;
            //StreamWriter sw = new StreamWriter("output.txt",false);//набор значений в файл//
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series2"].Points.Clear();
            /*num = double.TryParse(textBox1.Text, out y1);
            if (!num)
            {

            }
            num = double.TryParse(textBox2.Text, out y2);
            if (!num)
            {

            }*/
            num = double.TryParse(textBox7.Text, out from);
            if (!num)
            {
                MessageBox.Show("Неправильно введено поле \"a\". Исправьте, пожалуйста;");
                textBox7.Text = "";
                check++;
            }
            num = double.TryParse(textBox8.Text, out to);
            if (!num&&check==0)
            {
                MessageBox.Show("Неправильно введено поле \"b\". Исправьте, пожалуйста;");
                textBox8.Text = "";
                check++;
            }
            num = double.TryParse(textBox3.Text, out h);
            if (!num&&check==0)
            {
                MessageBox.Show("Неправильно введено поле \"Шаг\". Исправьте, пожалуйста;");
                textBox3.Text = "";
                check++;
            }
            if((to-from)/h<3)
            {
                MessageBox.Show("Слишком мало точек для построения графика!");
                check++;
            }
            if (h<0.0001&&check==0)
            {
                MessageBox.Show("Скорее всего ничего работать не будет. Вы ввели очень маленький шаг. Он будет конфликтовать с методом округления, которогый используется в программе");
                textBox3.Text="";
                check++;
            }
            num = double.TryParse(textBox4.Text, out t);
            if (!num&&check==0)
            {
                MessageBox.Show("Неправильно введено поле \"t\". Исправьте, пожалуйста;");
                textBox4.Text = "";
                check++;
            }
            if (t>to||t<from)
                if (check==0)
                {
                    MessageBox.Show("Извините, но t  не попадает в заданный диапазон. Это плохо.");
                    textBox4.Text = "";
                    check++;
                }
            t_v1 = t;
            num = double.TryParse(textBox1.Text, out Y1);
            if (!num&&check==0)
            {
                MessageBox.Show("Неправильно введено поле \"у1(0)\". Исправьте, пожалуйста;");
                textBox1.Text = "";
                check++;
            }
            num = double.TryParse(textBox2.Text, out Y2);
            if (!num&&check==0)
            {
                MessageBox.Show("Неправильно введено поле \"у2(0)\". Исправьте, пожалуйста;");
                textBox2.Text = "";
                check++;
            }
            //
            // pri y1 = 1 y2 = 1;
            //
            /*for (;from<to;from+=h )
            {
                k1 = h * func1(y1, y2);
                q1 = h * func2(y1, y2);
                k2 = h * func1(y1 + h / 2, y2 + q1*h / 2);
                q2 = h * func2(y1 + h / 2, y2 + q1*h / 2);
                k3 = h * func1(y1 + h / 2, y2 + q2*h / 2);
                q3 = h * func2(y1 + h / 2, y2 + q2*h / 2);
                k4 = h * func1(y1 + h, y2 + q3*h);
                q4 = h * func2(y1 + h, y2 + q3*h);
                y11 = Runge(k1, k2, k3, k4, y10);
                y22 = Runge(q1, q2, q3, q4, y20);
                sw.WriteLine(rounding(y11, k) + " || " + rounding(y22, k) + " || ");
                y10 = y11;
                y20 = y22;
            }*/
            if (check==0)
                Silv = true;
            //Kutte = true;
            if (Kutte == true)
            {
                runge(0, 10, 3, 3, 0.1, new Function(func1), new Function(func2));
            }
            if (Silv == true)
            {
                //6,44
                //1,66
                Matrix = new double[2, 2];
                Matrix[0, 0] = 4;
                Matrix[0, 1] = -2;
                Matrix[1, 0] = 3;
                Matrix[1, 1] = 4;
                Sobstvennie_chisla = new double[1, 2];
                Sobstvennie_chisla[0, 0] = 6.44;
                Sobstvennie_chisla[0, 1] = 1.66;
                Sobsvennie_vectora = new double[2, 2];
                /*Sobsvennie_vectora[0, 0] = 2;
                Sobsvennie_vectora[0, 1] = -1;
                Sobsvennie_vectora[1, 0] = 2;
                Sobsvennie_vectora[1, 1] = 1;*/
                Sobsvennie_vectora[0, 0] = 1;
                Sobsvennie_vectora[0, 1] = Math.Sqrt(2 / 3);
                Sobsvennie_vectora[1, 0] = Math.Sqrt(3 / 2);
                Sobsvennie_vectora[1, 1] = 1;
                // надо найти значение с1 и с2
                C1 = 1;// (Y1 - Y2 * Sobsvennie_vectora[1, 0]) / (Sobsvennie_vectora[0, 0] - Sobsvennie_vectora[1, 0]);
                C2 = 1;
                //y1 = Math.Pow(Math.E, (Sobstvennie_chisla[0, 0] * t)) * Sobsvennie_vectora[0, 0] * C1 + Math.Pow(Math.E, (t * Sobstvennie_chisla[0, 1])) * C2 * Sobsvennie_vectora[1, 0];
                //y2 = Math.Pow(Math.E, (Sobstvennie_chisla[0, 0] * t)) * Sobsvennie_vectora[0, 1] * C1 + Math.Pow(Math.E, (t * Sobstvennie_chisla[0, 1])) * C2 * Sobsvennie_vectora[1, 1];
                StreamWriter sw = new StreamWriter("output2.txt", false);
                for (double i =from; i <= to; i = i + h)
                {
                    if (i == from)
                    {
                        y2 = rounding(y2, k);
                        y1 = rounding(y2, k);
                        y1Array.Add(y1);
                        y2Array.Add(y2);
                        tArray.Add(t);
                        //chart1.Series["Series1"].Points.AddXY(0, Y1);
                        //chart1.Series["Series2"].Points.AddXY(0, Y2);
                    }
                    if (i != 0)
                    {
                        t = i;
                        t = rounding(t,k);
                        t = rounding(t, k);
                        //y1 = Math.Pow(Math.E, (Sobstvennie_chisla[0, 0] * t)) * Sobsvennie_vectora[0, 0] * C1 + Math.Pow(Math.E, (t * Sobstvennie_chisla[0, 1])) * C2 * Sobsvennie_vectora[1, 0];
                        //y2 = Math.Pow(Math.E, (Sobstvennie_chisla[0, 0] * t)) * Sobsvennie_vectora[0, 1] * C1 + Math.Pow(Math.E, (t * Sobstvennie_chisla[0, 1])) * C2 * Sobsvennie_vectora[1, 1];
                        y2 = Math.Pow(Math.E, (4 * t)) * Sobsvennie_vectora[1,0] * C1 * Math.Sin(Math.Sqrt(6) * t) + Math.Pow(Math.E, (t * 4)) * C2  * Math.Cos(Math.Sqrt(6) * t)*Sobsvennie_vectora[1,1];
                        y1 = Math.Pow(Math.E, (4 * t)) * Sobsvennie_vectora[0,0] * C1*Math.Cos(Math.Sqrt(6)*t) - Math.Pow(Math.E, (t * 4)) * C2 * Sobsvennie_vectora[0,1]*Math.Sin(Math.Sqrt(6)*t);
                        y2 = rounding(y2, k);
                        y1 = rounding(y1, k);
                        y2 = rounding(y2, k);
                        y1 = rounding(y1, k);
                        sw.WriteLine("{0}\t{1}\t{2}",i,y1,y2);
                        //chart1.Series["Series1"].Points.AddXY(i, y1);
                        //chart1.Series["Series2"].Points.AddXY(i, y2);
                        y1Array.Add(y1);
                        y2Array.Add(y2);
                        tArray.Add(t);
                    }
                }
                sw.Close();
                //chart1.Series["Series1"].ChartType = SeriesChartType.Line;
                //chart1.Series["Series2"].ChartType = SeriesChartType.Point;
                //chart1.Series["Series2"].Color = Color.Red;
            }
            y1Array.Clear();
            y2Array.Clear();
            tArray.Clear();
            label9.Text = "Все точки найдены и записаны в файл."+Environment.NewLine+" Нажмите \"Файл\" для просмотра файла"+Environment.NewLine+" или \"Построить\", чтобы построить график"+Environment.NewLine+" и найти y1(t) u y2(t)";
            //textBox5.Text = y1.ToString();
            //textBox6.Text = y2.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //button1.Enabled = false;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            //label3.Visible = false;
            //textBox3.Visible = false;
            label9.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "output2.txt");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series2"].Points.Clear();
            List<double> coolArray = new List<double>();//t
            List<double> funnyArray = new List<double>();//y1
            List<double> lovelyArray = new List<double>();//y2
            List<double> THEGREATARRAY = new List<double>();//all
            StreamReader sr = new StreamReader("output2.txt");
            string text = sr.ReadToEnd();
            sr.Close();
            char[] sep = new char[]{' ','\t','\n',' '};
            string[] helpme = new string[text.Split(sep).Length];
            helpme = text.Split(sep);
            for (int i=0;i<helpme.Length;i++)
            {
                if (helpme[i]!="")
                {
                    THEGREATARRAY.Add(double.Parse(helpme[i]));
                }
            }
            int kolda = 0;
            for (int i=0;i<THEGREATARRAY.Count;i++)
            {
                if (kolda==0)
                {
                    coolArray.Add(THEGREATARRAY[i]);
                    kolda++;
                    continue;
                }
                if (kolda==1)
                {
                    funnyArray.Add(THEGREATARRAY[i]);
                    kolda++;
                    continue;
                }
                if (kolda==2)
                {
                    lovelyArray.Add(THEGREATARRAY[i]);
                    kolda = 0;
                    continue;
                }
            }
            for (int i=0;i<coolArray.Count;i++)
            {
                if (rounding(t_v1,k) == rounding(coolArray[i],k))
                {
                    textBox5.Text = funnyArray[i].ToString();
                    textBox6.Text = lovelyArray[i].ToString();
                }
                chart1.Series["Series1"].Points.AddXY(coolArray[i],funnyArray[i] );
                chart1.Series["Series2"].Points.AddXY(coolArray[i],lovelyArray[i]);
            }
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            chart1.Series["Series2"].ChartType = SeriesChartType.Point;
            chart1.Series["Series2"].Color = Color.Red;
        }
    }
}
