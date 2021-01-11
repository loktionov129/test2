using Microsoft.EntityFrameworkCore;
using Test2.Domain.Figures.Entities;

namespace Test2.DataAccess
{
    public class AppDbContext : DbContext
    {
        public DbSet<Figure> Figures { get; set; }

        public AppDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=app.db");
    }
}