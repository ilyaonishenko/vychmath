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
        static double norma = 10000;
        static double E = 0;
        double[,] matrix;
        int greatI = 0;
        int greatJ = 0;
        double angle = 0;
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
            //rotationMatrix = new Matrix(N, N);
            //invertedRotationMatrix = new Matrix(N, N);
            //identityMatrix = Matrix.IdentityMatrix(N, N);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            E = double.Parse(textBox2.Text);
            //change(rotationMatrix,matrix);
            maxElement();
            searchAngle();
            double[] angleArray = new double[2];
            angleArray[0] = Math.Sin(angle);
            angleArray[1] = Math.Cos(angle);
            //rotationMatrix.rotationMatrix();            
            //change(invertedRotationMatrix, rotationMatrix);
            //invertedRotationMatrix = invertedRotationMatrix.Transpose(invertedRotationMatrix);
            //invertedRotationMatrix = invertedRotationMatrix.Invert();
            //invertedRotationMatrix.Transpose();
            //StreamWriter streamWriter = new StreamWriter("output.txt");
            while (norma > E)
            {

            /*streamWriter.WriteLine("matrix");
            streamWriter.WriteLine(matrix);
            streamWriter.WriteLine("inverted");
            streamWriter.WriteLine(invertedRotationMatrix);
            streamWriter.WriteLine("rotation");
            streamWriter.WriteLine(rotationMatrix);*/
            //streamWriter.WriteLine("psevdoi " + psevdoI);
            //streamWriter.WriteLine("psevdoj " + psevdoJ);
            //matrix = invertedRotationMatrix * matrix * rotationMatrix;
           // matrix = matrix.StupidMultiply(invertedRotationMatrix, matrix);
                //matrix = matrix.SimmetricMultiply1(invertedRotationMatrix, matrix);
            //matrix = matrix.StupidSimmetricMultiply(invertedRotationMatrix, matrix);
            //matrix = matrix.MaybeNotStupidMultiplyR(invertedRotationMatrix, matrix, psevdoI, psevdoJ);
                
            //streamWriter.WriteLine("matrix");
            //streamWriter.WriteLine(matrix);
            //matrix = matrix.StupidSimmetricMultiply(matrix, rotationMatrix);
            //matrix = matrix.SimmetricMultiply1(matrix, rotationMatrix);
              //  matrix = matrix.StupidMultiply(matrix, rotationMatrix);
            //matrix = matrix.MaybeNotStupidMultiplyL(matrix, rotationMatrix, psevdoJ, psevdoI);
                //identityMatrix = identityMatrix * rotationMatrix;
            //streamWriter.WriteLine("matrix");
            //streamWriter.WriteLine(matrix);
            hopeNotStupid(angleArray,greatI,greatJ);


                norma = Norma();
                //change(rotationMatrix, matrix);
                maxElement();
                searchAngle();
                //rotationMatrix.rotationMatrix();
                angleArray[0] = Math.Sin(angle);
                angleArray[1] = Math.Cos(angle);
                //change(invertedRotationMatrix, rotationMatrix);
                //invertedRotationMatrix.Transpose();
            }
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
            StreamWriter streamWriter = new StreamWriter("output.txt");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                    streamWriter.Write(matrix[i,j]+" ");
                streamWriter.WriteLine();
            }
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
        public void searchAngle()
        {
            double answer = 0;
            if (matrix[greatI, greatI] - matrix[greatJ, greatJ] == 0 && 2 * matrix[greatI, greatJ] > 0)
                answer = Math.PI / 4;
            else if (matrix[greatI, greatI] - matrix[greatJ, greatJ] == 0 && 2 * matrix[greatI, greatJ] < 0)
                answer = -Math.PI / 4;
            else if (matrix[greatI, greatI] - matrix[greatJ, greatJ] != 0)
                answer = (Math.Atan((2 * matrix[greatI, greatJ]) / (matrix[greatI, greatI] - matrix[greatJ, greatJ]))) / 2;
            this.angle = answer;
        }
        public void hopeNotStupid(double[] array, int _i, int _j)
        {
            double[,] array2 = new double[N, N];
            array2[_i, _i] = array[1] * array[1] * matrix[_i, _i] - 2 * array[0] * array[1] * matrix[_i, _j] + array[0] * array[0] * matrix[_j, _j];
            array2[_j, _j] = array[0] * array[0] * matrix[_i, _i] + 2 * array[0] * array[1] * matrix[_i, _j] + array[1] * array[1] * matrix[_j, _j];
            array2[_i, _j] = (array[1] * array[1] - array[0] * array[0]) * matrix[_i, _j] + array[0] * array[1] * (matrix[_i, _i] - matrix[_j, _j]);
            array2[_j, _i] = array2[_i, _j];
            for (int k = 0; k < N; k++)
            {
                if (k != _j && k != _i)
                {
                    array2[_i, k] = array[1] * matrix[_i, k] - array[0] * matrix[_j, k];
                    array2[_j, k] = array[0] * matrix[_i, k] + array[1] * matrix[_j, k];
                }
                array2[k, _i] = array2[_i, k];
                array2[k, _j] = array2[_j, k];
            }
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (array2[i, j] != 0)
                        matrix[i, j] = array2[i, j];
                }
            }
        }
        public void maxElement()
        {
            double answer = 0;
            int _i = 0;
            int _j = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i != j && answer < Math.Abs(matrix[i, j]))
                    {
                        answer = Math.Abs(matrix[i, j]);
                        _i = i;
                        _j = j;
                    }
                }
            }
            greatI = _i;
            greatJ = _j;
        }
        public double Norma()
        {
            double answer = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (i < j)
                    {
                        answer += Math.Pow(matrix[i, j], 2);
                    }
                }
            }
            answer = Math.Sqrt(answer);
            return answer;
        } 
    }
}
