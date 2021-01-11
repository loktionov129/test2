using System;

namespace Test2.Domain.Figures.Shapes
{
    public class Circle : Shape
    {
        public override string Type => "Circle";
        
        public double R { get; set; }
        
        public override double GetArea() => Math.Round(Math.PI * this.R * this.R, 2);
    }
}