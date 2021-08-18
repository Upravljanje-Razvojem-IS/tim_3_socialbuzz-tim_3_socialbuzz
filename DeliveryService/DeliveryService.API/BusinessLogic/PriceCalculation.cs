namespace DeliveryService.API.BusinessLogic
{
    public static class PriceCalculation
    {
        public static double Calculate(int pieces, double price, double priceDistance, double weightCoefficient)
        {
            /*
              Izračunava se ukupna cena kupovine. 
              Prvi deo predstavlja ukupnu cenu dostave, dok drugi predstavlja ukupnu cenu proizvoda.
              Ukupna cena dostave => cena razdaljine x koeficijent težine
              Ukupna cena proizvoda => cena proizvoda x broj komada
            */
            return (priceDistance * weightCoefficient) + (price * pieces);
        }
    }
}
