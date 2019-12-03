namespace SimpleSnakeNoBorders.GameObjects.Foods
{
    public class FoodAsterisk : Food
    {
        private const char FoodSymbol = '*';
        private const int AsteriskFoodPoints = 1;

        public FoodAsterisk() 
            : base(FoodSymbol, AsteriskFoodPoints)
        {
        }
    }
}
