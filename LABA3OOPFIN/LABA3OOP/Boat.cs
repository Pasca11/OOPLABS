using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using MyLib;

namespace LABA3OOP
{
    public class Boat
    {
        Poly ship;
        Triangle right;
        Triangle left;
        Rectagle flag;
        PointF[] ships;
        PointF[] rightflag;
        PointF[] leftflag;

        public Boat(int x, int y)
        {
            if (ship != null)
            {
                this.Del();
            }
            ships = new PointF[4];
            ships[0].X = x; ships[0].Y = y;
            ships[1].X = x + 300; ships[1].Y = y;
            ships[2].X = x + 250; ships[2].Y = y + 100;
            ships[3].X = x + 50;  ships[3].Y = y + 100;
            ship = new Poly(ships, 4);
            rightflag = new PointF[3];
            rightflag[0].X = x + 150; rightflag[0].Y = y;
            rightflag[1].X = x + 250; rightflag[1].Y = y;
            rightflag[2].X = x + 150; rightflag[2].Y = y - 200;
            right = new Triangle(rightflag);
            leftflag = new PointF[3];
            leftflag[0].X = x + 75; leftflag[0].Y = y;
            leftflag[1].X = x + 150; leftflag[1].Y = y;
            leftflag[2].X = x + 150; leftflag[2].Y = y - 150;
            left = new Triangle(leftflag);
            flag = new Rectagle(x + 75, y - 200, 75, 50);
        }

        public void Draw()
        {
            this.ship.Draw();
            this.right.Draw();
            this.left.Draw();
            this.flag.Draw();
        }

        public void Del()
        {
            Graphics g = Graphics.FromImage(Init.bitmap);
            g.Clear(Color.White);
            Init.pictureBox.Image = Init.bitmap;
        }

        public void move(int x, int y)
        {
            if (x >= 0 && x + 300 <= Init.pictureBox.Width && 100 + y <= Init.pictureBox.Height&& y - 200 >= 0)
            {
                this.Del();
                ships = new PointF[4];
                ships[0].X = x; ships[0].Y = y;
                ships[1].X = x + 300; ships[1].Y = y;
                ships[2].X = x + 250; ships[2].Y = y + 100;
                ships[3].X = x + 50; ships[3].Y = y + 100;
                ship = new Poly(ships, 4);
                rightflag = new PointF[3];
                rightflag[0].X = x + 150; rightflag[0].Y = y;
                rightflag[1].X = x + 250; rightflag[1].Y = y;
                rightflag[2].X = x + 150; rightflag[2].Y = y - 200;
                right = new Triangle(rightflag);
                leftflag = new PointF[3];
                leftflag[0].X = x + 75; leftflag[0].Y = y;
                leftflag[1].X = x + 150; leftflag[1].Y = y;
                leftflag[2].X = x + 150; leftflag[2].Y = y - 150;
                left = new Triangle(leftflag);
                flag = new Rectagle(x + 75, y - 200, 75, 50);
                this.Draw();
            }
            else
            {
                MessageBox.Show("NO");
            }
        }
    }
}
