using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleSnake.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int HashFoodPoints = 3;

        public FoodHash(Wall wall)
            : base(wall, FoodSymbol, HashFoodPoints)
        {
        }
    }
}
