using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Test2.Domain.Figures.Entities;
using Test2.Domain.Figures.Queries;
using Test2.Domain.Figures.Repositories;

namespace Test2.Domain.Figures.Handlers
{
    public class GetFigureByIdQueryHandler : IRequestHandler<GetFigureByIdQuery, Figure>
    {
        private readonly IFigureRepository _repository;
        
        public GetFigureByIdQueryHandler(IFigureRepository repository)
        {
            this._repository = repository;
        }
        
        public async Task<Figure> Handle(GetFigureByIdQuery query, CancellationToken cancellationToken)
        {
            return await this._repository.GetById(query.Id);
        }
    }
}