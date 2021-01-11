namespace Test2.Domain.Figures.Shapes
{
    public abstract class Shape
    {
        public virtual string Type { get; }
        
        public abstract double GetArea();
    }
}