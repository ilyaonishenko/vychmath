using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
        double[,] answer;
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
            label9.Text = "not done";
            openFileDialog1 = new OpenFileDialog();
            matrix = null;
            angle = 0;
            greatI = 0;
            greatJ = 0;
            answer = null;
            N = 0;
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
            label7.Text = "";
            N = int.Parse(textBox1.Text);
            matrix = new double[N, N];
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
        private void JacobyMethod(double E, double[] array, int _i, int _j)
        {
            maxElement();
            searchAngle();
            double[] angleArray = new double[2];
            angleArray[0] = Math.Sin(angle);
            angleArray[1] = Math.Cos(angle);
            while (E < norma)
            {
                hopeNotStupid(array, _i, _j);
                norma = Norma();
                maxElement();
                searchAngle();
                angleArray[0] = Math.Sin(angle);
                angleArray[1] = Math.Cos(angle);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            label9.Text = "done";
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            //E = double.Parse(textBox2.Text);
            //change(rotationMatrix,matrix);
            maxElement();
            searchAngle();
            double[] angleArray = new double[2];
            angleArray[0] = Math.Sin(angle);
            angleArray[1] = Math.Cos(angle);
            norma = 1000;
            //rotationMatrix.rotationMatrix();            
            //change(invertedRotationMatrix, rotationMatrix);
            //invertedRotationMatrix = invertedRotationMatrix.Transpose(invertedRotationMatrix);
            //invertedRotationMatrix = invertedRotationMatrix.Invert();
            //invertedRotationMatrix.Transpose();
            //StreamWriter streamWriter = new StreamWriter("output.txt");
            E = 0.01;
            //while (norma > E)
            //{

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
            /*hopeNotStupid(angleArray,greatI,greatJ);


                norma = Norma();
                //change(rotationMatrix, matrix);
                maxElement();
                searchAngle();
                //rotationMatrix.rotationMatrix();
                angleArray[0] = Math.Sin(angle);
                angleArray[1] = Math.Cos(angle);
                //change(invertedRotationMatrix, rotationMatrix);
                //invertedRotationMatrix.Transpose();
            }*/
            if (N < 10)
            {
                maxElement();
                searchAngle();
                angleArray = new double[2];
                angleArray[0] = Math.Sin(angle);
                angleArray[1] = Math.Cos(angle);
                E = 1;
                while (norma > E)
                {
                    hopeNotStupid(angleArray, greatI, greatJ);
                    norma = Norma();
                    maxElement();
                    searchAngle(); 
                    angleArray[0] = Math.Sin(angle);
                    angleArray[1] = Math.Cos(angle);
                }
            }
            if (N >= 10&&N<64)
            {
                answer = QRalgorithm(matrix, 0.1);
                
            }
            else if (N >= 64)
            {
                answer = QRalgorithm1(matrix, 0.1);
                if (N<300)
                    Thread.Sleep(10000);
            }
            stopwatch.Stop();
            TimeSpan ts = stopwatch.Elapsed;
            string time = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
            label8.Text = time;
            StreamWriter streamWriter0 = new StreamWriter("time.txt", true);
            streamWriter0.Write("N= " + N + " ");
            streamWriter0.Write("E= " + E + " ");
            streamWriter0.Write(time + "\n");
            streamWriter0.Close();
            StreamWriter streamWriter = new StreamWriter("output.txt");
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (N >= 10)
                    {
                        if (i != j)
                        {
                            answer[i, j] = 0;
                        }
                        streamWriter.Write(answer[i, j] + " ");
                    }
                    else
                    {
                        if (i != j)
                        {
                            streamWriter.Write(0 + " ");
                        }
                        else
                        streamWriter.Write(matrix[i, j] + " ");
                    }
                }
                streamWriter.WriteLine();
            }
            //streamWriter.WriteLine(norma);
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
            /*for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (array2[i, j] != 0)
                        matrix[i, j] = array2[i, j];
                }
            }*/
            matrix[_i, _i] = array2[_i, _i];
            matrix[_j, _j] = array2[_j, _j];
            matrix[_i, _j] = matrix[_j, _i] = array2[_i, _j];
            for (int k = 0; k < N; k++)
            {
                if (k != _j && k != _i)
                {
                    matrix[_i, k] = array2[_i, k];
                    matrix[k, _i] = array2[_i, k];
                    matrix[_j, k] = array2[_j, k];
                    matrix[k, _j] = array2[_j, k];
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
        double[,] Submatrix(double[,] A, int m1, int m2, int n1, int n2)
        {
            double[,] C = new double[m2 - m1 + 1, n2 - n1 + 1];
            for (int i = m1; i <= m2; i++)
                for (int j = n1; j <= n2; j++)
                {
                    C[i - m1, j - n1] = A[i, j];
                }
            return C;
        }
        double[,] Transpose(double[,] A)
        {
            int m = A.GetLength(0);
            int n = A.GetLength(1);
            double[,] C = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    C[i, j] = A[j, i];
                }
            }
            return C;
        }
        double AbsVector(double[,] x)
        {
            double sum = 0;
            for (int i = 0; i < x.GetLength(0); i++)
            {
                sum += Math.Pow(x[i, 0], 2.0);
            }
            return Math.Pow(sum, 0.5);
        }
        double[,] Multiply(double[,] A, double w)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] *= w;
                }
            }
            return A;
        }
        double[,] Multiply(double[,] A, double[,] B)
        {
            if (A.GetLength(1) != B.GetLength(0))
            {
                MessageBox.Show("Something Wrong");
            }
            int m = A.GetLength(0);
            int k = B.GetLength(1);
            int n = A.GetLength(1);
            double[,] C = new double[m, k];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    C[i, j] = 0;
                    for (int r = 0; r < n; r++)
                    {
                        C[i, j] += A[i, r] * B[r, j];
                    }

                }
            }
            return C;
        }
        double[,] Identity(int n)
        {
            double[,] matrix = new double[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == j)
                    {
                        matrix[i, j] = 1;
                    }
                    else
                        matrix[i, j] = 0;
                }
            }
            return matrix;
        }
        double[,] House(double[,] x)
        {
            int n = x.GetLength(0);
            double u = AbsVector(x);
            double tmp = x[0, 0];
            int l = 0;
            bool bl = true;
            if (u != 0)
            {
                while (bl)
                {
                    if (x[l, 0] == 0)
                    {
                        l++;
                    }
                    else
                    {
                        tmp = x[l, 0];
                        break;
                    }
                }
                double b = tmp + Math.Sign(tmp) * u;
                for (int i = 1; i < n; i++)
                {
                    x[i, 0] = x[i, 0] / b;
                }
            }
            x[0, 0] = 1;
            return x;
        }

        double Givens(double a, double b)
        {
            double c = 0, s = 0, tau = 0;
            if (b == 0)
            {
                c = 1;
                s = 0;
            }
            else
            {
                if (Math.Abs(b) > Math.Abs(a))
                {
                    tau = -a / b;
                    s = 1 / (Math.Pow(1 + Math.Pow(tau, 2), 0.5));
                    c = s * tau;
                }
                else
                {
                    tau = -b / a;
                    c = 1 / (Math.Pow(1 + Math.Pow(tau, 2), 0.5));
                    s = c * tau;
                }
            }
            return Math.Asin(s);
        }
        double[,] G(int m, int k, double tetta, int n)
        {
            double[,] matrix = Identity(n);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j == (m) && i == (m))
                    {
                        matrix[i, j] = -Math.Cos(tetta);
                    }
                    if (j == (k) && i == (k))
                    {
                        matrix[i, j] = Math.Cos(tetta);
                    }
                    if (j == (k) && i == (m))
                    {
                        matrix[i, j] = Math.Sin(tetta);
                    }
                    if (j == (m) && i == (k))
                    {
                        matrix[i, j] = Math.Sin(tetta);
                    }
                }
            }
            return matrix;
        }
        double[,] Treshka(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] B = A;
            double[,] p;
            double[,] w;
            double[,] help;
            double[,] vwT;
            double[,] wvT;
            double[,] E;
            double[,] helpW;
            double lpl = 0;
            double[,] vect1;
            double[,] tmpA;
            for (int k = 0; k < n - 2; k++)
            {
                vect1 = Submatrix(A, k + 1, n - 1, k, k);
                vect1 = House(vect1);
                p = Multiply(Multiply(Submatrix(A, k + 1, n - 1, k + 1, n - 1), 2), vect1);
                help = Multiply(Transpose(vect1), vect1);
                double low = help[0, 0];
                p = Division(p, low);
                helpW = Multiply(vect1, Multiply(Transpose(p), vect1));
                helpW = Division(helpW, low);
                w = Minus(p, helpW);
                tmpA = Submatrix(A, k + 1, n - 1, k + 1, n - 1);
                vwT = Multiply(vect1, Transpose(w));
                wvT = Multiply(w, Transpose(vect1));
                tmpA = Minus(Minus(tmpA, vwT), wvT);
                E = Identity(n - k - 1);
                help = Multiply(Minus(E, Division(Multiply(Multiply(vect1, Transpose(vect1)), 2), low)), Submatrix(A, k + 1, n - 1, k, k));
                for (int i = k + 1; i < n; i++)
                {
                    for (int j = k + 1; j < n; j++)
                    {
                        B[i, j] = tmpA[i - k - 1, j - k - 1];
                    }
                    B[i, k] = -help[i - k - 1, 0];
                    B[k, i] = B[i, k];
                }
            }
            return B;
        }
        double[,] Division(double[,] A, double w)
        {
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    A[i, j] /= w;
                }
            }
            return A;
        }
        double[,] Minus(double[,] A, double[,] B)
        {
            int n = A.GetLength(0);
            int m = A.GetLength(1);
            double[,] C = new double[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    C[i, j] = A[i, j] - B[i, j];
                }
            }
            return C;
        }
        double[,] Shift(double[,] A)
        {
            int n = A.GetLength(0);
            double[,] T = A;
            double[,] F;
            double d = (T[n - 2, n - 2] - T[n - 1, n - 1]) / 2;
            double mu = T[n - 1, n - 1] - (Math.Pow(T[n - 1, n - 2], 2) / (d + Math.Sign(d) * Math.Pow(Math.Pow(d, 2) + Math.Abs(T[n - 1, n - 2]), 0.5)));
            double x = T[0, 0] - mu;
            double z = T[1, 0];
            for (int k = 0; k < n - 1; k++)
            {
                F = G(k, k + 1, Givens(x, z), n);
                T = Multiply(Multiply(Transpose(F), T), F);
                if (k < (n - 2))
                {
                    x = T[k + 1, k];
                    z = T[k + 2, k];
                }
            }
            return T;
        }
        double[,] QRalgorithm(double[,] A, double eps)
        {
            double[,] M = Proverka(A);
            double[,] T = Treshka(M);
            int n = T.GetLength(0);
            int p = n;
            double[,] tmpT;
            while (p != 0)
            {
                tmpT = Submatrix(T, 0, p - 1, 0, p - 1);
                tmpT = Shift(tmpT);
                for (int i = 0; i < p; i++)
                {
                    for (int j = 0; j < p; j++)
                    {
                        T[i, j] = tmpT[i, j];
                    }
                }
                /* for (int j = n - 2; j >= 0; --j)
                 {
                     if (Math.Abs(T[j + 1, j]) < Math.Pow(10, -7))
                     {
                         T[j + 1, j] = 0;
                         T[j, j + 1] = 0;
                     }
                 }*/
                for (int i = n - 2; i >= 0; i--)
                {
                    if (Math.Abs(T[i + 1, i]) <= eps * (Math.Abs(T[i, i]) + Math.Abs(T[i + 1, i + 1])))
                    {
                        p = i;
                        T[i + 1, i] = 0;
                        T[i, i + 1] = 0;
                    }
                    else
                    {
                        p = i + 2;
                        break;
                    }
                }
            }
            return T;
        }
        double[,] Proverka(double[,] A)
        {
            int n = A.GetLength(0);
            int d;
            double[,] v = Submatrix(A, 1, n - 1, 0, 0);
            if (AbsVector(v) != 0)
            {
                d = 0;
            }
            else
            {
                d = 1;
            }
            int m = n - d;

            double[,] T = new double[m, m];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    T[i, j] = A[i + d, j + d];
                }
            }
            return T;
        }

        double[,] QRalgorithm1(double[,] A, double eps)
        {
            double[,] M = Proverka(A);
            double[,] T = Treshka(M);
            int n = T.GetLength(0);
            int p = n;
            double[,] tmpT;
            while (p != 0)
            {
                tmpT = Submatrix(T, p - 2, p - 1, p - 2, p - 1);
                tmpT = Shift(tmpT);


                for (int i = p - 2; i < p; i++)
                {
                    for (int j = p - 2; j < p; j++)
                    {
                        T[i, j] = tmpT[i - p + 2, j - p + 2];
                    }
                }
                for (int i = n - 2; i >= 0; i--)
                {
                    if (Math.Abs(T[i + 1, i]) <= eps * (Math.Abs(T[i, i]) + Math.Abs(T[i + 1, i + 1])))
                    {
                        p = i;
                        T[i + 1, i] = 0;
                        T[i, i + 1] = 0;
                    }
                    else
                    {
                        p = i + 2;
                        break;
                    }
                }
            }
            return T;
        }
    }
}
