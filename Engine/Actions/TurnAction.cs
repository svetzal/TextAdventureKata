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
            var adjustment = 0;
            var directionLabel = string.Empty;

            if (RightSynonyms.Contains(parts.Last()))
            {
                adjustment = 1;
                directionLabel = "right";
            }

            if (LeftSynonyms.Contains(parts.Last()))
            {
                adjustment = -1;
                directionLabel = "left";
            }

            if (BackwardsSynonyms.Contains(parts.Last()))
            {
                adjustment = 2;
                directionLabel = "around";
            }

            if (adjustment == 0) return "I don't understand which way you want me to turn.";

            engine.Orientation = (engine.Orientation + adjustment) % 4;
            return $"You turn {directionLabel}.";
        }
    }
}