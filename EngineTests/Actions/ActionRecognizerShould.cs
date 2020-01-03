using Engine.Actions;
using Xunit;

namespace EngineTests.Actions
{
    public class ActionRecognizerShould
    {
        [Fact]
        public void Exist()
        {
            var ar = new ActionRecognizer<QuitAction>(parts => parts.Length == 1 && parts[0] == "quit");
            Assert.IsType<QuitAction>(ar.Recognize(new[] {"quit"}));
        }
    }
}