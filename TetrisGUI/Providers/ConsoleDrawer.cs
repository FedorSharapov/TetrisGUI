using System;
using System.Collections.Generic;
using System.Text;

namespace TetrisGUI
{
    class ConsoleDrawer : IDrawer
    {
        const char DEFAULT_SYMBOL = '*';

        public void InitField()
        {
            Console.Clear();
            Console.SetWindowSize(Field.Width, Field.Height);
            Console.SetBufferSize(Field.Width, Field.Height); // чтобы исключить появления полосы прокрутки
            Console.CursorVisible = false;

            /*
            for (int i = 1; i < _height; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write('║');
                Console.SetCursorPosition(_width - 1, i);
                Console.Write('║');
            }

            Console.SetCursorPosition(0, _height - 1);
            Console.Write('╚');

            for (int i = 1; i < _width; i++)
            {
                Console.SetCursorPosition(i, _height - 1);
                Console.Write('═');
            }

            Console.SetCursorPosition(_width - 1, _height - 1);
            Console.Write('╝');

            Console.SetCursorPosition(0, 0);*/
        }
        public void DrawPoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(DEFAULT_SYMBOL);
            Console.SetCursorPosition(0, 0);
        }
        public void HidePoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(' ');
            Console.SetCursorPosition(0, 0);
        }

        public void GameOver()
        {
            Console.SetCursorPosition(Field.Width / 2 - 8, Field.Height / 2);
            Console.WriteLine("G A M E  O V E R");
        }

        public bool KeyAvailable()
        {
            return Console.KeyAvailable;
        }

        public Keys GetKey()
        {
            var key = Console.ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.LeftArrow:
                    return Keys.LEFT_ARROW;
                case ConsoleKey.RightArrow:
                    return Keys.RIGHT_ARROW;
                case ConsoleKey.DownArrow:
                    return Keys.DOWN_ARROW;
                case ConsoleKey.UpArrow:
                    return Keys.UP_ARROW;
                case ConsoleKey.Escape:
                    return Keys.ESC;
                case ConsoleKey.Enter:
                    return Keys.ENTER;
            }
            return Keys.ESC;
        }
    }
}
