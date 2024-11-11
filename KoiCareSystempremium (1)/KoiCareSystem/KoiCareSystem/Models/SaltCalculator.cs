// Models/SaltCalculator.cs
namespace KoiCareSystem.Models
{
    public class SaltCalculator
    {
        public static double CalculateSaltAmount(double volume, double salinity)
        {
            return volume * salinity / 100;
        }
    }
}
