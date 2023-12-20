using HospitalManagementSystem.Domains.Common.Interfaces;
using HospitalManagementSystem.Shared.Response;

namespace HospitalManagementSystem.Application.Generics.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : IEntity
    {
        IQueryable<TEntity> Entities { get; }

        Task<Response<IEnumerable<TEntity>>> GetEntitiesAsync();

        Task<Response<TEntity>> GetEntityByIdAsync(Guid Id);

        Task<Response<TEntity>> InsertEntityAsync(TEntity entity);

        Task<Response<TEntity>> UpdateEntityAsync(TEntity entity);

        Task<Response<IEnumerable<TEntity>>> DeleteEntityByIdAsync(Guid id);
    }
}
