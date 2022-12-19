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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            string ns = textBox1.Text;
            string ms = textBox2.Text;
            int n, m;
            if (int.TryParse(ns, out n) && int.TryParse(ms, out m) && n > 0 && m > 0 && n <= 10 && m <= 10)
            {
                richTextBox1.Text = "";
                richTextBox2.Text = "";
                int[,] matrix = new int[n, m];
                int[,] tmatrix = new int[m, n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        matrix[i, j] = rnd.Next(-10, 10);
                        richTextBox1.Text += matrix[i, j];
                        for (int k = 0; k < 4 - matrix[i, j].ToString().Length; k++)
                        {
                            richTextBox1.Text += " ";
                        }
                    }
                    richTextBox1.Text += "\n";
                }
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        richTextBox2.Text += matrix[j, i];
                        for (int k = 0; k < 4 - matrix[j, i].ToString().Length; k++)
                        {
                            richTextBox2.Text += " ";
                        }
                    }
                    richTextBox2.Text += "\n";
                }
            } else
            {
                MessageBox.Show("Неверное значение(я) для размеров матрицы");
            }
        }
    }
}
