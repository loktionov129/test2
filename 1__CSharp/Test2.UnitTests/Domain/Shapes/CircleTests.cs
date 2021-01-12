using Test2.Domain.Figures.Shapes;
using Xunit;

namespace Test2.UnitTests.Domain.Shapes
{
    public class CircleTests
    {
        [Fact]
        public void GetArea__WhenRadiusIs4__ShouldReturn50_27()
        {
            var shape = new Circle()
            {
                R = 4.0
            };

            var expected = 50.27;
            var actual = shape.GetArea();
            
            Assert.Equal(expected, actual);
        }
    }
}