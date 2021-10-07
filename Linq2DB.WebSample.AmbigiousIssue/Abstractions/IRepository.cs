using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Linq2DB.WebSample.AmbigiousIssue.Abstractions
{
    /// <summary>
    /// TEntity class will always be BaseEntity or Its Inherited Child Classes
    /// Barebone Repository
    /// </summary>
    public interface IRepository<TEntity, TDbContext> where TEntity : class
    {
        IQueryable<TEntity> Query();
        Task<int> SaveChangesAsync();
    }
}
