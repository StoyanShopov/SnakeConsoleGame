using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public abstract class Food : Point
    {
        private char foodSymbol;
        private Random random;

        public Food(char foodSymbol, int points)
        {
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
            this.random = new Random();
        }

        public int FoodPoints { get; private set; }

        public bool IsFoodPoint(Point snake)
        {
            return this.LeftX == snake.LeftX && this.TopY == snake.TopY;
        }

        public void SetRandomFood(Queue<Point> snakeElements, IReadOnlyCollection<Point> obstacles)
        {
            Point food = this.GetRandomPosition(snakeElements);

            bool isFood = obstacles.Any(x => x.LeftX == food.LeftX && x.TopY == food.TopY);

            while (isFood)
            {
                food = this.GetRandomPosition(snakeElements);

                isFood = obstacles.Any(x => x.LeftX == food.LeftX && x.TopY == food.TopY);
            }

            food.Draw(foodSymbol);
        }
    }
}
