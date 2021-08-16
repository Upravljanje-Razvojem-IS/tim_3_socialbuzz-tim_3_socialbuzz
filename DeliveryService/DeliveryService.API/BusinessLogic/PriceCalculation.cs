namespace DeliveryService.API.BusinessLogic
{
    public static class PriceCalculation
    {
        public static double Calculate(int pieces, double price, double priceDistance, double weightCoefficient)
        {
            return (priceDistance * weightCoefficient) + (price * pieces);
        }
    }
}
