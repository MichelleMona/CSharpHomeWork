using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _20200403
{
    public partial class Form1 : Form
    {
        int depth;
        double length;
        int color;
        double rightTh;
        double leftTh;
        double rightPer;
        double leftPer;

        private Graphics graphics;

        double th1 = 0 * Math.PI / 180;
        double th2 = 0 * Math.PI / 180;
        double per1 = 0;
        double per2 = 0;
        public Form1()
        {
            InitializeComponent();
        }

        int setColor()
        {
            if (radioButton2.Checked == true) return 2;
            else if (radioButton1.Checked == true) return 1;
            else if (radioButton3.Checked == true) return 3;
            else return 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();

            try
            {
                color = setColor();
                

                depth = Convert.ToInt32(textBox1.Text);
                length = Convert.ToDouble(textBox2.Text);
                rightPer = trackBar1.Value;
                per1 = rightPer/100;
                leftPer = trackBar2.Value ;
                per2 = leftPer/100;
                rightTh = trackBar3.Value ;
                th1 =rightTh * Math.PI / 180;
                leftTh = trackBar4.Value ;
                th2 = leftTh * Math.PI / 180;
                if (depth < 0 || length < 0) return;
            }
            catch
            {
                label1.Text = "参数错误";
            }
            label1.Text = "图的递归深度，主干长度，右分支长度比，左分支长度比，右分支角度，左分支角度为:"+" " + depth + " " + length + " " + rightPer + "% " + leftPer + "% " + rightTh + "° " + leftTh + "° " ;
            drawCayleyTree(depth, 200, 400, length, -Math.PI / 2);
            
        }
        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);
        }
        void drawLine(double x0,double y0,double x1,double y1)
        {
            switch (color)
            {
                case 1: graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1); break;
                case 2: graphics.DrawLine(Pens.Yellow, (int)x0, (int)y0, (int)x1, (int)y1); break;
                case 3: graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1); break;
                default: graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1); break;
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            color = setColor();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            color = setColor();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            color = setColor();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            graphics.Clear(Color.White);
        }
    }
}
