namespace Engine.Locations
{
    public class NormalLocation : ILocation
    {
        public ILocation[] Directions { get; set; }
        public string DetailedSensation { get; set; }
        public string NearbySensation { get; set; }

        public NormalLocation()
        {
            Directions = new ILocation[] {null, null, null, null};
        }
    }
}