using System.Collections.Generic;

namespace Engine.Locations
{
    public class NormalLocation : ILocation
    {
        public ILocation[] Directions { get; set; }
        public string DetailedSensation { get; set; }
        public string NearbySensation { get; set; }
        public List<InventoryItem> Items { get; set; }

        public NormalLocation()
        {
            Directions = new ILocation[] {null, null, null, null};
            Items = new List<InventoryItem>();
        }
    }
}