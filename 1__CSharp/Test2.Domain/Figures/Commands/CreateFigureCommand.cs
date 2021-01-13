using MediatR;
using Test2.Domain.Figures.Shapes;

namespace Test2.Domain.Figures.Commands
{
    public class CreateFigureCommand : IRequest<int>
    {
        public Shape Data { get; set; }

        public CreateFigureCommand(Shape data)
        {
            this.Data = data;
        }
    }
}
