using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test2.Domain;

namespace Test2.DataAccess
{
    public class EfRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        public EfRepository(TContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
            Set = Context.Set<TEntity>();
        }

        protected TContext Context { get; }

        public DbSet<TEntity> Set { get; }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var entry = await Set.AddAsync(entity);
            await Context.SaveChangesAsync();

            return entry.Entity;
        }
    }
}