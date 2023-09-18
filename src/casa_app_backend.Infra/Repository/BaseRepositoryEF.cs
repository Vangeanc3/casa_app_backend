using System.Linq.Expressions;
using casa_app_backend.Application.Interfaces.Repository;
using casa_app_backend.Domain.Models;
using casa_app_backend.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace casa_app_backend.Infra.Repository
{
    public class BaseRepositoryEF<T> : IBaseRepositoryEF<T> where T : Entity, new()
    {
        protected readonly AppDbContext db;
        protected readonly DbSet<T> dbSet;

        public BaseRepositoryEF(AppDbContext db)
        {
            this.db = db;
            dbSet = db.Set<T>();
        }
        public virtual async Task<List<T>> List()
        {
            return await dbSet.AsNoTracking().ToListAsync();
        }
        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }
        public Task Create(T request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
        public Task Update(T request)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}