using Engine;
using Xunit;

namespace EngineTests
{
    public class DirectionCalculatorShould
    {
        [Fact]
        public void ReturnSouthWhenReversedFromNorth()
        {
            Assert.Equal(DirectionCalculator.South, DirectionCalculator.Reverse(DirectionCalculator.North));
        }

        [Fact]
        public void ReturnNorthWhenReversedFromSouth()
        {
            Assert.Equal(DirectionCalculator.North, DirectionCalculator.Reverse(DirectionCalculator.South));
        }

        [Fact]
        public void ReturnEastWhenReversedFromWest()
        {
            Assert.Equal(DirectionCalculator.West, DirectionCalculator.Reverse(DirectionCalculator.East));
        }
    }
}