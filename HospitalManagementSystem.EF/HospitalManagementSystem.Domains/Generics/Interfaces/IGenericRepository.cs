using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Domains.Generics.Interfaces
{
    public interface IGenericRepository<TEntity> 
        where TEntity : Entity
    {
        Task<Response<IEnumerable<TEntity>>> GetEntitiesAsync();

        Task<Response<TEntity>> GetEntityByIdAsync(Guid ID);

        Task<Response<TEntity>> InsertEntityAsync(TEntity entity);

        Task<Response<TEntity>> UpdateEntityAsync(TEntity entity);

        Task<Response<IEnumerable<TEntity>>> DeleteEntityByIdAsync(Guid ID);
    }
}
