namespace SimpleSnakeNoBorders.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Point
    {
        private int leftX;
        private int topY;
        private readonly Random random;

        public Point()
        {
            this.random = new Random();
        }

        public Point(int leftX, int topY)
            : this()
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }

        public int LeftX
        {
            get
            {
                return leftX;
            }
            set
            {
                if (value < -1 || value > Console.WindowWidth)
                {
                    throw new IndexOutOfRangeException();
                }

                leftX = value;
            }
        }

        public int TopY
        {
            get
            {
                return topY;
            }
            set
            {
                if (value < -1 || value > Console.WindowHeight)
                {
                    throw new IndexOutOfRangeException();
                }

                topY = value;
            }
        }

        public Point GetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = this.random.Next(2, Console.WindowWidth - 2);
            this.TopY = this.random.Next(2, Console.WindowHeight - 2);

            while (IsPointOfSnake(snakeElements))
            {
                this.LeftX = this.random.Next(2, Console.WindowWidth - 2);
                this.TopY = this.random.Next(2, Console.WindowHeight - 2);
            }

            var newPoint = new Point(this.LeftX, this.TopY);

            return newPoint;
        }

        private bool IsPointOfSnake(Queue<Point> snakeElements)
             => snakeElements.Any(x => x.TopY == this.TopY && x.LeftX == this.LeftX);

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX, this.TopY);
            Console.Write(symbol);
        }

        public void Draw(int left, int top, char symbol)
        {
            Console.SetCursorPosition(left, top);
            Console.Write(symbol);
        }
    }
}
