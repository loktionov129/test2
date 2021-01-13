using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Test2.Domain.Figures.Entities;
using Test2.Domain.Figures.Handlers;
using Test2.Domain.Figures.Queries;
using Test2.Domain.Figures.Repositories;
using Test2.Infrastructure.JsonConverters;
using Xunit;

namespace Test2.UnitTests.Domain.Handlers
{
    public class GetFigureAreaByIdQueryHandlerTests
    {
        private readonly Mock<IFigureRepository> _figureRepositoryMock;
        
        public GetFigureAreaByIdQueryHandlerTests()
        {
            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                Converters = new List<JsonConverter>{ new ShapeConverter() },
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            
            var data = @"{""r"":4,""type"":""Circle""}";
            var figure = new Figure(data);
            _figureRepositoryMock = new Mock<IFigureRepository>();
            _figureRepositoryMock.Setup(repository => repository.GetById(It.IsAny<int>()))
                .Returns(Task.FromResult(figure));
        }
        
        [Fact]
        public async Task Handle__ShouldReturnFigureArea()
        {
            var handler = new GetFigureAreaByIdQueryHandler(_figureRepositoryMock.Object);
            var query = new GetFigureAreaByIdQuery(3);

            var expected = 50.27;
            var actual = await handler.Handle(query, CancellationToken.None);
            
            Assert.Equal(expected, actual);
            _figureRepositoryMock.Verify(x => x.GetById(3), Times.Once);
        }
    }
}
