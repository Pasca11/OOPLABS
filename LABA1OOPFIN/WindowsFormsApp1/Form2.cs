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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ns = textBox1.Text;
            int num;
            int n = 0;
            bool isnum = int.TryParse(ns, out num);
            if (isnum)
            {
                n = num;
            }
            if (isnum && n > 0 && n <= 10)
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                int[,] matrix = new int[n, n];
                int[,] b = new int[n, n];
                int[,] c = new int[n, n];
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        matrix[i, j] = count++;
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (j < i)
                        {
                            b[i, j] = matrix[i, j];
                            c[i, j] = matrix[i, j];
                            richTextBox1.Text += b[i, j];
                            richTextBox2.Text += c[i, j];
                        }
                        else
                        {
                            b[i, j] = matrix[j, i];
                            c[i, j] = (-1) * matrix[i, j];
                            richTextBox1.Text += b[i, j];
                            richTextBox2.Text += c[i, j];
                        }
                        for (int l = 0; l < 5 - b[i, j].ToString().Length; l++)
                        {
                            richTextBox1.Text += " ";
                        }
                        for (int l = 0; l < 5 - c[i, j].ToString().Length; l++)
                        {
                            richTextBox2.Text += " ";
                        }
                    }
                    richTextBox1.Text += "\n";
                    richTextBox2.Text += "\n";
                }

            } else
            {
                MessageBox.Show("Неверное значение для размеров матрицы");
            }
        }
    }
}
