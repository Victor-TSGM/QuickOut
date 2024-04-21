
namespace QuickOut.Domain.Estabilishments
{
    public class Location
    {
        public Guid Id  { get; set; }
        public Estabilishment Estabilishment { get; set; }
        public string Latitude { get; set; }
        public string Logitude { get; set; }
    }
}
