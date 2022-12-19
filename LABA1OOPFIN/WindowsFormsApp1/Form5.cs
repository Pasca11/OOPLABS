using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string xs = textBox3.Text;
            string ys = textBox2.Text;
            double x, y = 0;
            if (Double.TryParse(xs, out x) && Double.TryParse(ys, out y))
            {
                if (x <= 1 && x >= -1 && y <= 1 && y >= -1)
                { 
                    MessageBox.Show("Да");
                } else
                {
                    MessageBox.Show("Нет");
                }
            } else
            {
                MessageBox.Show("Неверное значение для координат");
            }
        }
    }
}
