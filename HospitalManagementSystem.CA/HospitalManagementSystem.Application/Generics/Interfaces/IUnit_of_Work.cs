using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Application.Generics.Interfaces
{
    public interface IUnit_of_Work : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>()
            where TEntity : AuditableEntity;

        Task<int> Save(CancellationToken cancellationToken);

        Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys);
        
        Task Rollback();
    }
}
