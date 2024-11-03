namespace KoiCareSystem.Models
{
    public class WaterParameter
    {
        public int Id { get; set; }
        public float Temperature { get; set; }
        public float Salt { get; set; }
        public float PH { get; set; }
        public float Oxygen { get; set; }
        public float Nitrite { get; set; }
        public float Nitrate { get; set; }
        public float Phosphate { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
