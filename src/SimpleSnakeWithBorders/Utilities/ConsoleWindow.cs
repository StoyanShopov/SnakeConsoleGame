namespace SimpleSnakeWithBorders.Utilities
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    public static class ConsoleWindow
    {
        [DllImport("kernel32.dll", ExactSpelling = true)]
        private static extern IntPtr GetConsoleWindow();
        private static readonly IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private const int Maximize = 3;

        public static void CustomizeConsole()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, Maximize);
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Clear();
            Console.CursorVisible = false;
        }
    }
}
