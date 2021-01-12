using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test2.Domain.Figures.Commands;
using Test2.Domain.Figures.Queries;
using Test2.Domain.Figures.Services;

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
        public async Task<int> Post([FromBody] object shape)
        {
            var data = Newtonsoft.Json.JsonConvert.SerializeObject(shape);

            return await this._mediator.Send(new CreateFigureCommand(data));
        }

        [HttpGet("{id}")]
        public async Task<double> Get(int id)
        {
            var figure = await this._mediator.Send(new GetFigureByIdQuery(id));

            return new FigureAreaService(figure).CalculateArea();
        }
    }
}