using Test2.Domain.Figures.Shapes;
using Xunit;

namespace Test2.UnitTests.Domain.Shapes
{
    public class TriangleTests
    {
        [Fact]
        public void GetArea__WhenRadiusIs4__ShouldReturn50_27()
        {
            var shape = new Triangle()
            {
                Height = 5.0,
                Base = 6.0
            };

            var expected = 15.0;
            var actual = shape.GetArea();
            
            Assert.Equal(expected, actual);
        }
    }
}