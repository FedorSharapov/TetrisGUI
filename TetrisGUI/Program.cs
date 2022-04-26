using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SmallBasic.Library;
using System.Threading;
using System.Timers;

namespace TetrisGUI
{
    class Program
    {
        const int TIMER_INTERVAL = 500;
        private static System.Timers.Timer timer;
        static private Object _lockObject = new object();

        static Figure currentFigure;
        static FigureGenerator figureGenerator;

        static void Main(string[] args)
        {
            DrawerProvider.Drawer.InitField();
            Thread.Sleep(100);
            
            figureGenerator = new FigureGenerator(Field.Width / 2, 0);
            currentFigure = figureGenerator.GetNewFigure();
            SetTimer();

            while (true)
            {
                if (DrawerProvider.Drawer.KeyAvailable())
                {
                    var key = DrawerProvider.Drawer.GetKey();
                    Monitor.Enter(_lockObject);
                    var result = HandleKey(key);
                    ProcessResult(result);
                    Monitor.Exit(_lockObject);
                }
            }
        }



        private static bool ProcessResult(Result result)
        {
            if (result == Result.HEAP_STRIKE || result == Result.DOWN_BORDER_STRIKE)
            {
                Field.AddFigure(currentFigure);
                Field.TryDeleteLines();

                if (currentFigure.IsOnTop)
                {
                    DrawerProvider.Drawer.GameOver();
                    timer.Stop();
                    return true;
                }
                else
                {
                    currentFigure = figureGenerator.GetNewFigure();
                    return true;
                }
            }
            else
                return false;
        }

        private static Result HandleKey(Keys key)
        {
            switch (key)
            {
                case Keys.LEFT_ARROW:
                    return currentFigure.TryMove(Direction.LEFT);
                case Keys.RIGHT_ARROW:
                    return currentFigure.TryMove(Direction.RIGHT);
                case Keys.DOWN_ARROW:
                    return currentFigure.TryMove(Direction.DOWN);
                case Keys.UP_ARROW:
                    return currentFigure.TryRotate();
            }

            return Result.SUCCESS;
        }

        private static void SetTimer()
        {
            timer = new System.Timers.Timer(TIMER_INTERVAL);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
        }

        private static void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            Monitor.Enter(_lockObject);
            var result = currentFigure.TryMove(Direction.DOWN);
            ProcessResult(result);
            Monitor.Exit(_lockObject);
        }
    }
}
