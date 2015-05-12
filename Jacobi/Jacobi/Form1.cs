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
using System.Diagnostics;

namespace Jacobi
{
    public partial class Jacoby : Form
    {
        public static int N;
        public static double[,] matrix;
        private OpenFileDialog openFileDialog1;
        public Jacoby()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "Выберите файл:";
            openFileDialog1.Filter = "Текстовые файлы|*.txt";
            openFileDialog1.InitialDirectory = @"Z:\Documents\Visual Studio 2013\Projects\Jacobi\Jacobi\bin\Debug";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Encrypt the selected file. I'll do this later. :)
            }
            
        }

        private void Jacoby_Load(object sender, EventArgs e)
        {
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            N = int.Parse(textBox1.Text);
            matrix = new double[N,N];
            StreamReader streamReader = File.OpenText(openFileDialog1.FileName);
            for (int i = 0; i < N; i++)
            {
                String text = streamReader.ReadLine();
                String[] arrayString = text.Split(' ');
                for (int j = 0; j < N; j++)
                {
                    matrix[i, j] = double.Parse(arrayString[j]);
                }
            }
            streamReader.Close();
            label5.Text = "Сделано!!";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter("output.txt");
            /*for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    streamWriter.Write(matrix[i,j].ToString()+" ");
                }
                streamWriter.WriteLine();
            }*/
            streamWriter.WriteLine(maxElement(matrix).ToString());
            streamWriter.Close();
            Process.Start("notepad.exe", "output.txt");
        }
        private double maxElement(double[,] array){
            double answer = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i != j&&answer<Math.Abs(matrix[i,j]))
                    {
                        answer = Math.Abs(matrix[i, j]);
                    }
                }
            }
                return answer;
        }
    }
}
