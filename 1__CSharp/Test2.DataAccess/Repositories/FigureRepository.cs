using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test2.Domain.Figures.Entities;
using Test2.Domain.Figures.Repositories;

namespace Test2.DataAccess.Repositories
{
    public class FigureRepository : EfRepository<Figure, AppDbContext>, IFigureRepository
    {
        public FigureRepository(AppDbContext context)
            : base(context)
        {
        }

        public async Task<Figure> GetById(int id)
        {
            return await Context.Figures.FirstOrDefaultAsync(b => b.Id == id)
                ?? throw new ArgumentException($"Figure with id={id} not found!");
        }
    }
}