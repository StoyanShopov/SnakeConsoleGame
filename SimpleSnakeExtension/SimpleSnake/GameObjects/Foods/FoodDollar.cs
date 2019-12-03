namespace SimpleSnakeNoBorders.GameObjects.Foods
{
    public class FoodDollar : Food
    {
        private const char FoodSymbol = '$';
        private const int DollarFoodPoints = 2;

        public FoodDollar() 
            : base(FoodSymbol, DollarFoodPoints)
        {
        }
    }
}
