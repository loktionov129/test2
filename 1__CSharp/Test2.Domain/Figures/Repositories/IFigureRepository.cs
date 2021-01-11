using System.Collections.Generic;
using System.Threading.Tasks;
using Test2.Domain.Figures.Entities;

namespace Test2.Domain.Figures.Repositories
{
    public interface IFigureRepository : IRepository<Figure>
    {
        Task<Figure> GetById(int id);
    }
}