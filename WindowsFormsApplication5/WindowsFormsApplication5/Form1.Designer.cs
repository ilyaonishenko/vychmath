namespace WindowsFormsApplication5
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "Рассчитать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "у1(0) =";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(122, 106);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(210, 31);
            this.textBox1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "у2(0) = ";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(112, 160);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(220, 31);
            this.textBox2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 389);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 26);
            this.label3.TabIndex = 5;
            this.label3.Text = "Шаг:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(112, 386);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(220, 31);
            this.textBox3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 224);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "t =";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(112, 224);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(220, 31);
            this.textBox4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 731);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 26);
            this.label5.TabIndex = 9;
            this.label5.Text = "y1(t) =";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(106, 728);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(247, 31);
            this.textBox5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 789);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 26);
            this.label6.TabIndex = 11;
            this.label6.Text = "y2(t) = ";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(106, 789);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(247, 31);
            this.textBox6.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 26);
            this.label7.TabIndex = 13;
            this.label7.Text = "a = ";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(112, 278);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(220, 31);
            this.textBox7.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(22, 332);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 26);
            this.label8.TabIndex = 15;
            this.label8.Text = "b =";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(112, 329);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(220, 31);
            this.textBox8.TabIndex = 16;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(463, 40);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "y1(t)";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "y2(t)";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Size = new System.Drawing.Size(902, 833);
            this.chart1.TabIndex = 17;
            this.chart1.Text = "chart1";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(186, 440);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 41);
            this.button2.TabIndex = 18;
            this.button2.Text = "Файл";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(121, 507);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(146, 41);
            this.button3.TabIndex = 19;
            this.button3.Text = "Построить график";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(121, 830);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(146, 41);
            this.button4.TabIndex = 20;
            this.button4.Text = "Выход";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 565);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 26);
            this.label9.TabIndex = 21;
            this.label9.Text = "Шаг:";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(363, 160);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(69, 30);
            this.radioButton1.TabIndex = 22;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "silv";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(363, 219);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(92, 30);
            this.radioButton2.TabIndex = 23;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "runge";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1377, 885);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Решение системы дифференциальных уравнений";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
    }
}

