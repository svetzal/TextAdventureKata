namespace Engine.Actions
{
    public interface IWrittenAction
    {
        string Execute(TextAdventureEngine engine, string[] parts);
    }
}