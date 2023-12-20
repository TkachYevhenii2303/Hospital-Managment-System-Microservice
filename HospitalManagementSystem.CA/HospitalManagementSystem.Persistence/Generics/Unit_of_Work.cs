using HospitalManagementSystem.Application.Generics.Interfaces;
using Hospital_Management_System_Persistence.Context;
using System.Collections;
using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Persistence.Generics
{
    public class Unit_of_Work : IUnit_of_Work
    {
        private readonly ApplicationDbContext _context;
        
        private Hashtable _repositories;
        
        private bool _disposed;

        public Unit_of_Work(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose() => _context.Dispose();

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : AuditableEntity
        {
            if (_repositories is null) { _repositories = new Hashtable(); }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepository<>);

                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return _repositories[type] as IGenericRepository<TEntity>;

        }

        public Task Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
            return Task.CompletedTask;
        }

        public async Task<int> Save(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task<int> SaveAndRemoveCache(CancellationToken cancellationToken, params string[] cacheKeys)
        {
            throw new NotImplementedException();
        }
    }
}
