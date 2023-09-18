using casa_app_backend.Domain.Models;

namespace casa_app_backend.Application.Interfaces.Repository
{
    public interface IBaseRepositoryEF<T> : IDisposable where T : Entity 
    {
        Task<List<T>> List();
        Task<T> Get(int id);
        Task Create(T request);
        Task Update(T request);
        Task Delete(int id);
    }
}