using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LABA4OOP
{
    /// <summary>
    /// Класс для хранения параметров
    /// </summary>
    public class Operand
    {
        public object value;
        public Operand(object NewValue)
        {
            this.value = NewValue;
        }
    }
}
