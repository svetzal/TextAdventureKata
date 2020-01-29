using System;
using System.Linq;

namespace Engine.Actions
{
    public class MoveAction : IWrittenAction
    {
        public string Execute(TextAdventureEngine engine, string[] parts)
        {
            var direction = -1;
            
            if ("forward" == parts.Last())
                direction = engine.CurrentOrientation;
            else if ("backward" == parts.Last())
                direction = DirectionCalculator.Reverse(engine.CurrentOrientation);

            if (direction == -1) return $"I don't know how to move {parts.Last()}";
            if (engine.CurrentLocation.Directions[direction] == null) return $"You cannot move {parts.Last()}";
            
            var oldLocation = engine.CurrentLocation;
            engine.CurrentLocation = oldLocation.Directions[direction];

            return $"You move {parts.Last()}";
        }
    }
}