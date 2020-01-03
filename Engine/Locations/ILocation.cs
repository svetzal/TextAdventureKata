namespace Engine.Locations
{
    public interface ILocation
    {
        ILocation[] Directions { get; }
        string DetailedSensation { get; }
        string NearbySensation { get; }
    }
}