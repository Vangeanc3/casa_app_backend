using casa_app_backend.Application.Interfaces.Repository;
using casa_app_backend.Application.Interfaces.Services;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : Entity, new()
    {
        protected readonly IBaseRepositoryEF<T> baseRepository;

        public BaseService(IBaseRepositoryEF<T> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public virtual async Task Create(T entity)
        {
            await baseRepository.Create(entity);
        }

        public virtual async Task Delete(int id)
        {
            await baseRepository.Delete(id);
        }

        public virtual async Task<T> Get(int id)
        {
            return await baseRepository.Get(id);
        }

        public virtual async Task<List<T>> List()
        {
            return await baseRepository.List();
        }

        public virtual async Task Update(T entity)
        {
            await baseRepository.Update(entity);
        }
    }
}