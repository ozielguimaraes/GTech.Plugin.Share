namespace GTech.Plugin.Share
{
    public class Position
    {
        public Position(float latitude, float longitude, string addressToDisplay = null)
        {
            Address = addressToDisplay;
            Latitude = latitude;
            Longitude = longitude;
        }

        public string Address { get; private set; }
        public float Latitude { get; private set; }
        public float Longitude { get; private set; }
    }
}