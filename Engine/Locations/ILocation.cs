using System;
using System.Collections.Generic;

namespace Engine.Locations
{
    public interface ILocation
    {
        ILocation[] Directions { get; }
        string DetailedSensation { get; }
        string NearbySensation { get; }
        List<InventoryItem> Items { get; set; }
        Func<TextAdventureEngine,TextUserInterface,bool> Logic { get; set; }
    }
}