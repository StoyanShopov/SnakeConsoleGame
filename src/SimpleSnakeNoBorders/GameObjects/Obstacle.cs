namespace SimpleSnakeNoBorders.GameObjects
{
    using System.Collections.Generic;
    using System.Linq;

    public class Obstacle : Point
    {
        private const char ObstacleSymbol = '\u2020';
        private readonly List<Point> obstacles;

        public Obstacle()
        {
            this.obstacles = new List<Point>();
        }

        public bool IsObstacle(Point snakePoint)
            => this.obstacles.Any(x => x.LeftX == snakePoint.LeftX && x.TopY == snakePoint.TopY);

        public IReadOnlyCollection<Point> Obstacles
            => this.obstacles.AsReadOnly();

        public void SetRandomObstacle(Queue<Point> snakeElements, Point direction)
        {
            Point point = this.GetRandomPosition(snakeElements);
            Point snakeHead = snakeElements.Last();

            int nextLeftX = snakeHead.LeftX + direction.LeftX;
            int nextTopY = snakeHead.TopY + direction.TopY;

            bool isObstacle = point.LeftX == nextLeftX && point.TopY == nextTopY;

            while (isObstacle)
            {
                point = this.GetRandomPosition(snakeElements);

                nextLeftX = snakeHead.LeftX + direction.LeftX;
                nextTopY = snakeHead.TopY + direction.TopY;

                isObstacle = point.LeftX == nextLeftX && point.TopY == nextTopY;
            }

            this.obstacles.Add(point);

            point.Draw(ObstacleSymbol);
        }
    }
}
