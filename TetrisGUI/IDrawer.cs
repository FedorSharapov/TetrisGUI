using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGUI
{
    interface IDrawer
    {
        void InitField();
        void DrawPoint(int x, int y);
        void HidePoint(int x, int y);
        void GameOver();

        bool KeyAvailable();

        Keys GetKey();
    }
}
