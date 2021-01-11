using MediatR;
using Test2.Domain.Figures.Entities;

namespace Test2.Domain.Figures.Queries
{
    public class GetFigureByIdQuery : IRequest<Figure>
    {
        public int Id { get; set; }

        public GetFigureByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
