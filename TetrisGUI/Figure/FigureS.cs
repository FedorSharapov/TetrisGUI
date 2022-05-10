using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGUI
{
    class FigureS:Figure
    {
        public FigureS(int x, int y)
        {
            _points[0] = new Point(x, y+1);
            _points[1] = new Point(x + 1, y + 1); 
            _points[2] = new Point(x + 1, y);
            _points[3] = new Point(x+2, y);

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
            /*   for (int i = 0; i < POINTS_LENTH; i++)
               {
                   _points[i].X = _points[0].X;
                   _points[i].Y = _points[0].Y + i;
               }*/
            _points[0].X = _points[0].X;
            _points[0].Y = _points[0].Y;

            _points[1].X = _points[0].X;
            _points[1].Y = _points[0].Y + 1;

            _points[2].X = _points[0].X + 1;
            _points[2].Y = _points[0].Y + 1;

            _points[3].X = _points[0].X + 1;
            _points[3].Y = _points[0].Y + 2;
        }

        private void RotateHorizontal()
        {
            /*for (int i = 0; i < POINTS_LENTH; i++)
            {
                _points[i].Y = _points[0].Y;
                _points[i].X = _points[0].X + i;
            }*/
            _points[0].X = _points[0].X;
            _points[0].Y = _points[0].Y;

            _points[1].X = _points[0].X+1;
            _points[1].Y = _points[0].Y;

            _points[2].X = _points[0].X + 1;
            _points[2].Y = _points[0].Y - 1;

            _points[3].X = _points[0].X + 2;
            _points[3].Y = _points[0].Y - 1;
        }
    }
}
