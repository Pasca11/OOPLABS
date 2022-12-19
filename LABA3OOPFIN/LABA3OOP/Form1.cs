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
    public partial class Form1 : Form
    {
        public Boat boat;
        Bitmap bitmap;
        Pen pen = new Pen(Color.Black, 5);
        public Form1()
        {
            InitializeComponent();
            this.bitmap = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Init.pen = this.pen;
            Init.bitmap = this.bitmap;
            Init.pictureBox = pictureBox1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
            Init.pictureBox.Image = Init.bitmap;
            this.boat = new Boat(0, 300);
            boat.Draw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (boat != null)
            {
                boat.Del();
                boat = null;
            } else
            {
                MessageBox.Show("Фигура не существует");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (boat != null)
            {
                int x, y;
                if (int.TryParse(textBox1.Text, out x) && int.TryParse(textBox2.Text, out y))
                {
                    boat.move(x, y);
                }
                else
                {
                    MessageBox.Show("Неверное значение для координат");
                }
            } else
            {
                MessageBox.Show("Фигура не существует");
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Show();
        }
    }
}
