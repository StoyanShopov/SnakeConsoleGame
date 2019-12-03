namespace SimpleSnakeWithBorders.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char FoodSymbol = '*';
        private const int AsteriskFoodPoints = 1;

        public FoodAsterisk(Wall wall) 
            : base(wall, FoodSymbol, AsteriskFoodPoints)
        {
        }
    }
}
