using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Newtonsoft.Json;
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
            var data = JsonConvert.SerializeObject(command.Data);
            var figure = await this._repository.AddAsync(new Figure(data));

            return figure.Id;
        }
    }
}