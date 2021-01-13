using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Moq;
using Test2.Api.Controllers;
using Test2.Domain.Figures.Commands;
using Test2.Domain.Figures.Entities;
using Test2.Domain.Figures.Queries;
using Test2.Domain.Figures.Shapes;
using Xunit;

namespace Test2.UnitTests.Api.Controllers
{
    public class FigureControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        
        public FigureControllerTests()
        {
            var data = @"{""height"":5,""base"":6,""type"":""Triangle""}";
            var figure = new Figure(data, 3);
            _mediatorMock = new Mock<IMediator>();
            _mediatorMock.Setup(mediator => mediator.Send(It.IsAny<CreateFigureCommand>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(3));
            
            _mediatorMock.Setup(mediator => mediator.Send(It.IsAny<GetFigureAreaByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(15.0));
        }
        
        [Fact]
        public async Task Post__ShouldCreateFigure__Returns3()
        {
            var controller = new FigureController(_mediatorMock.Object);
            var shape = new Triangle()
            {
                Height = 5.0,
                Base = 6.0
            };

            var expected = 3;
            var actual = await controller.Post(shape);
            
            Assert.Equal(expected, actual);
            _mediatorMock.Verify(x => x.Send(It.IsAny<CreateFigureCommand>(), CancellationToken.None), Times.Once);
        }
        
        [Fact]
        public async Task Get__ShouldCalculateTriangleArea__Returns15_0()
        {
            var controller = new FigureController(_mediatorMock.Object);

            var expected = 15.0;
            var actual = await controller.Get(3);
            
            Assert.Equal(expected, actual);
            _mediatorMock.Verify(x => x.Send(It.IsAny<GetFigureAreaByIdQuery>(), CancellationToken.None), Times.Once);
        }
    }
}