namespace KoiCareSystem.Models
{
    public class Aquarium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public float Depth { get; set; }
        public float Volume { get; set; }
        public int DrainsCount { get; set; }
        public string PumpCapacity { get; set; }
    }
}
