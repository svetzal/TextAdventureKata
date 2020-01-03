using System.Linq;

namespace Engine.Actions
{
    public class MoveAction : IWrittenAction
    {
        public string Execute(TextAdventureEngine engine, string[] parts)
        {
            var direction = -1;

            if ("forward" == parts.Last())
                direction = engine.Orientation;
            else if ("backward" == parts.Last())
                direction = DirectionCalculator.Reverse(engine.Orientation);

            if (direction >= 0)
            {
                var oldLocation = engine.Location;
                engine.Location = oldLocation.Directions[direction];

                return $"You move {parts.Last()}";
            }

            return $"I don't know how to move {parts.Last()}";
        }
    }
}