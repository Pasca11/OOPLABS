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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] s = textBox1.Text.Split(' ');
            int[] matrix = new int[s.Length];
            int k = 0;
            bool flag = true;
            foreach(string i in s)
            {
                int nums;
                if (int.TryParse(i, out nums)) {
                    matrix[k++] = nums;
                } else
                {
                    MessageBox.Show("Неверное значение в строке ввода");
                    flag = false;
                    break;
                }
            }
            if (flag)
            {
                textBox2.Text = "";
                int min = int.MaxValue;
                foreach (int i in matrix)
                {
                    if (i < min)
                    {
                        min = i;
                    }
                }
                for (int i = 0; i < matrix.Length; i++)
                {
                    if (matrix[i] == min) {
                        matrix[i] *= 2;
                        foreach (int j in matrix)
                        {
                            textBox2.Text += j + " ";
                        }
                        break;
                    }
                }
            }
        }
    }
}
