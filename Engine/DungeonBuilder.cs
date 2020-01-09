using Engine.Locations;

namespace Engine
{
    public class DungeonBuilder
    {
        public static void Connect(int direction, ILocation from, ILocation to)
        {
            from.Directions[direction] = to;
            to.Directions[DirectionCalculator.Reverse(direction)] = @from;
        }
    }
}