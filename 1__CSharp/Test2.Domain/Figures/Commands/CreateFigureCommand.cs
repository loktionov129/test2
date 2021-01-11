using MediatR;

namespace Test2.Domain.Figures.Commands
{
    public class CreateFigureCommand : IRequest<int>
    {
        public string Data { get; set; }

        public CreateFigureCommand(string data)
        {
            this.Data = data;
        }
    }
}
