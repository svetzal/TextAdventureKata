using Engine;
using Engine.Actions;
using Engine.Locations;
using Xunit;

namespace EngineTests.Actions
{
    public class TurnActionShould
    {
        [Fact]
        public void TurnRight()
        {
            var turnAction = new TurnAction();
            var engine = new TextAdventureEngine(new NormalLocation(), DirectionCalculator.North);
            turnAction.Execute(engine, new[] {"turn", "right"});
            Assert.Equal(1, engine.CurrentOrientation);
        }
    }
}