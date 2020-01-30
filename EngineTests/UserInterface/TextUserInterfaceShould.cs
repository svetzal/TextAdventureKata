using System.IO;
using System.Text;
using Engine;
using Engine.Locations;
using Xunit;

namespace EngineTests.UserInterface
{
    public class TextUserInterfaceShould
    {
        public TextUserInterfaceShould()
        {
            _output = new StringBuilder();
            _writer = new StringWriter(_output);
            _ui = new TextUserInterface(_writer, null);
            _entrance.Directions[DirectionCalculator.North] = new NormalLocation
            {
                NearbySensation = "sensation north"
            };
            _entrance.Directions[DirectionCalculator.East] = new NormalLocation
            {
                NearbySensation = "sensation east"
            };
            _entrance.Directions[DirectionCalculator.South] = new NormalLocation
            {
                NearbySensation = "sensation south"
            };
            _entrance.Directions[DirectionCalculator.West] = new NormalLocation
            {
                NearbySensation = "sensation west"
            };
        }

        private readonly ILocation _entrance = new NormalLocation();
        private readonly StringBuilder _output;
        private readonly StringWriter _writer;
        private readonly TextUserInterface _ui;

        [Fact]
        public void RenderCorrectlyOrientedDescriptionText()
        {
            _ui.Render(DirectionCalculator.East, _entrance);
            Assert.Equal(
                "Ahead of you, sensation east. To your right, sensation south. Behind you, sensation west. To your left, sensation north.\n",
                _writer.ToString());
        }

        [Fact]
        public void RenderDescriptionText()
        {
            _ui.Render(DirectionCalculator.North, _entrance);
            Assert.Equal(
                "Ahead of you, sensation north. To your right, sensation east. Behind you, sensation south. To your left, sensation west.\n",
                _writer.ToString());
        }
    }
}