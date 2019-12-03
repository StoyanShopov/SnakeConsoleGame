namespace SimpleSnakeNoBorders.GameObjects.Foods
{
    public class FoodHash : Food
    {
        private const char FoodSymbol = '#';
        private const int HashFoodPoints = 3;

        public FoodHash()
            : base(FoodSymbol, HashFoodPoints)
        {
        }
    }
}
