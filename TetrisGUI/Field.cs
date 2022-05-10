using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGUI
{
    static class Field
    {
        private static int _width = 20;
        private static int _height = 20;

        private static bool[][] _heap;

        static Field()
        {
            _heap = new bool[_height][];

            for(int i =0; i < _height; i++)
                _heap[i] = new bool[_width];
        }

        public static int Width
        {
            get
            {
                return _width;
            }
        }
        public static int Height
        {
            get
            {
                return _height;
            }
        }

        public static void AddFigure(Figure figure)
        {
            foreach(var p in figure.Points)
            {
                _heap[p.Y][p.X] = true;
            }
        }

        public static bool CheckStrike(Point p)
        {
            return _heap[p.Y][p.X];
        }

        public static void TryDeleteLines()
        {
            for (int j = 0; j < _height; j++)
            {
                int counter = 0;

                for (int i = 0; i < _width; i++)
                {
                    if (_heap[j][i])
                        counter++;
                }
                if (counter == _width)
                {
                    DeleteLine(j);
                    Redraw();
                }
            }
        }

        private static void Redraw()
        {
            for (int j = 0; j <_height; j++)
            {
                for (int i = 0; i < _width; i++)
                {
                    if (_heap[j][i])
                        DrawerProvider.Drawer.DrawPoint(i, j);
                    else
                        DrawerProvider.Drawer.HidePoint(i, j);
                }
            }
        }

        private static void DeleteLine(int line)
        {
            for(int j =line; j >= 0; j--)
            {
                for(int i = 0; i <_width;i++)
                {
                    if (j == 0)
                        _heap[j][i] = false;
                    else
                        _heap[j][i] = _heap[j-1][i];
                }
            }
        }
    }
}
