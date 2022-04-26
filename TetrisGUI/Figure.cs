using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGUI
{
    abstract class Figure
    {
        protected const int POINTS_LENTH = 4;
        protected Point[] _points = new Point[POINTS_LENTH];

        public Point[] Points
        {
            get { return _points; }
        } 

        public void Draw()
        {
            foreach (Point p in _points)
                p.Draw();
        }
        public void Hide()
        {
            foreach (Point p in _points)
                p.Hide();
        }
        internal bool IsOnTop
        {
            get { return Points[0].Y == 0; }
        }

        internal Result TryMove(Direction direction)
        {
            Hide();
            Move(direction);

            var result = VerifyPosition();
            if (result != Result.SUCCESS)
                Move(Reverse(direction));

            Draw();
            return result;
        }

        private Direction Reverse(Direction direction)
        {
            switch(direction)
            {
                case Direction.LEFT:
                    return Direction.RIGHT;
                case Direction.RIGHT:
                    return Direction.LEFT;
                case Direction.DOWN:
                    return Direction.UP;
                case Direction.UP:
                    return Direction.DOWN;
            }

            return direction;
        }

        private void Move(Direction direction)
        {
            foreach (var p in Points)
                p.Move(direction);
        }

        private Result VerifyPosition()
        {
            foreach (var p in Points)
            {
                if (p.Y >= Field.Height)
                    return Result.DOWN_BORDER_STRIKE;

                if (p.X >= Field.Width || p.X < 0 || p.Y < 0)
                    return Result.BORDER_STRIKE;

                if (Field.CheckStrike(p))
                    return Result.HEAP_STRIKE;
            }

            return Result.SUCCESS;
        }

        internal Result TryRotate()
        {
            Hide();
            Rotate();

            var result = VerifyPosition();
            if (result != Result.SUCCESS)
                Rotate();

            Draw();
            return result;
        }

        protected abstract void Rotate();
    }
}
