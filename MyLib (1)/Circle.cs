using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace MyLib
{
    public class Circle : Ellips
    {
        public Pen newPen = Init.pen;

        public Circle(string name, int x, int y, int w) : base(name, x, y, w, w)
        {

        }

        public override void ch_w(int w)
        {
            if (this.x + w >= 0 && this.x + w <= Init.pictureBox.Width && this.y + w >= 0 && this.y + w <= Init.pictureBox.Height)
            {
                this.w = w;
                this.h = w;
                this.DeleteF(this, false);
                this.Draw();
            }
        }

        public void ch_Color(Pen pen)
        {
            this.DeleteF(this, false);
            this.newPen = pen;
            this.Draw(pen);
        }

        public override void MoveTo(int x, int y)
        {
            if (x >= 0 && y >= 0 && x + this.w >= 0 && y + this.h >= 0 && x + this.w <= Init.pictureBox.Width && y + this.h <= Init.pictureBox.Height)
            {
                this.x = x;
                this.y = y;
                this.DeleteF(this, false);
                this.Draw(this.newPen);
            }
        }
    }
}
