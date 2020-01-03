using System.IO;
using System.Text;
using Engine.Locations;

namespace Engine
{
    public class TextUserInterface : IUserInterface
    {
        private readonly TextReader _reader;
        private readonly TextWriter _writer;

        public TextUserInterface(TextWriter writer, TextReader reader)
        {
            _writer = writer;
            _reader = reader;
        }

        public void Render(int orientation, ILocation location)
        {
            _writer.WriteLine(ConstructDescription(orientation, location));
        }

        public void Render(string message)
        {
            _writer.WriteLine(message);
        }

        private string ConstructDescription(int orientation, ILocation location)
        {
            string[] directionalPreambles = {"Ahead of you", "To your left", "Behind you", "To your right"};

            var sb = new StringBuilder();

            sb.Append(location.DetailedSensation);
            sb.Append(" ");

            for (var i = 0; i < 4; i++)
            {
                var offsetOrientation = (i + orientation) % 4;
                if (location.Directions[i] != null)
                {
                    sb.Append(directionalPreambles[offsetOrientation]);
                    sb.Append(", ");
                    sb.Append(location.Directions[i].NearbySensation);
                    sb.Append(". ");
                }
            }

            return sb.ToString().Trim();
        }

        public string GetCommand()
        {
            _writer.Write("You: ");
            return _reader.ReadLine();
        }
    }
}