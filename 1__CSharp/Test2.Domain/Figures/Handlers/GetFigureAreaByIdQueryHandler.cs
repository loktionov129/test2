using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Test2.Domain.Figures.Queries;
using Test2.Domain.Figures.Repositories;
using Test2.Domain.Figures.Shapes;

namespace Test2.Domain.Figures.Handlers
{
    public class GetFigureAreaByIdQueryHandler : IRequestHandler<GetFigureAreaByIdQuery, double>
    {
        private readonly IFigureRepository _repository;
        
        public GetFigureAreaByIdQueryHandler(IFigureRepository repository)
        {
            this._repository = repository;
        }
        
        public async Task<double> Handle(GetFigureAreaByIdQuery query, CancellationToken cancellationToken)
        {
            var figure = await this._repository.GetById(query.Id);
            var shape = Newtonsoft.Json.JsonConvert.DeserializeObject<Shape>(figure.Data);

            return shape.GetArea();
        }
    }
}