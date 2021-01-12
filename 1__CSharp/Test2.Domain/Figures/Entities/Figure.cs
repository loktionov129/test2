namespace Test2.Domain.Figures.Entities
{
    public record Figure
    {
        public int Id { get; set; }
        public string Data { get; set; }

        public Figure(string data, int id = 0)
        {
            this.Data = data;
            this.Id = id;
        }
    }
}
