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
        static Matrix rotationMatrix;
        static Matrix invertedRotationMatrix;
        static Matrix identityMatrix;
        static double norma = 10000;
        static double E = 0;
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
            }
            label6.Text = openFileDialog1.FileName.Split('\\')[openFileDialog1.FileName.Split('\\').Length - 1];
        }

        private void Jacoby_Load(object sender, EventArgs e)
        {
            /*
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture; */
        }
        // 25x25 with 1 = 4.65
        // 25x25 with 5 = 4.69
        // 50x50 with 1 = 3.57.64

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
            label5.Text = "";
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        label7.Text += matrix[i, j];
                        label7.Text += "          ";
                    }
                    label7.Text += Environment.NewLine;
                    label7.Text += Environment.NewLine;
                }
            }
            label5.Text = "Сделано!!";
            rotationMatrix = new Matrix(N, N);
            invertedRotationMatrix = new Matrix(N, N);
            //identityMatrix = Matrix.IdentityMatrix(N, N);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            E = double.Parse(textBox2.Text);
            change(rotationMatrix,matrix);
            rotationMatrix.maxElement();
            rotationMatrix.searchAngle();
            rotationMatrix.rotationMatrix();            
            change(invertedRotationMatrix, rotationMatrix);
            //invertedRotationMatrix = invertedRotationMatrix.Transpose(invertedRotationMatrix);
            //invertedRotationMatrix = invertedRotationMatrix.Invert();
            invertedRotationMatrix.Transpose();
            StreamWriter streamWriter = new StreamWriter("output.txt");
            //while (norma > E)
            //{

            streamWriter.WriteLine("matrix");
            streamWriter.WriteLine(matrix);
            streamWriter.WriteLine("inverted");
            streamWriter.WriteLine(invertedRotationMatrix);
            streamWriter.WriteLine("rotation");
            streamWriter.WriteLine(rotationMatrix);
            int psevdoI = rotationMatrix.MAINI();
            int psevdoJ = rotationMatrix.MAINJ();
            //streamWriter.WriteLine("psevdoi " + psevdoI);
            //streamWriter.WriteLine("psevdoj " + psevdoJ);
            //matrix = invertedRotationMatrix * matrix * rotationMatrix;
            //matrix = matrix.StupidMultiply(invertedRotationMatrix, matrix);
                //matrix = matrix.SimmetricMultiply1(invertedRotationMatrix, matrix);
            //matrix = matrix.StupidSimmetricMultiply(invertedRotationMatrix, matrix);
            matrix = matrix.MaybeNotStupidMultiplyR(invertedRotationMatrix, matrix, psevdoI, psevdoJ);
                
            streamWriter.WriteLine("matrix");
            streamWriter.WriteLine(matrix);
            //matrix = matrix.StupidSimmetricMultiply(matrix, rotationMatrix);
            //matrix = matrix.SimmetricMultiply1(matrix, rotationMatrix);
                //matrix = matrix.StupidMultiply(matrix, rotationMatrix);
            matrix = matrix.MaybeNotStupidMultiplyL(matrix, rotationMatrix, psevdoJ, psevdoI);
                //identityMatrix = identityMatrix * rotationMatrix;
            streamWriter.WriteLine("matrix");
            streamWriter.WriteLine(matrix);



                norma = matrix.Norma();
                change(rotationMatrix, matrix);
                rotationMatrix.maxElement();
                rotationMatrix.searchAngle();
                rotationMatrix.rotationMatrix();
                change(invertedRotationMatrix, rotationMatrix);
                invertedRotationMatrix.Transpose();
            //}
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string time = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            label8.Text = time;
            StreamWriter streamWriter0 = new StreamWriter("time.txt",true);
            streamWriter0.Write("N= " + N + " ");
            streamWriter0.Write("E= " + E + " ");
            streamWriter0.Write(time + "\n");
            streamWriter0.Close();
            //StreamWriter streamWriter = new StreamWriter("output.txt");
            streamWriter.WriteLine(matrix);
            streamWriter.WriteLine(norma);
            streamWriter.Close();
            Process.Start("notepad.exe", "output.txt");
        }
        private void change(Matrix m1, Matrix m2)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    m1[i, j] = m2[i, j];
                }
            }
        }
    }
}
