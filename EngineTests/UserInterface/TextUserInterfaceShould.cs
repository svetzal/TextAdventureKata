using System.IO;
using System.Text;
using Engine;
using Engine.Locations;
using Xunit;

namespace EngineTests.UserInterface
{
    public class TextUserInterfaceShould
    {
        private readonly ILocation _entrance = new NormalLocation();
        private readonly StringBuilder _output;
        private readonly StringWriter _writer;
        private readonly TextUserInterface _ui;

        public TextUserInterfaceShould()
        {
            _output = new StringBuilder();
            _writer = new StringWriter(_output);
            _ui = new TextUserInterface(_writer, null);
            _entrance.Directions[0] = new NormalLocation
            {
                NearbySensation = "sensation north",
            };
            _entrance.Directions[2] = new NormalLocation
            {
                NearbySensation = "sensation south",
            };
        }

        [Fact]
        public void RenderCorrectlyOrientedDescriptionText()
        {
            var orientation = 1;
            _ui.Render(orientation, _entrance);
            Assert.Equal(
                "To your left, sensation north. To your right, sensation south.\n",
                _writer.ToString());
        }

        [Fact]
        public void RenderDescriptionText()
        {
            var orientation = 0;
            _ui.Render(orientation, _entrance);
            Assert.Equal(
                "Ahead of you, sensation north. Behind you, sensation south.\n",
                _writer.ToString());
        }
    }
}