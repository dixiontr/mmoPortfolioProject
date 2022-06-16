using mmo.Domain.Common;

namespace mmo.Application.Interfaces.Repositories
{

    public interface IRepository<T> where T : aBaseEntity, new()
    {
        Task<List<T>> GetAsync();
        Task<T> GetByIdAsync(Guid id);
    }

}