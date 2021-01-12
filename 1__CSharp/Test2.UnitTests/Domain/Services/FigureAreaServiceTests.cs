using Test2.Domain.Figures.Entities;
using Test2.Domain.Figures.Services;
using Xunit;

namespace Test2.UnitTests.Domain.Services
{
    public class FigureAreaServiceTests
    {
        [Fact]
        public void CalculateArea__Triangle__ShouldReturnTriangleArea()
        {
            var json = @"{""height"":5,""base"":6,""type"":""Triangle""}";
            var triangle = new Figure(json);
            var service = new FigureAreaService(triangle);

            var expected = 15.0;
            var actual = service.CalculateArea();
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CalculateArea__Circle__ShouldReturnCircleArea()
        {
            var json = @"{""r"":4,""type"":""Circle""}";
            var circle = new Figure(json);
            var service = new FigureAreaService(circle);

            var expected = 50.27;
            var actual = service.CalculateArea();
            
            Assert.Equal(expected, actual);
        }
        
        [Fact]
        public void CalculateArea__Shape__ShouldReturn0()
        {
            var json = @"{""type"":""Shape""}";
            var shape = new Figure(json);
            var service = new FigureAreaService(shape);

            var expected = 0;
            var actual = service.CalculateArea();
            
            Assert.Equal(expected, actual);
        }
    }
}