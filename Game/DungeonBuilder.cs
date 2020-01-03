using System.Data;
using Engine;
using Engine.Locations;

namespace Game
{
    public class DungeonBuilder
    {
        public ILocation Build()
        {
            var entranceRoom = new NormalLocation
            {
                NearbySensation = "you hear the howling of the winter wind",
                DetailedSensation = "The room is chilly, and sounds small.",
            };

            var keyRoom = new NormalLocation
            {
                NearbySensation = "you hear water dripping", 
                DetailedSensation = "Water drips nearby, and the room echoes hollowly. You feel something sharp and hard under your foot.",
            };
            var key = new InventoryItem
            {
                Name = "key",
            };
            keyRoom.Items.Add(key);
            
            var exitRoom = new ExitLocation
            {
                NearbySensation = "you hear the howling of the winter wind",
            };

            Connect(DirectionCalculator.North, entranceRoom, keyRoom);
            Connect(DirectionCalculator.South, entranceRoom, exitRoom);
            
            return entranceRoom;
        }

        private static void Connect(int direction, ILocation from, ILocation to)
        {
            from.Directions[direction] = to;
            to.Directions[DirectionCalculator.Reverse(direction)] = from;
        }
    }
}