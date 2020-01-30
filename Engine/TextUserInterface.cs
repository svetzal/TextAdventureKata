using System.Collections.Generic;
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
            string[] directionalPreambles = {"Ahead of you", "To your right", "Behind you", "To your left"};

            var sb = new StringBuilder();

            sb.Append(location.DetailedSensation);
            sb.Append(" ");

            for (var i = orientation; i < orientation + 4; i++)
            {
                var offsetOrientation = i % 4;
                if (location.Directions[offsetOrientation] != null)
                {
                    sb.Append(directionalPreambles[i - orientation]);
                    sb.Append(", ");
                    sb.Append(location.Directions[offsetOrientation].NearbySensation);
                    sb.Append(". ");
                }
            }

            return sb.ToString().Trim();
        }

        public IEnumerable<string> Commands()
        {
            while (true)
            {
                _writer.Write("You: ");
                yield return _reader.ReadLine();
            }
        }
    }
}