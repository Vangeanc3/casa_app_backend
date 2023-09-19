using casa_app_backend.Application.Interfaces.Repository;
using casa_app_backend.Domain.Exceptions;
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
        public virtual async Task<T> Get(int id)
        {
            return await dbSet.FindAsync(id) ?? throw new BusinessException($"Registro {id} não encontrado");
        }
        public virtual async Task Create(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(int id)
        {
            // OLHAR DEPOIS ISSO
            dbSet.Remove(new T { Id = id });
            await SaveChanges();
        }
        public virtual async Task Update(T entity)
        {
            dbSet.Update(entity);
            await SaveChanges();
        }
        public virtual async Task<int> SaveChanges()
        {
            return await db.SaveChangesAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }
    }
}