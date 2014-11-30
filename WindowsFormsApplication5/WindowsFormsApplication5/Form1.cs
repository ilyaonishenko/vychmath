using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class Form1 : Form
    {
        bool num = false;
        double h = 0;
        double y1 = 0; // y1
        double y2 = 0;
        double y10 = 0;
        double y20 = 0;
        double y11 = 0;
        double y22 = 0;
        double from = 0;
        double to = 0;
        double k1 = 0, k2 = 0, k3 = 0, k4 = 0;
        double q1 = 0, q2 = 0, q3 = 0, q4 = 0;
        public Form1()
        {
            InitializeComponent();
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
            int textboxbool = 0;
            if (textBox1.Text != "")
                textboxbool++;
            if (textBox2.Text != "")
                textboxbool++;
            if (textBox3.Text != "")
                textboxbool++;
            if (textBox4.Text != "")
                textboxbool++;
            if (textboxbool == 4)
                button1.Enabled = true;
            num = double.TryParse(textBox1.Text, out y1);
            if (!num)
            {

            }
            num = double.TryParse(textBox2.Text, out y2);
            if (!num)
            {

            }
            num = double.TryParse(textBox3.Text, out y10);
            if (!num)
            {

            }
            num = double.TryParse(textBox4.Text, out from);
            if (!num)
            {

            }
            num = double.TryParse(textBox7.Text, out to);
            if (!num)
            {

            }
            num = double.TryParse(textBox8.Text, out h);
            if (!num)
            {

            }
            for (double i=from;i<to+0.001;i+=h)
            {
                k1 = h * func1(y1, y2);
                q1 = h * func2(y1, y2);
                k2 = h * func1(y1 + h / 2, y2 + q1 / 2);
                q2 = h * func2(y1 + h / 2, y2 + q1 / 2);
                k3 = h * func1(y1 + h / 2, y2 + q2 / 2);
                q3 = h * func2(y1 + h / 2, y2 + q2 / 2);
                k4 = h * func1(y1 + h, y2 + q3);
                q4 = h * func2(y1 + h, y2 + q3);
                y11 = Runge(k1,k2,k3,k4,y10);
                y22 = Runge(q1,q2,q3,q4,y20);
                y10 = y11;
                y20 = y22;
            }
            textBox5.Text = y10.ToString();
            textBox6.Text = y20.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //button1.Enabled = false;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
        }
    }
}
