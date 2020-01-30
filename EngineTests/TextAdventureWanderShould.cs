using Engine;
using Engine.Locations;
using Xunit;

namespace EngineTests
{
    public class TextAdventureWanderShould
    {
        public TextAdventureWanderShould()
        {
            _one = BuildLocation("one");
            _two = BuildLocation("two");
            _three = BuildLocation("three");
            _four = BuildLocation("four");

            DungeonBuilder.Connect(DirectionCalculator.East, _one, _two);
            DungeonBuilder.Connect(DirectionCalculator.South, _two, _three);
            DungeonBuilder.Connect(DirectionCalculator.West, _three, _four);
            DungeonBuilder.Connect(DirectionCalculator.North, _four, _one);

            _engine = new TextAdventureEngine(_one, DirectionCalculator.North);
        }

        private readonly TextAdventureEngine _engine;
        private readonly ILocation _one;
        private readonly ILocation _two;
        private readonly ILocation _three;
        private readonly ILocation _four;

        private ILocation BuildLocation(string desc)
        {
            return new NormalLocation
            {
                NearbySensation = desc,
                DetailedSensation = desc
            };
        }

        [Fact]
        public void MoveFour()
        {
            _engine.ProcessCommand("turn right");
            _engine.ProcessCommand("move forward");
            _engine.ProcessCommand("turn right");
            _engine.ProcessCommand("move forward");
            _engine.ProcessCommand("turn right");
            _engine.ProcessCommand("move forward");
            _engine.ProcessCommand("turn right");
            _engine.ProcessCommand("move forward");
            Assert.Equal(_one, _engine.CurrentLocation);
        }

        [Fact]
        public void MoveOne()
        {
            _engine.ProcessCommand("turn right");
            _engine.ProcessCommand("move forward");
            Assert.Equal(_two, _engine.CurrentLocation);
        }

        [Fact]
        public void MoveThree()
        {
            _engine.ProcessCommand("turn right");
            _engine.ProcessCommand("move forward");
            _engine.ProcessCommand("turn right");
            _engine.ProcessCommand("move forward");
            _engine.ProcessCommand("turn right");
            _engine.ProcessCommand("move forward");
            Assert.Equal(_four, _engine.CurrentLocation);
        }

        [Fact]
        public void MoveTwo()
        {
            _engine.ProcessCommand("turn right");
            _engine.ProcessCommand("move forward");
            _engine.ProcessCommand("turn right");
            _engine.ProcessCommand("move forward");
            Assert.Equal(_three, _engine.CurrentLocation);
        }
    }
}