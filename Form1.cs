using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reshenie_Integrala__Metod_Trapecii_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static float a, b, x, n, c, step, y, sum, sum2, sum3;
        private void button1_Click(object sender, EventArgs e)
        {
            a = Convert.ToSingle(textBox1.Text);
            b = Convert.ToSingle(textBox2.Text);
            step = Convert.ToSingle(textBox3.Text);
            c = Convert.ToSingle(textBox4.Text);
            n = Convert.ToSingle(textBox5.Text);

            sum = 0;
            sum2 = 0;
            sum3 = 0;

            for (x = a; x <= b; x += step)
            {
                if (x == a || x == b)
                {
                    y = Math.Abs(f(x));
                    sum += y;
                }
                else
                {
                    y = Math.Abs(f(x));
                    sum2 += y;
                }
            }
            float pogresh = (float)Math.Pow((b - a), 3) /
                      (12 * (float)Math.Pow((b - a / step), 2));//учитывая погрешность
            sum3 = (sum / 2 + sum2) * step + pogresh;

            textBox6.Text = "Ответ: " + sum3.ToString("f3");
        }
        public static float f(float x)
        {
          
            return (float)Math.Pow(Math.Cos(3 * Math.Sin(x)), 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.a = Convert.ToSingle(textBox1.Text);
            form2.b = Convert.ToSingle(textBox2.Text);
            form2.step = Convert.ToSingle(textBox3.Text);
            form2.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
