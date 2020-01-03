using Engine;
using Xunit;

namespace EngineTests
{
    public class CommandParserShould
    {
        private readonly CommandParser _parser = new CommandParser();

        [Fact]
        public void EnsureLowerCase()
        {
            Assert.Equal(new[] {"one", "two"}, _parser.Parse("One TWO"));
        }

        [Fact]
        public void NormalizeSpacing()
        {
            Assert.Equal(new[] {"one", "two"}, _parser.Parse("   one     two "));
        }
    }
}