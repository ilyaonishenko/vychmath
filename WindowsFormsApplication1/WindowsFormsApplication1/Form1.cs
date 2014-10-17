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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        double a = 0; //первая переменная для дифура
        double b = 0; //вторая переменная для дифура
        int d = 0;//переменная для построения графика
        double c1 = 0;//первый коэффициент
        double c2 = 0;//второй коэффициент
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].Points.Clear();//построение графика
            double y = 0;
            /*if (d==1)
            {
                int i = d;
                y = (-3 / 2 + 3 * i - (9 / 4) * Math.Pow(i, 2) + Math.Pow(i, 3) - (1 / 4) * Math.Pow(i, 4)) * Math.Cos(i * 2) + ((c1 * Math.Cos(Math.Sqrt(3) * i)) / Math.Exp(i)) + (-(45 / 8) + (21 / 4) * i - (9 / 4) * Math.Pow(i, 2) + (1 / 2) * Math.Pow(i, 3)) * Math.Sin(2 * i) + ((c2 * Math.Sin(Math.Sqrt(3))) / Math.Exp(i));
                chart1.Series["Series1"].Points.AddXY(i, y);
                chart1.Series["Series1"].Points.AddXY(0, y);
            }*/
            //else { 
            for (double i=0;i<=d;i+=0.01)
            {
                y = (-3/2+3*i-(9/4)*Math.Pow(i,2)+Math.Pow(i,3)-(1/4)*Math.Pow(i,4))*Math.Cos(i*2)+((c1*Math.Cos(Math.Sqrt(3)*i))/Math.Exp(i))+(-(45/8)+(21/4)*i-(9/4)*Math.Pow(i,2)+(1/2)*Math.Pow(i,3))*Math.Sin(2*i)+((c2*Math.Sin(Math.Sqrt(3)))/Math.Exp(i));
                chart1.Series["Series1"].Points.AddXY(i, y);
            }
        //}
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string n = "null";//не используются
            string o = "over";//ничего
            string l = "literal";//не используется
            bool num = false;
            try
            {
                num = double.TryParse(textBox1.Text, out a);
                if (num) {      }
                else
                {
                    throw new myException1_1("Not number!");
                    num = false;
                }
                if (a>999999999)
                {
                    throw new myException3_1("a lot");
                }
            }
            catch (myException1_1 ex)
            {
                button2.Enabled = false;
                MessageBox.Show("a не число");
            }
            catch (myException3_1 ex)
            {
                button2.Enabled = false;
                MessageBox.Show("a очень большое число!");
            }
            try
            {
                num = double.TryParse(textBox2.Text, out b);
                if (num) {      }
                else
                {
                    throw new myException1_2("Not number!");
                    num = false;
                }
                if (b>999999999)
                {
                    throw new myException3_2("a lot");
                }
            }
            catch (myException1_2 ex)
            {
                button2.Enabled = false;
                MessageBox.Show("b не число");
            }
            catch (myException3_2 ex)
            {
                button2.Enabled = false;
                MessageBox.Show("b слишком большое число ");
            }
            try
            {

                if (num = int.TryParse(textBox3.Text, out d)) { }
                else
                {
                    throw new myException1_3();
                    num = false;
                }
                if (Math.Abs(d)==0)
                {
                    throw new myException2_1();
                    num = false;
                }
            }
            catch (myException1_3 ex)
            {
                button2.Enabled = false;
                MessageBox.Show("d не число");
            }
            catch (myException2_1 ex)
            {
                button2.Enabled = false;
                MessageBox.Show("d не должен быть нулём");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Ошибка переполнения");
            }
            c1 = Math.Round(57/8+a,3) ;
            c2 = Math.Round((33/4+b + c1) / Math.Sqrt(3),3);
            label4.Text = "Коэффициенты: с1 = " + c1 + " с2 = " + c2;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;
        }
    }
    public class myException1_1:System.Exception
    {
        public myException1_1() : base() { }
        public myException1_1(string message):base(message){}
        public myException1_1(string message, Exception inner) : base(message, inner) { }
    }
    public class myException1_2 : System.Exception
    {
        public myException1_2() : base() { }
        public myException1_2(string message) : base(message) { }
        public myException1_2(string message, Exception inner) : base(message, inner) { }
    }
    public class myException1_3:System.Exception
    {
        public myException1_3() : base() { }
        public myException1_3(string message):base(message){}
        public myException1_3(string message, Exception inner) : base(message, inner) { }
    }
    public class myException2_1:System.Exception
    {
        public myException2_1() : base() { }
        public myException2_1(string message):base(message){}
        public myException2_1(string message, Exception inner) : base(message, inner) { }
    }
    public class myException3_1 : System.Exception
    {
        public myException3_1() : base() { }
        public myException3_1(string message) : base(message) { }
        public myException3_1(string message, Exception inner) : base(message, inner) { }
    }
    public class myException3_2 : System.Exception
    {
        public myException3_2() : base() { }
        public myException3_2(string message) : base(message) { }
        public myException3_2(string message, Exception inner) : base(message, inner) { }
    }
}
