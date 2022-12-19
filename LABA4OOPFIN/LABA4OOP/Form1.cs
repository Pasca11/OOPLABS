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

namespace LABA4OOP
{
    public partial class Form1 : Form
    {
        private Stack<Operator> operators = new Stack<Operator>();
        private Stack<Operand> operands = new Stack<Operand>();

        public Form1()
        {
            InitializeComponent();
            Init.pictureBox = pictureBox1;
            Init.bitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) // Срабатывает, если нажат Enter
            {
                operators.Clear(); // очизаем стеки
                operands.Clear();
                string expression = textBox1.Text.Replace(" ", ""); // удаляем пробелы
                for (int i = 0; i < expression.Length; i++)
                {
                    if (Functions.IsOperation(expression[i])) // Если добавление параметров в стек
                    {
                        if (!Char.IsDigit(expression[i]))
                        {
                            operands.Push(new Operand(expression[i]));
                            while (i < expression.Length - 1 && Functions.IsOperation(expression[i + 1]))
                            {
                                string temp_str = operands.Pop().value.ToString() + expression[i + 1].ToString();
                                operands.Push(new Operand(temp_str));
                                i++;
                            }
                        }
                        else if (Char.IsDigit(expression[i]))
                        {
                            operands.Push(new Operand(expression[i].ToString()));
                            while (i < expression.Length - 1 && Char.IsDigit(expression[i + 1])
                                && Functions.IsOperation(expression[i + 1]))
                            {
                                int temp_num = Convert.ToInt32(operands.Pop().value.ToString()) * 10 +
                                    (int)Char.GetNumericValue(expression[i + 1]);
                                operands.Push(new Operand(temp_num.ToString()));
                                i++;
                            }
                        }
                    }
                    else if (expression[i] == 'C') // Добавление команды отрисовки в стек
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(expression[i]));
                        }
                    }
                    else if (expression[i] == 'K') // Добавление команды перекраски в стек
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(expression[i]));
                        }
                    }
                    else if (expression[i] == 'M') // Добавление команды перемещения в стек
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(expression[i]));
                        }
                    }
                    else if (expression[i] == 'D') // Добавление команды удаления в стек 
                    {
                        if (operators.Count == 0)
                        {
                            operators.Push(OperatorContainer.FindOperator(expression[i]));
                        }
                    }
                    else if (expression[i] == '(')
                    {
                        operators.Push(OperatorContainer.FindOperator(expression[i]));
                    }
                    else if (expression[i] == ')') // Если встречена ), то 
                    {
                        do // Пока наверху стека не окажется ( достаем из стека операторы
                        {
                            if (operators.Peek().symbolOperator == '(')
                            {
                                operators.Pop();
                                break;
                            }
                            if (operators.Count == 0)
                            {
                                break;
                            }
                        }
                        while (operators.Peek().symbolOperator != '(');
                    }
                }
                try // ВЫполнение команд и отлов ошибок
                {
                    SelectingPerformingOperation(operators.Peek());
                }
                catch // Срабатывет при ошибке
                {
                    MessageBox.Show("Введенной команды не существует.");
                    comboBox1.Items.Add("Введенной команды не существует.");
                }
            }
        }

        private void SelectingPerformingOperation(Operator op) // Выполнение команд
        {
            if (op.symbolOperator == 'C') // Рисование окружности
            {
                if (operands.Count == 4)
                {
                    int w = Convert.ToInt32(operands.Pop().value.ToString()); // Достаем параметры из стека
                    int y = Convert.ToInt32(operands.Pop().value.ToString());
                    int x = Convert.ToInt32(operands.Pop().value.ToString());
                    string name = operands.Pop().value.ToString();
                    if (Functions.IsFits(x, y, w))
                    {
                        Circle figure = new Circle(name, x, y, w); // Создание фигуры
                        ShapeContainer.figureList.Add(figure); // Добавление фигуры в контейгер фигур
                        figure.
                        figure.Draw(Init.pen); // ОТрисовка фигуры
                        comboBox1.Items.Add($"Окружность {figure.Name} отрисована"); // Добавление записи в логгер
                    } else // Если фигура выходит за границы
                    {
                        MessageBox.Show("Окружность выходит за границы");
                        comboBox1.Items.Add("Ошибка. Окружность выходит за границы");
                    }
                }
                else // Если введено неверное число параметров
                {
                    MessageBox.Show("Команда С принимает 4 параметра");
                    comboBox1.Items.Add("Ошибка. Команда С принимает 4 параметра");
                }
            }
            else if (op.symbolOperator == 'M') // Перемещение фигуры
            {
                if (operands.Count == 3)
                {
                    Circle figure = null;
                    int y = Convert.ToInt32(operands.Pop().value.ToString());  // Достаем параметры из стека
                    int x = Convert.ToInt32(operands.Pop().value.ToString());
                    string name = operands.Pop().value.ToString();
                    foreach (Figure f in ShapeContainer.figureList)
                    {
                        if (f.Name == name) // Поис4к фигуры в контейнере
                        {
                            figure = (Circle)f;
                        }
                    }
                    if (figure != null) // Если фигура найдена, то
                    {
                        if (Functions.IsFits(x, y, figure.w))
                        {
                            figure.MoveTo(x, y); // Перемещение фигуры
                            comboBox1.Items.Add($"Фигура {figure.Name} перемещена");
                        }
                        else
                        {
                            MessageBox.Show("Нельзя переместить фигуру за границы");
                            comboBox1.Items.Add("Ошибка. Нельзя переместить фигуру за границы");
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Фигуры {name} не существует");
                        comboBox1.Items.Add($"Ошибка. Фигуры {name} не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Команда M принимает 3 параметра");
                    comboBox1.Items.Add("Ошибка. Команда M принимает 3 параметра");
                }
            }
            else if (op.symbolOperator == 'D')  // Удаление фигуры
            {
                if (operands.Count == 1)
                {
                    Circle figure = null;
                    string name = operands.Pop().value.ToString();
                    foreach (Figure f in ShapeContainer.figureList)
                    {
                        if (f.Name == name)
                        {
                            figure = (Circle)f;
                        }
                    }
                    if (figure != null)
                    {
                        figure.DeleteF(figure, true);
                        ShapeContainer.figureList.Remove(figure);
                        comboBox1.Items.Add($"Фигура {figure.Name} удалена");
                    }
                    else
                    {
                        MessageBox.Show($"Фигуры {name} не существует");
                        comboBox1.Items.Add($"Ошибка. Фигуры {name} не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Команда D принимает 1 параметр");
                    comboBox1.Items.Add("Ошибка. Команда D принимает 1 параметр");
                }
            }
            else if (op.symbolOperator == 'K') // Перекраска фигуры
            {
                if (operands.Count == 2)
                {
                    Circle figure = null;
                    string toClolor = operands.Pop().value.ToString();
                    string name = operands.Pop().value.ToString();
                    foreach (Figure f in ShapeContainer.figureList)
                    {
                        if (f.Name == name)
                        {
                            figure = (Circle)f;
                        }
                    }
                    if (figure != null)
                    {
                        Pen pp = Functions.StringToPen(toClolor); // Получаем цвет из слова
                        figure.ch_Color(pp); // Перекраска фигуры
                        comboBox1.Items.Add($"Фигура {figure.Name} перекрвшена");
                    }
                    else
                    {
                        MessageBox.Show($"Фигуры {name} не существует");
                        comboBox1.Items.Add($"Ошибка. Фигуры {name} не существует");
                    }
                }
                else
                {
                    MessageBox.Show("Команда K принимает 2 параметра");
                    comboBox1.Items.Add("Ошибка. Команда K принимает 2 параметра");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
