using Moq;
using Xunit;

namespace MazeSolverTests
{
    public class NoTests
    {
        public readonly Mock<IList<string>> strings;

        //ha ha , no tests
        [Fact]
        public void ShouldTrueIsTrue()
        {
            Assert.True(true);
        }
    }
}