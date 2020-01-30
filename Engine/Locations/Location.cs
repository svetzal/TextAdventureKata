using System;
using System.Collections.Generic;

namespace Engine.Locations
{
    public class NormalLocation : ILocation
    {
        public NormalLocation()
        {
            Directions = new ILocation[] {null, null, null, null};
            Items = new List<InventoryItem>();
        }

        public ILocation[] Directions { get; }
        public string DetailedSensation { get; set; }
        public string NearbySensation { get; set; }
        public List<InventoryItem> Items { get; set; }
        public Func<TextAdventureEngine, TextUserInterface, bool> Logic { get; set; }
    }
}