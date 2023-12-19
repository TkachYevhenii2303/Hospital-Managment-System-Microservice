using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.Domains.Common.Interfaces;

namespace HospitalManagementSystem.Domains.Generics.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : IEntity
    {
        Task<Response<IEnumerable<TEntity>>> GetEntitiesAsync();

        Task<Response<TEntity>> GetEntityByIdAsync(Guid Id);

        Task<Response<IEnumerable<TEntity>>> InsertEntityAsync(TEntity entity);

        Task<Response<IEnumerable<TEntity>>> UpdateEntityAsync(TEntity entity);

        Task<Response<IEnumerable<TEntity>>> DeleteEntityAsync(Guid Id);
    }
}
