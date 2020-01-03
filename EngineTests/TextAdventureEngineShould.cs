using Engine;
using Engine.Locations;
using Xunit;

namespace EngineTests
{
    public class TextAdventureEngineShould
    {
        private static readonly int _orientation = 1;
        private static readonly ILocation _entrance = new NormalLocation();
        private readonly TextAdventureEngine _engine = new TextAdventureEngine(_entrance, _orientation);

        [Fact]
        public void Quit()
        {
            var result = _engine.ProcessCommand("quit");
            Assert.Equal("Bye!", result);
            Assert.Equal(TextAdventureEngine.States.Terminating, _engine.CurrentState);
        }

        [Fact]
        public void RejectInvalidCommand()
        {
            var result = _engine.ProcessCommand("blah");
            Assert.Equal("Unrecognized command", result);
        }

        [Fact]
        public void SayHello()
        {
            Assert.Equal("Hello, blah!", _engine.ProcessCommand("My name is blah"));
        }

        [Fact]
        public void StartAwaitingInput()
        {
            Assert.Equal(TextAdventureEngine.States.NeedsInput, _engine.CurrentState);
        }

        [Fact]
        public void StartWithInitialLocations()
        {
            Assert.Equal(_entrance, _engine.Location);
        }

        [Fact]
        public void StartWithInitialOrientation()
        {
            Assert.Equal(_engine.Orientation, _orientation);
        }
    }
}