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
    public partial class Form4 : Form
    {
        DateTime d;
        Date dd;
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            render();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int plus;
            if (int.TryParse(textBox6.Text, out plus))
            {
                if (plus > 0)
                {
                    dd.plus_date(plus);
                    upd();
                } else
                {
                    MessageBox.Show("Значение должно быть больше нуля");
                }
            } else
            {
                MessageBox.Show("Неверное значение");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int minus;
                if (int.TryParse(textBox7.Text, out minus))
                {
                    if (minus > 0)
                    {
                        dd.minus_date(minus);
                        upd();
                    }
                    else
                    {
                        MessageBox.Show("Значение должно быть больше нуля");
                    }
                }
                else
                {
                    MessageBox.Show("Неверное значение");
                }
            } catch (System.ArgumentOutOfRangeException error)
            {
                render();
            }
        }

        void render()
        {
            d = new DateTime(1, 1, 1);
            dd = new Date();
            textBox1.Text = dd.get_day().ToString() + "." + dd.get_month().ToString() + "." + dd.get_year().ToString();
            if (dd.is_vis())
            {
                textBox2.Text = "Високосный";
            }
            else
            {
                textBox2.Text = "Не високосный";
            }
        }
        void upd()
        {
            textBox1.Text = dd.get_day().ToString() + "." + dd.get_month().ToString() + "." + dd.get_year().ToString();
            d = new DateTime((int)dd.get_year(), (int)dd.get_month(), (int)dd.get_day());
            if (dd.get_year() % 4 == 0)
            {
                textBox2.Text = "Високосный";
            }
            else
            {
                textBox2.Text = "Не високосный";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            uint dday, dmonth, dyear;
            if (textBox3.Text.Length != 0)
            {
                if (uint.TryParse(textBox3.Text, out dday) && dd.set_day(dday))
                {
                    textBox3.Text = "";
                    upd();
                }
                else
                {
                    MessageBox.Show("Неверное значение в поле дня");
                    textBox3.Text = "";
                }
            }
            if (textBox4.Text.Length != 0)
            {
                if (uint.TryParse(textBox4.Text, out dmonth) && dd.set_month(dmonth))
                {
                    textBox4.Text = "";
                    upd();
                }
                else
                {
                    MessageBox.Show("Неверное значение в поле месяца");
                    textBox4.Text = "";
                }
            }
            if (textBox5.Text.Length != 0)
            {
                if (uint.TryParse(textBox5.Text, out dyear) && dd.set_year(dyear))
                {
                    textBox5.Text = "";
                    upd();
                }
                else
                {
                    MessageBox.Show("Неверное значение в поле месяца");
                    textBox5.Text = "";
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox3.Text = dd.get_day().ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox4.Text = dd.get_month().ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = dd.get_year().ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime d2;
            Date dd2 = new Date();
            uint dday, dmonth, dyear;
            if (uint.TryParse(textBox10.Text, out dday) && uint.TryParse(textBox9.Text, out dmonth) && uint.TryParse(textBox8.Text, out dyear))
            {
                if (dd2.set_day(dday) && dd2.set_month(dmonth) && dd2.set_year(dyear))
                {
                    d2 = new DateTime((int)dyear, (int)dmonth, (int)dday);
                    TimeSpan d3 = d - d2;
                    if (d > d2)
                    {
                        textBox11.Text = "До";
                    } else if (d == d2)
                    {
                        textBox11.Text = "Равно";
                    } else
                    {
                        textBox11.Text = "После";
                    }
                    textBox12.Text = Math.Abs(d3.TotalDays).ToString();
                } else
                {
                    MessageBox.Show("Неыерное значения(я)");
                }
            } else
            {
                MessageBox.Show("Неверное значение(я)");
            }
        }
    }
}
