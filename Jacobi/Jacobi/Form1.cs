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
        private OpenFileDialog openFileDialog1;
        static Matrix matrix;
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
            label6.Text = openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Length - 1];
        }

        private void Jacoby_Load(object sender, EventArgs e)
        {
             
        }

        private void button3_Click(object sender, EventArgs e)
        {
            N = int.Parse(textBox1.Text);
            matrix = new Matrix(N, N);
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
            //streamWriter.WriteLine(maxElement(matrix).ToString());
            /*int[] position = new int[2];
            position = maxElement(matrix);
            double angle = searchAngle(matrix, position);
            matrix = rotationMatrix(position, angle);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    streamWriter.Write(matrix[i, j].ToString() + " ");
                }
                streamWriter.WriteLine();
            }*/
            streamWriter.Close();
            Process.Start("notepad.exe", "output.txt");
        }
        private double searchAngle(double[,] array,int[] posArr)
        {
            double answer = 0;
            if (array[posArr[0], posArr[0]] - array[posArr[1], posArr[1]] == 0 && 2 * array[posArr[0], posArr[1]] > 0)
                answer = Math.PI / 4;
            else if (array[posArr[0], posArr[0]] - array[posArr[1], posArr[1]] == 0 && 2 * array[posArr[0], posArr[1]] < 0)
                answer = -Math.PI / 4;
            else if (array[posArr[0], posArr[0]] - array[posArr[1], posArr[1]] != 0)
                answer = (Math.Atan((2 * array[posArr[0], posArr[1]]) / (array[posArr[0], posArr[0]] - array[posArr[1], posArr[1]]))) / 2;
            return answer;
        }
        private double[,] rotationMatrix(int[] posArr,double angle)
        {
            double[,] answerArray = onetityMatrix(3);
            double newAngle = Math.Cos(angle);
            double newAngleS = Math.Sin(angle);
            for (int i = 0; i < N; i++)
                for (int j = 0; j < N; j++)
                {
                    if (i == posArr[0])
                    {
                        answerArray[i, i] = newAngle;
                        if (j == posArr[1])
                        {
                            answerArray[j, j] = newAngle;
                            answerArray[i, j] = -newAngleS;
                            answerArray[j, i] = newAngleS;
                        }
                    }
                }
           return answerArray;
        }
        private double[,] onetityMatrix(int n)
        {
            double[,] answerArray = new double[n, n];
            for(int i=0;i<n;i++)
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                        answerArray[i, j] = 1;
                    else answerArray[i, j] = 0;
                }
            return answerArray;
        }
    }
}
