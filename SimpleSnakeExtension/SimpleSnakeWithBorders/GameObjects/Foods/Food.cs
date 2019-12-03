namespace SimpleSnakeWithBorders.GameObjects.Foods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private readonly Wall wall;
        private readonly char foodSymbol;
        private readonly Random random;

        protected Food(Wall wall, char foodSymbol, int points)
            :base(wall.LeftX, wall.TopY)
        {
            this.wall = wall;
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;

            this.random = new Random();
        }

        public int FoodPoints { get; }

        public void SetRandomPosition(Queue<Point> snakeElements)
        {
            this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
            this.TopY = this.random.Next(2, this.wall.TopY - 2);

            bool isPointOfSnake = IsPointOfSnake(snakeElements);

            while (isPointOfSnake)
            {
                this.LeftX = this.random.Next(2, this.wall.LeftX - 2);
                this.TopY = this.random.Next(2, this.wall.TopY - 2);

                isPointOfSnake = IsPointOfSnake(snakeElements);
            }

            this.Draw(foodSymbol);
        }
        public bool IsFoodPoint(Point snake)
        {
            return this.LeftX == snake.LeftX &&
                   this.TopY == snake.TopY;
        }

        private bool IsPointOfSnake(Queue<Point> snakeElements)
        {
            return snakeElements
                .Any(x => x.TopY == this.TopY && x.LeftX == this.LeftX);
        }
    }
}
