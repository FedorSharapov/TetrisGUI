using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.SmallBasic.Library;

namespace TetrisGUI
{
    class SmallBasicDrawer : IDrawer
    {
        public const int SIZE_RECTANGLE = 20;
        private static bool _keyAvailable = false;

        public SmallBasicDrawer()
        {
            GraphicsWindow.KeyDown += GraphicsWindow_KeyDown;

        }
        private static void GraphicsWindow_KeyDown()
        {
            _keyAvailable = true;
        }

        public void InitField()
        {
            GraphicsWindow.Clear();
            GraphicsWindow.Width = Field.Width* SIZE_RECTANGLE;
            GraphicsWindow.Height = Field.Height * SIZE_RECTANGLE;
            GraphicsWindow.BackgroundColor = "White";
        }
        public void DrawPoint(int x, int y)
        {
            GraphicsWindow.PenColor = "DarkGreen";
            GraphicsWindow.PenWidth = 2;
            
            GraphicsWindow.DrawRectangle(x * SIZE_RECTANGLE, y * SIZE_RECTANGLE, SIZE_RECTANGLE, SIZE_RECTANGLE);
        }
        public void HidePoint(int x, int y)
        {
            GraphicsWindow.PenColor = GraphicsWindow.BackgroundColor;
            GraphicsWindow.PenWidth = 2;
            GraphicsWindow.DrawRectangle(x * SIZE_RECTANGLE, y * SIZE_RECTANGLE, SIZE_RECTANGLE, SIZE_RECTANGLE);
        }

        public void GameOver()
        {
            GraphicsWindow.BrushColor = "Red";
            GraphicsWindow.FontSize = 20;
            GraphicsWindow.FontBold = true;
            GraphicsWindow.DrawText(GraphicsWindow.Width / 2 - 4* GraphicsWindow.FontSize, GraphicsWindow.Height/ 2, "G A M E  O V E R");
        }

        public bool KeyAvailable()
        {
            return _keyAvailable;
        }

        public Keys GetKey()
        {
            _keyAvailable = false;
            var key = GraphicsWindow.LastKey;

            switch(key.ToString())
            {
                case "Left":
                    return Keys.LEFT_ARROW;
                case "Right":
                    return Keys.RIGHT_ARROW;
                case "Down":
                    return Keys.DOWN_ARROW;
                case "Up":
                    return Keys.UP_ARROW;
                case "Escape":
                    return Keys.ESC;
                case "Enter":
                    return Keys.ENTER;
            }
            return Keys.ESC;
        }
    }
}
