using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGUI
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point() { }

        public Point(Point point)
        {
            X = point.X;
            Y = point.Y;
        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.LEFT:
                    X -= 1;
                    break;
                case Direction.RIGHT:
                    X += 1;
                    break;
                case Direction.DOWN:
                    Y += 1;
                    break;
                case Direction.UP:
                    Y -= 1;
                    break;
            }
        }
        public void Draw()
        {
            DrawerProvider.Drawer.DrawPoint(X, Y);
        }
        public void Hide()
        {
            DrawerProvider.Drawer.HidePoint(X, Y);
        }
    }
}
