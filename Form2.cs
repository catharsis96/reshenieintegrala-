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
    public partial class Form2 : Form
    {
        public float a;// Параметры передаваемые из Form1
        public float b;
        public float step;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;
            //g.FillRectangle(Brushes.White, 0, 0, w, h);
            g.Clear(Color.White);
            g.TranslateTransform(w / 2, h / 2);

            const int s = 20;// Масштаб в пикселах

            Grid(g, -w / 2, -h / 2, w / s, h / s, s, Pens.LightBlue);

            g.DrawLine(Pens.Red, 0, -h / 2, 0, h / 2); // Y 
            g.DrawLine(Pens.Red, -w / 2, 0, w / 2, 0); // X

            Plot(g, s, 0, 0);
        }
        void Grid(Graphics g, int x0, int y0, int nx, int ny, int s, Pen p)
        {
            for (int x = -nx / 2; x <= nx; x++)
                g.DrawLine(p, x * s, -ny / 2 * s,
                              x * s, ny / 2 * s);

            for (int y = -ny / 2; y <= ny; y++)
                g.DrawLine(p, -nx / 2 * s, y * s,
                               nx / 2 * s, y * s);
        }
        PointF[] tochk;
        void Plot(Graphics g, float s, float ox, float oy)
        {
            for (float x = a; x < b; x += step)
            {
                tochk = new PointF[4];
                tochk[0] = new PointF(x * s, oy);
                tochk[1] = new PointF(x * s, -Form1.f(x) * s);
                tochk[2] = new PointF((x + step) * s, -Form1.f(x + step) * s);
                tochk[3] = new PointF((x + step) * s, oy);
                g.DrawPolygon(Pens.Green, tochk);
            }
        }

        private void Form2_ClientSizeChanged(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
