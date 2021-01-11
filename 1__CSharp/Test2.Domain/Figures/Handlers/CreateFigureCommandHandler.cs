using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Test2.Domain.Figures.Commands;
using Test2.Domain.Figures.Entities;
using Test2.Domain.Figures.Repositories;

namespace Test2.Domain.Figures.Handlers
{
    public class CreateFigureCommandHandler : IRequestHandler<CreateFigureCommand, int>
    {
        private readonly IFigureRepository _repository;
        
        public CreateFigureCommandHandler(IFigureRepository repository)
        {
            this._repository = repository;
        }
        
        public async Task<int> Handle(CreateFigureCommand command, CancellationToken cancellationToken)
        {
            var figure = await this._repository.AddAsync(new Figure(command.Data));

            return figure.Id;
        }
    }
}