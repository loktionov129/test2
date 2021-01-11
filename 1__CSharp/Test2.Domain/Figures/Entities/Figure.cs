namespace Test2.Domain.Figures.Entities
{
    public class Figure
    {
        public int Id { get; set; }
        public string Data { get; set; }

        public Figure(string data)
        {
            this.Data = data;
        }
    }
}
