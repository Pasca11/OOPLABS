using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyLib;

namespace LABA3OOP
{
    public partial class Form2 : Form
    {
        public Poly poly;
        Bitmap bitmap;
        Pen pen = new Pen(Color.Black, 5);
        PointF[] points;
        int flag = 0;
        int i = 0;
        public Form2()
        {
            InitializeComponent();
            this.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Init.pen = this.pen;
            Init.bitmap = this.bitmap;
            Init.pictureBox = pictureBox1;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(textBox1.Text, out n))
            {
                points = new PointF[n];
                flag = 1;
                label6.Text = points.Length.ToString();
            } else
            {
                MessageBox.Show("неыерное значение");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                int x, y;
                if (i < points.Length)
                {
                    if (int.TryParse(textBox2.Text, out x) && int.TryParse(textBox3.Text, out y))
                    {
                        points[i].X = x;
                        points[i].Y = y;
                        i++;
                        label6.Text = (points.Length - i).ToString();
                    }
                }
            } else
            {
                MessageBox.Show("Количество точек не выбрано");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (poly != null)
            {
                poly.DeleteF(poly, true);
                poly = null; 
            }
            i = 0;
            poly = new Poly(points, points.Length);
            poly.Draw();
        }
    }
}
