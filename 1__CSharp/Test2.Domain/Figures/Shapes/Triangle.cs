using System;

namespace Test2.Domain.Figures.Shapes
{
    public class Triangle : Shape
    {
        public override string Type => "Triangle";
        
        public double Height { get; set; }
        
        public double Base { get; set; }

        public override double GetArea() => Math.Round(0.5 * this.Base * this.Height);
    }
}