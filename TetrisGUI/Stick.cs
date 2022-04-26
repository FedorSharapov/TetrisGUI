using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGUI
{
    class Stick : Figure
    {
        public Stick(int x, int y)
        {
            _points[0] = new Point(x, y);
            _points[1] = new Point(x, y + 1);
            _points[2] = new Point(x, y + 2);
            _points[3] = new Point(x, y + 3);

            Draw();
        }

        protected sealed override void Rotate()
        {
            if (_points[0].X == _points[1].X)
                RotateHorizontal();
            else
                RotateVertical();
        }

        private void RotateVertical()
        {
            for (int i = 0; i < POINTS_LENTH; i++)
            {
                _points[i].X = _points[0].X;
                _points[i].Y = _points[0].Y + i;
            }
        }

        private void RotateHorizontal()
        {
            for (int i = 0; i < POINTS_LENTH; i++)
            {
                _points[i].Y = _points[0].Y;
                _points[i].X = _points[0].X + i;
            }
        }
    }
}
