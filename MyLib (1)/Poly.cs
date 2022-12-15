using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace MyLib
{
    public class Poly : Figure
    {
        public PointF[] points;
        public int versh;
        public Poly(PointF[] pnts, int vershins)
        {
            this.points = pnts;
            this.versh = vershins;
        }

        public override void Draw()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawPolygon(Init.pen, points);
            Init.pictureBox.Image = Init.bitmap;
        }

        public override void MoveTo(int x, int y)
        {
            for (int i = 0; i < this.versh; i++)
            {
                this.points[i].X += x;
                this.points[i].Y += y;
                this.DeleteF(this, false);
                this.Draw();
            }
        }

        public override void MoveTo(int x, int y, Pen pen)
        {
            if (x >= 0 && y >= 0 && x + this.w >= 0 && y + this.h >= 0 && x + this.w <= Init.pictureBox.Width && y + this.h <= Init.pictureBox.Height)
            {
                this.x = x;
                this.y = y;
                this.DeleteF(this, false);
                this.Draw(pen);
            }
        }

        public override void Draw(Pen pen)
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.DrawEllipse(pen, this.x, this.y, this.w, this.h);
            Init.pictureBox.Image = Init.bitmap;
        }
    }
}
