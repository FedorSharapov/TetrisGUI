using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGUI
{
    class Square : Figure
    {
        public Square(int x, int y)
        {
            _points[0] = new Point(x, y);
            _points[1] = new Point(x+1, y);
            _points[2] = new Point(x, y+1);
            _points[3] = new Point(x+1, y+1);

            Draw();
        }

        protected sealed override void Rotate()
        {

        }
    }
}
