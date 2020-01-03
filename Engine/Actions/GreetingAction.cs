using System.Linq;

namespace Engine.Actions
{
    public class GreetingAction : IWrittenAction
    {
        public string Execute(TextAdventureEngine engine, string[] parts)
        {
            return $"Hello, {parts.Last()}!";
        }
    }
}