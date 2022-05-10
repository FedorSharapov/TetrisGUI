using System;

namespace TetrisGUI
{
    static class DrawerProvider
    {
        private static IDrawer _drawer = new SmallBasicDrawer();
        //private static IDrawer _drawer = new ConsoleDrawer();

        public static IDrawer Drawer
        {
            get { return _drawer; }
        }
    }
}