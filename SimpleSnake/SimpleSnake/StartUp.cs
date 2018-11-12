namespace SimpleSnake
{
    using SimpleSnake.Core;
    using SimpleSnake.GameObjects;
    using System;
    using System.Threading;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Wall wall = new Wall(60, 20);
            Snake snake = new Snake(wall);

            Engine engine = new Engine(snake, wall);
            engine.Run();
        }
    }
}