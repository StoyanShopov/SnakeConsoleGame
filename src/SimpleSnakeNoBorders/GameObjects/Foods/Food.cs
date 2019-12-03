namespace SimpleSnakeNoBorders.GameObjects.Foods
{
    using System.Collections.Generic;
    using System.Linq;

    public abstract class Food : Point
    {
        private readonly char foodSymbol;

        protected Food(char foodSymbol, int points)
        {
            this.foodSymbol = foodSymbol;
            this.FoodPoints = points;
        }

        public int FoodPoints { get; }

        public bool IsFoodPoint(Point snake)
            => this.LeftX == snake.LeftX && this.TopY == snake.TopY;
        
        public void SetRandomFood(Queue<Point> snakeElements, IReadOnlyCollection<Point> obstacles)
        {
            Point food = this.GetRandomPosition(snakeElements);

            while (IsFood(food, obstacles))
            {
                food = this.GetRandomPosition(snakeElements);
            }

            food.Draw(this.foodSymbol);
        }

        private bool IsFood(Point food, IReadOnlyCollection<Point> obstacles)
            => obstacles.Any(x => x.LeftX == food.LeftX && x.TopY == food.TopY);
    }
}
