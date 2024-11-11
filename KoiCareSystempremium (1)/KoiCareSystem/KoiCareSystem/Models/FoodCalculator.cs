// Models/FoodCalculator.cs
namespace KoiCareSystem.Models
{
    public class FoodCalculator
    {
        public static double CalculateFoodAmount(double weight, double percentage)
        {
            return weight * percentage / 100;
        }
    }
}
