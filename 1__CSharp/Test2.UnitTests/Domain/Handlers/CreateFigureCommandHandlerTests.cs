using System.Threading;
using System.Threading.Tasks;
using Moq;
using Test2.Domain.Figures.Commands;
using Test2.Domain.Figures.Entities;
using Test2.Domain.Figures.Handlers;
using Test2.Domain.Figures.Repositories;
using Test2.Domain.Figures.Shapes;
using Xunit;

namespace Test2.UnitTests.Domain.Handlers
{
    public class CreateFigureCommandHandlerTests
    {
        private readonly Mock<IFigureRepository> _figureRepositoryMock;
        
        public CreateFigureCommandHandlerTests()
        {
            var data = @"{""r"":4,""type"":""Circle""}";
            var figure = new Figure(data, 3);
            _figureRepositoryMock = new Mock<IFigureRepository>();
            _figureRepositoryMock.Setup(repository => repository.AddAsync(It.IsAny<Figure>()))
                .Returns(Task.FromResult(figure));
        }
        
        [Fact]
        public async Task Handle__ShouldCreateFigure__Returns3()
        {
            var handler = new CreateFigureCommandHandler(_figureRepositoryMock.Object);
            var shape = new Circle()
            {
                R = 4.0
            };
            var command = new CreateFigureCommand(shape);

            var expected = 3;
            var actual = await handler.Handle(command, CancellationToken.None);
            
            Assert.Equal(expected, actual);
            _figureRepositoryMock.Verify(x => x.AddAsync(It.IsAny<Figure>()), Times.Once);
        }
    }
}
