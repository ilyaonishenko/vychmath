using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication6
{
    public partial class Form1 : Form
    {
        double x;
        double y;
        double[,] Jacoby;
        double[,] functionMatrix;
        double toch;
        int iter;
        bool num = false;
        bool checker = true;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool goOn = true;
            num = double.TryParse(textBox1.Text, out x);
            if (!num)
            {
                goOn = false;
                MessageBox.Show("Вы неверно ввели х");
            }
            num = double.TryParse(textBox2.Text,out y);
            if (!num&&goOn==true)
            {
                goOn = false;
                MessageBox.Show("Вы неверно ввели y");
            }
            if (x>2&&y>2)
            {
                MessageBox.Show("Вы ввели слишком большие приближенные значения");
            }
            num = int.TryParse(textBox3.Text, out iter);
            if (!num&&goOn==true)
            {
                goOn = false;
                MessageBox.Show("Вы неверно ввели количество итераций");
            }
            num = double.TryParse(textBox4.Text, out toch);
            if (!num&&goOn==true)
            {
                goOn = false;
                MessageBox.Show("Вы неверно ввели точность");
            }
            Jacoby = new double[2, 2];
            Jacoby = createJacoby(Jacoby, x, y);
            functionMatrix = new double[2, 2];
            /*int i=0;
            while(i<iter)
            {
                if (checker == false)
                    break;
                heyNewton(ref x, ref y, Jacoby,ref checker, toch,iter);
                i++;
            }
                //int w = 100;
            textBox5.Text = x.ToString();//listX.Last<double>().ToString();
           // textBox5.Text = x.ToString();
            //test(ref w);
            textBox6.Text = y.ToString();//listY.Last<double>().ToString();*/
            if (goOn == true)
            {
                for (int i = 0; i < iter; i++)
                {
                    x = x - ((1 / det(createJacoby(Jacoby, x, y))) * det(createMatrixFunctionX(functionMatrix, x, y)));
                    y = y - ((1 / det(createJacoby(Jacoby, x, y))) * det(createMatrixFunctionY(functionMatrix, x, y)));
                    if ((Math.Cos(x * x + y * y) - x + y - 0.2) < toch && ((Math.Pow(x + y - 2, 2)) / (0.6) + Math.Pow(y - 0.1, 2) - 1) < toch)
                    {
                        checker = false;
                    }
                }
                textBox5.Text = x.ToString();
                textBox6.Text = y.ToString();
            }
        }
        double [,] createJacoby(double[,] Jacoby,double x,double y)
        {
            Jacoby[0, 0] = -2 * x * Math.Sin(Math.Pow(x, 2) + Math.Pow(y, 2)) - 1;
            Jacoby[0, 1] = 1 - 2 * y * Math.Sin(Math.Pow(x, 2) + Math.Pow(y, 2));
            Jacoby[1, 0] = 3.33333334*(x + y - 2);
            Jacoby[1, 1] = 3.33333334 * x + 5.333334 * y - 6.8;
            return Jacoby;
        }
        double [,] createMatrixFunctionX(double[,] functionF,double x,double y)
        {
            functionF[0, 0] = Math.Cos(x * x + y * y) - x + y - 0.2;
            functionF[0, 1] = 1 - 2 * y * Math.Sin(Math.Pow(x, 2) + Math.Pow(y, 2));
            functionF[1, 0] = ((Math.Pow(x + y - 2, 2)) / (0.6)) + Math.Pow(y - 0.1, 2) - 1;
            functionF[1, 1] = 3.33333334 * x + 5.33333334 * y - 6.8;
            return functionF;
        }
        double[,] createMatrixFunctionY(double[,] functionF, double x, double y)
        {
            functionF[0, 0] = -2 * x * Math.Sin(Math.Pow(x, 2) + Math.Pow(y, 2)) - 1;
            functionF[0, 1] = Math.Cos(Math.Pow(x,2) + Math.Pow(y,2)) - x + y - 0.2;
            functionF[1, 0] = 3.333333334 * (x + y - 2);
            functionF[1, 1] = ((Math.Pow(x + y - 2, 2)) / (0.6)) + Math.Pow(y - 0.1, 2) - 1;
            return functionF;
        }
        double det(double[,] Matrix)
        {
            return Matrix[0, 0] * Matrix[1, 1] - Matrix[0, 1] * Matrix[1, 0];
        }
        void heyNewton (ref double x,ref double y,double[,] Jacoby, ref bool checker,double toch,double iter)
        {
            for (int i = 0; i < iter; i++)
            {
                x = x - ((1 / det(createJacoby(Jacoby, x, y))) * det(createMatrixFunctionX(functionMatrix, x, y)));
                y = y - ((1 / det(createJacoby(Jacoby, x, y))) * det(createMatrixFunctionY(functionMatrix, x, y)));
                if ((Math.Cos(x * x + y * y) - x + y - 0.2) < toch && ((Math.Pow(x + y - 2, 2)) / (0.6) + Math.Pow(y - 0.1, 2) - 1) < toch)
                {
                    checker = false;
                    break;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        double[,] Yakoby(double[,] Jacoby, double x, double y)
        {
            Jacoby[0, 0] = -2 * x * Math.Sin(Math.Pow(x, 2) + Math.Pow(y, 2)) - 1;
            Jacoby[0, 1] = 1 - 2 * y * Math.Sin(Math.Pow(x, 2) + Math.Pow(y, 2));
            Jacoby[1, 0] = 3.33 * (x + y - 2);
            Jacoby[1, 1] = 3.33 * x + 5.33 * y - 6.8;
            return Jacoby;
        }

        double Determinant(double[,] Matrix_yakoby)
        {
            double determinant = Matrix_yakoby[0, 0] * Matrix_yakoby[1, 1] - Matrix_yakoby[0, 1] * Matrix_yakoby[1, 0];
            return determinant;
        }
        double[,] Func_Matrix_x(double[,] functionF, double x, double y)
        {
            functionF[0, 0] = Math.Cos(x * x + y * y) - x + y - 0.2;
            functionF[0, 1] = 1 - 2 * y * Math.Sin(Math.Pow(x, 2) + Math.Pow(y, 2));
            functionF[1, 0] = (Math.Pow(x + y - 2, 2)) / (0.6) + Math.Pow(y - 0.1, 2) - 1;
            functionF[1, 1] = 3.33 * x + 5.33 * y + 6.46;
            return functionF;
        }
        double[,] Func_Matrix_y(double[,] functionF, double x, double y)
        {
            functionF[0, 0] = -2 * x * Math.Sin(Math.Pow(x, 2) + Math.Pow(y, 2)) - 1;
            functionF[0, 1] = Math.Cos(x * x + y * y) - x + y - 0.2;
            functionF[1, 0] = 3.33 * (x + y + 2);
            functionF[1, 1] = (Math.Pow(x + y - 2, 2)) / (0.6) + Math.Pow(y - 0.1, 2) - 1;
            return functionF;
        }
    }
}
