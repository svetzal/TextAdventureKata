using System.Linq;

namespace Engine.Actions
{
    public class TurnAction : IWrittenAction
    {
        private static readonly string[] RightSynonyms =
        {
            "right", "clockwise", "clock-wise"
        };

        private static readonly string[] LeftSynonyms =
        {
            "left", "counterclockwise", "counter-clockwise"
        };

        private static readonly string[] BackwardsSynonyms =
        {
            "around", "about"
        };

        public string Execute(TextAdventureEngine engine, string[] parts)
        {
            var directionLabel = string.Empty;

            if (RightSynonyms.Contains(parts.Last()))
            {
                engine.CurrentOrientation = DirectionCalculator.TurnRight(engine.CurrentOrientation);
                directionLabel = "right";
            }

            if (LeftSynonyms.Contains(parts.Last()))
            {
                engine.CurrentOrientation = DirectionCalculator.TurnLeft(engine.CurrentOrientation);
                directionLabel = "left";
            }

            if (BackwardsSynonyms.Contains(parts.Last()))
            {
                engine.CurrentOrientation = DirectionCalculator.Reverse(engine.CurrentOrientation);
                directionLabel = "around";
            }

            return directionLabel == string.Empty ? "I don't understand which way you want me to turn." : $"You turn {directionLabel}.";
        }
    }
}