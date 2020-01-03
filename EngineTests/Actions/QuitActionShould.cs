using Engine;
using Engine.Actions;
using Engine.Locations;
using Xunit;

namespace EngineTests.Actions
{
    public class QuitActionShould
    {
        [Fact]
        public void Exist()
        {
            var quitAction = new QuitAction();
            var engine = new TextAdventureEngine(new NormalLocation(), DirectionCalculator.North);
            quitAction.Execute(engine, new[] {"quit"});
            Assert.Equal(TextAdventureEngine.States.Terminating, engine.CurrentState);
        }
    }
}