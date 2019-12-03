namespace SimpleSnakeNoBorders
{
    using Core;
    using GameObjects;
    using Utilities;

    public class StartUp
    {
        public static void Main()
        {
            ConsoleWindow.CustomizeConsole();

            Snake snake = new Snake();

            Engine engine = new Engine(snake);
            engine.Run();
        }
    }
}