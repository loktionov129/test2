namespace Test2.Domain.Figures.Shapes
{
    public abstract record Shape
    {
        public virtual string Type { get; }
        
        public abstract double GetArea();
    }
}