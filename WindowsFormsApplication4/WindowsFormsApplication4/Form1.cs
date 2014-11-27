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

namespace WindowsFormsApplication4
{

    public partial class Form1 : Form
    {
        double x0=0; // начальное и конечное значения
        double xK=0;
        double step;// шаг
        int n; // кол-во точек во входных данных
        int m;// порядок полинома
        double X;// аргумент
        List<double> listx = new List<double>();
        List<double> listy = new List<double>();
        List<double> listx_v1 = new List<double>();
        List<double> listy_v1 = new List<double>();
        List<double> compareX = new List<double>();
        List<double> compareY = new List<double>();
        bool check = false;
        bool num = false;
        int count=0;
        double y = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox6.ReadOnly = true;
            textBox7.ReadOnly = true;
            textBox8.ReadOnly = true;
            label6.Visible = false;
            textBox6.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("notepad.exe", "output.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series2"].Points.Clear();
            num = double.TryParse(textBox1.Text, out x0);
            if (!num)
            {
                MessageBox.Show("Неправильно введен х0");
                x0 = 0;
                textBox1.Text = "";
                count++;
            }
            num = double.TryParse(textBox2.Text, out xK);
            if (!num)
            {
                MessageBox.Show("Неправильно введён хк");
                xK = 0;
                textBox2.Text = "";
                count++;
            }
            num = double.TryParse(textBox3.Text, out step);
            if (!num)
            {
                MessageBox.Show("Шаг введен неправильно");
                step = 0;
                textBox3.Text = "";
                count++;
            }
            if (step == 0||step<0)
            {

                MessageBox.Show("Шаг не может быть 0 и, соответственно, меньше 0");
                step = 0;
                textBox3.Text = "";
                count++;
            }
            
            if (xK < x0)
            {
                MessageBox.Show("xk<x0");
                count++;
            }
            // input ended
            StreamWriter sw = new StreamWriter("output.txt",false);
            if (count == 0)
            {
                sw.WriteLine("x\ty");
                for (double i = x0; i < xK + 0.01; i += step)
                {
                    listx.Add(i);
                    y = Math.Sin(i) / Math.Pow(Math.Cos(i), 2);
                    listy.Add(y);
                }
                if (listx.Count <5)
                {
                    MessageBox.Show("Должно быть не меньше 5 точек");
                    check = true;
                    textBox3.Text = "";
                    textBox2.Text = "";
                    textBox1.Text = "";
                }
                if (check != true)
                {
                    for (int i = 0; i < listy.Count; i++)
                        sw.WriteLine("{0}\t{1}", listx[i], listy[i]);
                }
            }
            listx.Clear();
            listy.Clear();
            count = 0;
            sw.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();
            chart1.Series["Series2"].Points.Clear();
            listy_v1.Clear();
            listx_v1.Clear();
            StreamReader sr = new StreamReader("output.txt");
            String text = sr.ReadToEnd();
            sr.Close();
            List<string> listt = new List<string>();
            string[] tables = new string[text.Split('\t', ' ', '\n', '\r').Length];
            tables = text.Split('\t', ' ', '\n', '\r');
            for (int i = 0; i < tables.Length; i++)
            {
                if (tables[i] != "" && i > 1)
                {
                    listt.Add(tables[i]);
                }
            }
            for (int i = 0; i < listt.Count; i++)
            {
                if (i % 2 == 0)
                    listx_v1.Add(Math.Round(double.Parse(listt[i]),2));
                if (i % 2 != 0)
                    listy_v1.Add(Math.Round(double.Parse(listt[i]),2));

            }
           /* double k=0;
            for (int i=0;i<listx_v1.Count-1;i++)
            {
                k=0;
                for (int j=0;j<listx_v1.Count-i-1;j++)
                {
                    if (listx_v1[j]>listx_v1[j+1])
                    {
                        k = listx_v1[j];
                        listx_v1[j] = listx_v1[j + 1];
                        listx_v1[j + 1] = k;
                        k = 0;
                    }
                }
            }
            for (int i = 0; i < listy_v1.Count - 1; i++)
            {
                k = 0;
                for (int j = 0; j < listy_v1.Count - i - 1; j++)
                {
                    if (listy_v1[j] > listy_v1[j + 1])
                    {
                        k = listy_v1[j];
                        listy_v1[j] = listy_v1[j + 1];
                        listy_v1[j + 1] = k;
                        k = 0;
                    }
                }
            }*/
            int counterX =0;
            int counterY = 0;
            double comparer = 0;
           for (int i = 0; i < listx_v1.Count;i++ )
            {
                comparer = listx_v1[i];
                for (int j=0;j<listx_v1.Count;j++)
                {
                    if (comparer == listx_v1[j])
                        counterX++;
                }
            }
            comparer = 0;
            /*for (int i = 0; i < listy_v1.Count; i++)
            {
                comparer = listy_v1[i];
                for (int j=0;j<listy_v1.Count;j++)
                {
                    if (comparer == listy_v1[j])
                        counterY++;
                }
            }*/
            bool go = true;
            StreamWriter sw = new StreamWriter("output.txt",false);
            sw.WriteLine("x\ty");
            for (int i = 0; i < listy_v1.Count; i++)
                sw.WriteLine("{0}\t{1}", listx_v1[i], listy_v1[i]);
            sw.Close();
            if (counterX>listx_v1.Count||counterY>listy_v1.Count)
            {
                MessageBox.Show("Проблемы с введенными в файл значениями.");
                go = false;
            }
            if (listy_v1.Count != listx_v1.Count)
            {
                MessageBox.Show("Разное количество чисел");
                go = false;
            }
            if (go == true)
            {
                count = 0;
                double[,] Gramma = new double[0, 0];
                double[,] B = new double[0, 0];
                num = int.TryParse(textBox4.Text, out m);
                if (!num)
                {
                    MessageBox.Show("Неправильно введено m");
                    m = 0;
                    textBox4.Text = "";
                    count++;
                }
                /*if (m >= 10)
                {
                    MessageBox.Show("m должно быть меньше 10");
                    m = 0;
                    textBox4.Text = "";
                    count++;
                }*/
                num = double.TryParse(textBox5.Text, out X);
                if (!num)
                {
                    MessageBox.Show("Неправильно введен X");
                    X = 0;
                    textBox5.Text = "";
                    count++;
                }
                m += 1;
                if (X < listx_v1[0] || X > listx_v1[listx_v1.Count-1])
                {
                    MessageBox.Show("Введенный Х не попадает в заданный диапазон.");
                    textBox5.Text = "";
                    count++;
                }
                //input ended 
                if (count == 0)
                {
                    if (radioButton1.Checked == true)
                    {
                        int n = listx_v1.Count;
                        Gramma = new double[n, m];
                        double[,] Peremn = new double[1, 1];
                        double z = 1;
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                Gramma[i, j] = Math.Pow(listx_v1[i], j);
                            }
                        }
                        Peremn = Peremnogenie_matriz(Transponirovanie(Gramma, n, m), m, n, Gramma, m);
                        double[,] Y = new double[listy_v1.Count, 1];
                        for (int i = 0; i < listy_v1.Count; i++)
                        {
                            Y[i, 0] = listy_v1[i];
                        }
                        double[,] Beta = new double[0, 0];
                        Beta = Peremnogenie_matriz(Transponirovanie(Gramma, n, m), m, n, Y, 1);
                        double[,] Obratnaya = new double[1, 1];
                        double uu = 1;
                        if (uu == 0)
                        {
                            MessageBox.Show("Определитель матрицы равен 0! Обратной матрицы не существует! введите другие данные!");
                        }
                        if (uu != 0)
                        {
                            double[,] Grr = new double[1, 1];//Массив нужен для того, чтобы записать в него матрицу, которая равна произведению Obratnaya на Beta
                            Grr = Gauss(Peremn, Beta);//Получаем массив коэффициентов полинома
                            double y = 0;
                            for (int i = 0; i < Grr.GetLength(0); i++)
                            {
                                y += Grr[i, 0] * Math.Pow(X, i);
                            }
                            textBox7.Text = y.ToString();
                            double pogreshost = 0;
                            double[] dif = new double[listy_v1.Count];
                            double[] f = new double[listy_v1.Count];
                            for (int i = 0; i < listx_v1.Count; i++)
                            {
                                for (int j = 0; j < Grr.GetLength(0); j++)
                                {
                                    f[i] += Grr[j, 0] * Math.Pow(listx_v1[i], j);
                                }
                                dif[i] += Math.Pow((f[i] - listy_v1[i]), 2);
                                pogreshost += dif[i];
                            }
                            pogreshost = pogreshost / listx_v1.Count;
                            pogreshost = Math.Pow(pogreshost, 0.5);
                            textBox6.Text = Convert.ToString(pogreshost);
                            textBox8.Text = X.ToString();
                            for (int j = 0; j < listx_v1.Count; j++)
                            {
                                y = 0;
                                for (int i = 0; i < Grr.GetLength(0); i++)
                                {
                                    y += Grr[i, 0] * Math.Pow(listx_v1[j], i);
                                }
                                chart1.Series["Series1"].Points.AddXY(listx_v1[j], y);
                            }
                            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
                            for (int i = 0; i < listx_v1.Count; i++)
                            {
                                chart1.Series["Series2"].Points.AddXY(listx_v1[i], listy_v1[i]);
                            }
                            chart1.Series["Series2"].ChartType = SeriesChartType.Point;
                        }
                    }
                    /*Obratnaya = Obr(Peremn);
                    double[,] Grr = new double[1, 1];
                    Grr = Peremnogenie_matriz(Obratnaya, m, m, Beta, 1);
                    double y = 0;
                    for (int i = 0; i < Grr.GetLength(0); i++)
                    {
                        y += Grr[i, 0] * Math.Pow(X, i);
                    }
                    textBox7.Text = y.ToString();
                    double pogreshost = 0;
                    double[] dif = new double[listy_v1.Count];
                    double[] f = new double[listy_v1.Count];
                    for (int i = 0; i < listx_v1.Count; i++)
                    {
                        for (int j = 0; j < Grr.GetLength(0); j++)
                        {
                            f[i] += Grr[j, 0] * Math.Pow(listx_v1[i], j);
                        }
                        dif[i] += Math.Pow((f[i] - listy_v1[i]), 2);
                        pogreshost += dif[i];
                    }
                    pogreshost = pogreshost / listx_v1.Count;
                    pogreshost = Math.Pow(pogreshost, 0.5);
                    //textBox6.Text = Convert.ToString(pogreshost);
                    textBox8.Text = X.ToString(); 
                    for (int j = 0; j < listx_v1.Count; j++)
                    {
                        y = 0;
                        for (int i = 0; i < Grr.GetLength(0); i++)
                        {
                            y += Grr[i, 0] * Math.Pow(listx_v1[j], i);
                        }
                        chart1.Series["Series1"].Points.AddXY(listx_v1[j], y);
                    }
                    chart1.Series["Series1"].ChartType = SeriesChartType.FastLine;
                    for (int i = 0; i < listx_v1.Count; i++)
                    {
                        chart1.Series["Series2"].Points.AddXY(listx_v1[i], listy_v1[i]);
                    }
                    chart1.Series["Series2"].ChartType = SeriesChartType.Point;*/
                }
                listx_v1.Clear();
                listy_v1.Clear();
            }
        }
        
        
        
        
        
        
        
        public double[,] Transponirovanie(double[,] matrix, int n, int m)
        {
            double[,] matrix_2 = new double[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix_2[i, j] = matrix[j, i];
                }

            }
            return matrix_2;
        }
        double[,] Peremnogenie_matriz(double[,] matrix, int n_strok, int m_stolbzov, double[,] matrix_2, int stolbzi)
        {
            double[,] matrix3 = new double[n_strok, stolbzi];
            for (int i = 0; i < n_strok; i++)
            {
                for (int k = 0; k < stolbzi; k++)
                {
                    for (int j = 0; j < m_stolbzov; j++)
                    {
                        matrix3[i, k] += matrix[i, j] * matrix_2[j, k];
                    }
                }

            }
            return matrix3;
        }

        //
        public double Det(double[,] matriza)
        {
            double det = 0;
            int razmer = matriza.GetLength(0);
            if (razmer == 1) det = matriza[0, 0];
            if (razmer == 2) det = matriza[0, 0] * matriza[1, 1] - matriza[0, 1] * matriza[1, 0];
            if (razmer > 2)
            {
                for (int j = 0; j < matriza.GetLength(1); j++)
                {
                    det += Math.Pow(-1, 0 + j) * matriza[0, j] * Det(Minor(matriza, 0, j));
                }

            }

            return det;
        }
        public double[,] Minor(double[,] Matrix, int stroka, int stolbez)
        {
            double[,] buf = new double[Matrix.GetLength(0) - 1, Matrix.GetLength(1) - 1];
            for (int i = 0; i < Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    if (i != stroka || j != stolbez)
                    {
                        if (i < stroka && j < stolbez) buf[i, j] = Matrix[i, j];
                        if (i > stroka && j > stolbez) buf[i - 1, j - 1] = Matrix[i, j];
                        if (i < stroka && j > stolbez) buf[i, j - 1] = Matrix[i, j];
                        if (i > stroka && j < stolbez) buf[i - 1, j] = Matrix[i, j];
                    }
                }
            }
            return buf;
        }
        public double[,] MinoriMatr(int razmer, double[,] matr)
        {
            double[,] result = new double[razmer, razmer];
            for (int i = 0; i < razmer; i++)
            {
                for (int j = 0; j < razmer; j++)
                {
                    result[i, j] = Math.Pow(-1, i + j) * Det(Minor(matr, i, j));
                }
            }
            return result;
        }
        public double[,] Obr(double[,] matrix)
        {
            double k = 1 / Det(matrix);
            double[,] matr = MinoriMatr(matrix.GetLength(0), matrix);
            for (int i = 0; i < matr.GetLength(0); i++)
            {
                for (int j = 0; j < matr.GetLength(1); j++)
                {
                    matr[i, j] = matr[i, j] * k;
                }
            }
            return matr;
        }
        public double[,] Gauss(double[,] dd, double[,] bb)
        {
            double max = dd[0, 0];
            double z = 0;
            bool bbb = true;
            double h = 0;
            int schetchik = 0;
            double umnogrnie = 1;
            for (int i = schetchik; i < dd.GetLength(0); i++)
            {
                max = dd[i, i];
                int nomer = i;
                for (int j = schetchik; j < dd.GetLength(1); j++)
                {
                    if (Math.Abs(dd[j, i]) > Math.Abs(max))
                    {
                        max = dd[j, i];
                        for (int u = schetchik; u < dd.GetLength(1); u++)
                        {
                            z = dd[j, u];
                            dd[j, u] = dd[nomer, u];
                            dd[nomer, u] = z;
                        }
                        z = bb[j, 0];
                        bb[j, 0] = bb[nomer, 0];
                        bb[nomer, 0] = z;
                    }
                }
                for (int yy = schetchik + 1; yy < dd.GetLength(0); yy++)
                {
                    double mnog = Math.Abs(dd[yy, schetchik] / max);

                    for (int kk = schetchik + 1; kk < dd.GetLength(1); kk++)
                    {
                        if ((dd[yy, schetchik] > 0 && dd[schetchik, schetchik] > 0) || (dd[yy, schetchik] < 0 && dd[schetchik, schetchik] < 0))
                        {
                            dd[yy, kk] = dd[yy, kk] - dd[schetchik, kk] * mnog;
                        }

                        if ((dd[yy, schetchik] > 0 && dd[schetchik, schetchik] < 0) || (dd[yy, schetchik] < 0 && dd[schetchik, schetchik] > 0))
                        {
                            dd[yy, kk] = dd[yy, kk] + dd[schetchik, kk] * mnog;
                        }
                    }
                    if ((dd[yy, schetchik] > 0 && dd[schetchik, schetchik] > 0) || (dd[yy, schetchik] < 0 && dd[schetchik, schetchik] < 0))
                    {
                        bb[yy, 0] = bb[yy, 0] - bb[schetchik, 0] * mnog;
                    }
                    if ((dd[yy, schetchik] > 0 && dd[schetchik, schetchik] < 0) || (dd[yy, schetchik] < 0 && dd[schetchik, schetchik] > 0))
                    {
                        bb[yy, 0] = bb[yy, 0] + bb[schetchik, 0] * mnog;
                    }
                    dd[yy, schetchik] = 0;
                }

                schetchik++;
            }
            double[,] Matrix = new double[dd.GetLength(0), 1];
            double n = 0;
            int k = dd.GetLength(1);

            for (int i = Matrix.GetLength(0) - 1; i >= 0; i--)
            {
                Matrix[i, 0] = bb[i, 0];
                for (int j = Matrix.GetLength(0) - 1; j > i; j--)
                {
                    Matrix[i, 0] -= dd[i, j] * Matrix[j, 0];
                }

                if (dd[i, i] == 0 || bb[i, 0] == 0)//проверка - есть ли вобще решения
                    bbb = false;
                Matrix[i, 0] = Matrix[i, 0] / dd[i, i];
            }

            return Matrix;

        }
    }
}
