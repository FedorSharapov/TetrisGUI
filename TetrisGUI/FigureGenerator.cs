﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGUI
{
    class FigureGenerator
    {
        private int _x;
        private int _y;

        public FigureGenerator(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public Figure GetNewFigure()
        {
            Random rand = new Random();
            int value = rand.Next(0, 3);

            if ((Figures)value == Figures.Square)
                return new Square(_x, _y);
            else if ((Figures)value == Figures.Stick)
                return new Stick(_x, _y);
            else
                return new FigureS(_x, _y);
        }
    }
}
