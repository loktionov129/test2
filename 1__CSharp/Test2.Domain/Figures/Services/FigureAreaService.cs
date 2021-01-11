using Newtonsoft.Json.Linq;
using Test2.Domain.Figures.Entities;
using Test2.Domain.Figures.Shapes;

namespace Test2.Domain.Figures.Services
{
    public class FigureAreaService
    {
        private readonly Figure _figure;

        public FigureAreaService(Figure figure)
        {
            this._figure = figure;
        }

        public double CalculateArea()
        {
            var type = JObject.Parse(this._figure.Data)["type"].ToString();
            
            return type switch
            {
                "Circle" => Calculate<Circle>(),
                "Triangle" => Calculate<Triangle>(),
                _ => 0
            };
        }

        private double Calculate<TShape>() where TShape : Shape
        {
            var shape = Newtonsoft.Json.JsonConvert.DeserializeObject<TShape>(this._figure.Data);

            return shape.GetArea();
        }
    }
}