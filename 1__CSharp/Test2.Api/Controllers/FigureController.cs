using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test2.Domain.Figures.Commands;
using Test2.Domain.Figures.Queries;
using Test2.Domain.Figures.Services;
using Test2.Domain.Figures.Shapes;

namespace Test2.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FigureController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FigureController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpPost]
        public async Task<int> Post([FromBody] Shape shape)
        {
            return await this._mediator.Send(new CreateFigureCommand(shape));
        }

        [HttpGet("{id}")]
        public async Task<double> Get(int id)
        {
            return await this._mediator.Send(new GetFigureAreaByIdQuery(id));
        }
    }
}