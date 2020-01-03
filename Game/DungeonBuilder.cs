using System.Data;
using Engine;
using Engine.Locations;

namespace Game
{
    public class DungeonBuilder
    {
        public ILocation Build()
        {
            var entrance = new NormalLocation
            {
                NearbySensation = "you hear the howling of the winter wind",
                DetailedSensation = "The room is chilly, and sounds small.",
            };

            var key = new NormalLocation
            {
                NearbySensation = "you hear water dripping", 
                DetailedSensation = "Water drips nearby, and the room echoes hollowly. You feel something sharp and hard under your foot.",
            };
            
            var exit = new ExitLocation
            {
                NearbySensation = "you hear the howling of the winter wind",
            };

            Connect(DirectionCalculator.North, entrance, key);
            Connect(DirectionCalculator.South, entrance, exit);
            
            return entrance;
        }

        public static void Connect(int direction, ILocation from, ILocation to)
        {
            from.Directions[direction] = to;
            to.Directions[DirectionCalculator.Reverse(direction)] = from;
        }
    }
}