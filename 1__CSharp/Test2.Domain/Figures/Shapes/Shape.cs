namespace Test2.Domain.Figures.Shapes
{
    public record Shape
    {
        public virtual string Type { get; }
        
        public virtual double GetArea() => 0;
    }
}