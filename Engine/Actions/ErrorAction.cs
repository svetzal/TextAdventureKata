namespace Engine.Actions
{
    public class ErrorAction : IWrittenAction
    {
        public string Execute(TextAdventureEngine engine, string[] parts)
        {
            return "Unrecognized command";
        }
    }
}