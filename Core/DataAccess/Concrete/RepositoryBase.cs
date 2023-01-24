using Core.DataAccess.Abstract;
using Core.Entities;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : IdentityDbContext<AppUser>
    {

        private readonly TContext _context;

        public RepositoryBase(TContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> exp = null, params string[] includes)
        {
            IQueryable<TEntity> query = GetQuery(includes);
            return exp is null ? await query.ToListAsync() : await query.Where(exp).ToListAsync();

        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }
        private IQueryable<TEntity?> GetQuery(string[] includes)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if (includes is not null)
            {
                foreach (var item in includes)
                {

                    query.Include(item);
                }
            }
            return query;

        }
    }
}
