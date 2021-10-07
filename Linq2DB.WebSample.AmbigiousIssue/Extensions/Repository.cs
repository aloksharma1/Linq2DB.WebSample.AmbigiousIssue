using Linq2DB.WebSample.AmbigiousIssue.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Linq2DB.WebSample.AmbigiousIssue.Extensions
{
    public class Repository<TEntity, TDbContext> : IRepository<TEntity, TDbContext> where TEntity : class, new()
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> dbSet;
        public Repository(TDbContext dbContext)
        {
            _dbContext = dbContext as DbContext;
            this.dbSet = _dbContext.Set<TEntity>();
        }
        public IQueryable<TEntity> Query()
        {
            return dbSet;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
    }
}
