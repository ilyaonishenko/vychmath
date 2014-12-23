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
            //textBox4.Visible = false;
            //label7.Visible = false;
            label8.Text = "Cos(x^2+y^2)-x+y-0.2=0";
            label9.Text = "(((x+y-2)^2)/0.6)+(y-0.1)^2-1=0";
            label8.Visible = false;
            label9.Visible = false;
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
            if (x>=1||y>=1)
            {
                //MessageBox.Show("Вы ввели слишком большие приближенные значения");
                //x = x * 0.1;
                //y = y * 0.1;
            }
            /*num = int.TryParse(textBox3.Text, out iter);
            if (!num&&goOn==true)
            {
                goOn = false;
                MessageBox.Show("Вы неверно ввели количество итераций");
            }*/
            if (x > 2.8 || y > 2.8)
            {
                x = x / 100000 + 2.8;
                y = y / 100000 + 2.8;
            }
            /*if (y>2.8)
            {
                y = y / 100000 + 2.8;
            }*/
            if (x < -2.8 || y < -2.8)
            {
                x = -2.8 + x / 100000;
                y = -2.8 + y / 100000;
            }
           /* if (y<-2.8)
            {
                y = -2.8 + y / 100000;
            }*/
            num = double.TryParse(textBox4.Text, out toch);
            if (!num&&goOn==true)
            {
                goOn = false;
                MessageBox.Show("Вы неверно ввели точность");
            }
            if (toch<=0.0001)
            {
                goOn = false;
                MessageBox.Show("Слишком точно!");
            }
            Jacoby = new double[2, 2];
            Jacoby = createJacoby(Jacoby, x, y);
            functionMatrix = new double[2, 2];
            double[,] Obr = new double[2, 2];
            double[,] AlgDop = new double[2, 2];
            AlgDop[0, 0] = Jacoby[1, 1];
            AlgDop[0, 1] = -Jacoby[1, 0];
            AlgDop[1, 0] = -Jacoby[0, 1];
            AlgDop[1, 1] = Jacoby[0, 0];
            double DETALG = 1/det(AlgDop);
            Obr[0, 0] = DETALG*Jacoby[1, 1];
            Obr[1, 1] = DETALG * Jacoby[0, 0];
            Obr[0, 1] = -DETALG * Jacoby[0, 1];
            Obr[1, 0] = -DETALG * Jacoby[1, 0];
            if (goOn == true)
            {
                double x_1 = 0;
                double y_1 = 0;
                for (int i = 0; ; i+=1)
                {
                    //x_1 = x - detObr(Jacoby, x, y) * det(createMatrixFunctionX(functionMatrix, x, y));
                    //y_1 = y - detObr(Jacoby, x, y) * det(createMatrixFunctionY(functionMatrix, x, y));
                    //x_1 = x - (1/det(createJacoby(Jacoby, x, y))) * det(createMatrixFunctionX(functionMatrix, x, y));
                    //y_1 = y - (1/det(createJacoby(Jacoby,x,y)))*det(createMatrixFunctionY(functionMatrix,x,y));
                    x_1 = x - det(Obr)* det(createMatrixFunctionX(functionMatrix, x, y));//do 2x rabotaet
                    y_1 = y - det(Obr) * det(createMatrixFunctionY(functionMatrix, x, y));
                    //x_1 = x - det(Obr) * F(x, y);
                    //y_1 = y - det(Obr) * G(x, y);
                    x = Math.Round(x_1, 4);
                    y = Math.Round(y_1, 4);
                    if (Math.Abs(Math.Cos(x * x + y * y) - x + y - 0.2) < toch && Math.Abs((Math.Pow(x + y - 2, 2)) / (0.6) + Math.Pow(y - 0.1, 2) - 1) < toch)
                    {
                        break;
                    }
                }
                textBox5.Text = x.ToString();
                textBox6.Text = y.ToString();
            }
        }
        double detObr(double[,] matrix,double x,double y)
        {
            matrix = createJacoby(matrix, x, y);
            double[,] Obr = new double[2, 2];
            double[,] AlgDop = new double[2, 2];
            AlgDop[0, 0] = matrix[1, 1];
            AlgDop[0, 1] = -matrix[1, 0];
            AlgDop[1, 0] = -matrix[0, 1];
            AlgDop[1, 1] = matrix[0, 0];
            double DETALG = 1 / det(AlgDop);
            Obr[0, 0] = DETALG * matrix[1, 1];
            Obr[1, 1] = DETALG * matrix[0, 0];
            Obr[0, 1] = -DETALG * matrix[0, 1];
            Obr[1, 0] = -DETALG * matrix[1, 0];
            double zz = 0;
            zz = det(Obr);
            return zz;
        }
        double F(double x,double y)
        {
            return Math.Cos(x * x + y * y) - x + y - 0.2;
        }
        double G(double x,double y)
        {
            return ((Math.Pow(x + y - 2, 2)) / (0.6)) + Math.Pow(y - 0.1, 2) - 1;
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
    }
}
