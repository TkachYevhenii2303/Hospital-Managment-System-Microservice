using HospitalManagementSystem.Context;
using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.Domains.Common.Interfaces;
using HospitalManagementSystem.Domains.Generics.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Domains.Generics
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : Entity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<IEnumerable<TEntity>>> GetEntitiesAsync()
        {
            var result = new Response<IEnumerable<TEntity>>();

            result.Data = await _context.Set<TEntity>().AsNoTracking().ToListAsync();

            result.Message = $"Proccess is Good! We return all information from {typeof(GenericRepository<TEntity>).FullName}";

            return result;
        }

        public async Task<Response<TEntity>> GetEntityByIdAsync(Guid Id)
        {
            var result = new Response<TEntity>();

            result.Data = await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);

            result.Message = $"Proccess is Good! We return information from {typeof(GenericRepository<TEntity>).FullName}";

            return result;
        }

        public async Task<Response<TEntity>> InsertEntityAsync(TEntity entity)
        {
            var result = new Response<TEntity>();

            entity.CreatedDateTime = DateTime.Now;

            await _context.Set<TEntity>().AddAsync(entity);

            result.Data = entity;

            result.Message = $"Proccess is Good! We insert information int {typeof(GenericRepository<TEntity>).FullName}";

            return result;
        }

        public async Task<Response<TEntity>> UpdateEntityAsync(TEntity entity)
        {
            var result = new Response<TEntity>();

            try
            {
                entity.CreatedDateTime = DateTime.Now;

                entity.UpdatedDateTime = DateTime.Now;

                var @object = await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

                if (@object is null)
                {
                    throw new NullReferenceException($"The informations with {entity.Id} ID not found!!!");
                }

                _context.Set<TEntity>().Update(entity);

                result.Data = entity;
            }
            catch (Exception exception)
            {
                result.Success = false;

                result.Message = $"Operations {typeof(GenericRepository<TEntity>).FullName} is not valid!";

                throw new Exception($"Somethig went wrong in Delete operation! {exception.Message}");
            }

            return result;
        }

        public async Task<Response<IEnumerable<TEntity>>> DeleteEntityByIdAsync(Guid Id)
        {
            var result = new Response<IEnumerable<TEntity>>();

            try
            {
                var @object = await _context.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);

                if (@object is null)
                {
                    throw new NullReferenceException($"The informations with {Id} ID not found!!!");
                }

                _context.Set<TEntity>().Remove(@object);

                result.Data = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            }
            catch (Exception exception)
            {
                result.Success = false;

                result.Message = $"Operations {typeof(GenericRepository<TEntity>).FullName} is not valid!";

                throw new Exception($"Somethig went wrong in Delete operation! {exception.Message}");
            }

            return result;
        }
    }
}
