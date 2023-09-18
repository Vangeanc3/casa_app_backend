using casa_app_backend.Application.Interfaces.Services;
using casa_app_backend.Domain.Models;

namespace casa_app_backend.Application.Services
{
    public class BaseService<T> : IBaseService<T> where T : Entity, new()
    {
        public Task Create(T request)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> List()
        {
            throw new NotImplementedException();
        }

        public Task Update(T request)
        {
            throw new NotImplementedException();
        }
    }
}