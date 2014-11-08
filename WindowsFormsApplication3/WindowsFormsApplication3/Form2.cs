using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        double iter = 0;
        List<double> listx;
        List<double> listy;
        double result;
        int s=0;
        double[] node = {0};
        double PL = 0;
        bool check = true;
        int number = 0;
        double[] weight={0};
        double lag = 1;
        double z =0;

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
