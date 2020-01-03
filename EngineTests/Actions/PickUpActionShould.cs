using Engine;
using Engine.Actions;
using Xunit;

namespace EngineTests.Actions
{
    public class PickUpActionShould
    {
        [Fact]
        public void Exist()
        {
            var pickUpAction = new PickUpAction();
        }
    }

    public class PickUpAction : IWrittenAction
    {
        public string Execute(TextAdventureEngine engine, string[] parts)
        {
            return "";
        }
    }
}