using Engine;
using Engine.Actions;
using Engine.Locations;
using Xunit;

namespace EngineTests.Actions
{
    public class MoveActionShould
    {
        private NormalLocation _firstLocation;
        private NormalLocation _secondLocation;
        private MoveAction _moveAction;
        private TextAdventureEngine _engine;

        public MoveActionShould()
        {
            _firstLocation = new NormalLocation();
            _secondLocation = new NormalLocation();
            _firstLocation.Directions[DirectionCalculator.North] = _secondLocation;
            _secondLocation.Directions[DirectionCalculator.South] = _firstLocation;

            _moveAction = new MoveAction();
            _engine = new TextAdventureEngine(_firstLocation, DirectionCalculator.North);
        }
        
        [Fact]
        public void MoveForward()
        {
            _engine.CurrentOrientation = DirectionCalculator.North;
            _moveAction.Execute(_engine, new[] {"move", "forward"});
            Assert.Equal(_secondLocation, _engine.CurrentLocation);
        }

        [Fact]
        public void MoveBackward()
        {
            _engine.CurrentOrientation = DirectionCalculator.South;
            _moveAction.Execute(_engine, new[] {"move", "backward"});
            Assert.Equal(_secondLocation, _engine.CurrentLocation);
        }
    }
}