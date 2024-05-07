using QuickOut.Library;

namespace QuickOut.Domain.Estabilishments
{
    public class Location
    {
        public string Latitude { get; private set; }
        public string Logitude { get; private set; }
        
        protected Location()
        {
            
        }

        public Result<Location> New(string latitude, string longitude)
        {
            //Validar latitude e longitude

            Location location = new Location()
            {
                Latitude = latitude,
                Logitude = longitude
            };
            
            return Result<Location>.Success(location);
        }
    }
}