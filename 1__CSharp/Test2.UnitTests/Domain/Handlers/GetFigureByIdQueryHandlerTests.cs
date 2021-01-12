using System.Threading;
using System.Threading.Tasks;
using Moq;
using Test2.Domain.Figures.Entities;
using Test2.Domain.Figures.Handlers;
using Test2.Domain.Figures.Queries;
using Test2.Domain.Figures.Repositories;
using Xunit;

namespace Test2.UnitTests.Domain.Handlers
{
    public class GetFigureByIdQueryHandlerTests
    {
        private readonly Mock<IFigureRepository> _figureRepositoryMock;
        
        public GetFigureByIdQueryHandlerTests()
        {
            var data = @"{""r"":4,""type"":""Circle""}";
            var figure = new Figure(data);
            _figureRepositoryMock = new Mock<IFigureRepository>();
            _figureRepositoryMock.Setup(repository => repository.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(figure));
        }
        
        [Fact]
        public async Task Handle__ShouldReturnFigure()
        {
            var handler = new GetFigureByIdQueryHandler(_figureRepositoryMock.Object);
            var query = new GetFigureByIdQuery(3);

            var expected = new Figure(@"{""r"":4,""type"":""Circle""}");
            var actual = await handler.Handle(query, CancellationToken.None);
            
            Assert.Equal(expected, actual);
            _figureRepositoryMock.Verify(x => x.GetById(3), Times.Once);
        }
    }
}
