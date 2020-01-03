namespace Engine.Actions
{
    public class QuitAction : IWrittenAction
    {
        public string Execute(TextAdventureEngine engine, string[] parts)
        {
            engine.Halt();
            return "Bye!";
        }
    }
}