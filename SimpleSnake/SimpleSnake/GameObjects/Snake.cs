using SimpleSnake.GameObjects.Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleSnake.GameObjects
{
    public class Snake
    {
        private const char snakeSymbol = '\u25CF';

        private Queue<Point> snakeElements;
        private Food[] foods;
        private Wall wall;

        private int nextLeftX;
        private int nextTopY;
        private int foodIndex;
        
        public Snake(Wall wall)
        {
            this.wall = wall;
            this.foods = new Food[3];
            this.foodIndex = this.RandomFoodNumber;
            this.snakeElements = new Queue<Point>();
            this.GetFoods();
            this.CreateSnake();
            //not here
          
        }

        private void CreateSnake()
        {
            for (int leftX = 1; leftX <= 6; leftX++)
            {
                this.snakeElements.Enqueue(new Point(leftX, 2));
            }

            this.foods[this.foodIndex].SetRandomPosition(snakeElements);
        }

        public int RandomFoodNumber => new Random().Next(0, this.foods.Length);

        public bool IsMoving(Point direction)
        {
            Point currentSnakeHead = this.snakeElements.Last();

            this.GetNextPoint(direction, currentSnakeHead);

            bool isPointOfSnake = this.snakeElements
                .Any(x => x.LeftX == this.nextLeftX && x.TopY == nextTopY);

            if (isPointOfSnake)
            {
                return false;
            }

            Point snakeNewHead = new Point(this.nextLeftX, this.nextTopY);

            if (wall.IsPointOfWall(snakeNewHead))
            {
                return false;
            }

            this.snakeElements.Enqueue(snakeNewHead);
            snakeNewHead.Draw(snakeSymbol);

            if (this.foods[this.foodIndex].IsFoodPoint(snakeNewHead))
            {
                this.Eat(direction, currentSnakeHead);
            }

            Point snakeTail = this.snakeElements.Dequeue();

            snakeTail.Draw(' ');
         
            return true;
        }

        private void Eat(Point direction, Point currentSnakeHead)
        {
            int length = this.foods[this.foodIndex].FoodPoints;

            for (int i = 0; i < length; i++)
            {
                this.snakeElements.Enqueue(new Point(this.nextLeftX, this.nextTopY));
                this.GetNextPoint(direction, currentSnakeHead);
            }

            this.wall.AddPoints(this.snakeElements);
            this.wall.PlayerInfo();
            this.foodIndex = this.RandomFoodNumber;
            this.foods[foodIndex].SetRandomPosition(snakeElements);
        }

        private void GetFoods()
        {
            this.foods[0] = new FoodHash(this.wall);
            this.foods[1] = new FoodDollar(this.wall);
            this.foods[2] = new FoodAsterisk(this.wall);
        }

        private void GetNextPoint(Point direction, Point snakeHead)
        {
            this.nextLeftX = snakeHead.LeftX + direction.LeftX;
            this.nextTopY = snakeHead.TopY + direction.TopY;
        }
    }
}
