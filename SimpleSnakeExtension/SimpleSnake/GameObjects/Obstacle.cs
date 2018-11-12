using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Obstacle : Point
    {
        private const char obstacleSymbol = '\u2020';
        private List<Point> obstacles;

        public Obstacle()
        {
            this.obstacles = new List<Point>();
        }

        public bool IsObstacle(Point snakePoint)
        {
            return this.obstacles.Any(x => x.LeftX == snakePoint.LeftX && x.TopY == snakePoint.TopY);
        }

        public IReadOnlyCollection<Point> Obstacles
        {
            get { return this.obstacles.AsReadOnly(); }
        }

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
            point.Draw(obstacleSymbol);
        }
    }
}
