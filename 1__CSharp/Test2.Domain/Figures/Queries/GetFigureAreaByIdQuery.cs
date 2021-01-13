using MediatR;

namespace Test2.Domain.Figures.Queries
{
    public class GetFigureAreaByIdQuery : IRequest<double>
    {
        public int Id { get; set; }

        public GetFigureAreaByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
