using HospitalManagementSystem.Domains.Common;
using Hospital_Management_System_Persistence.Context;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Application.Generics.Interfaces;
using HospitalManagementSystem.Shared.Response;

namespace HospitalManagementSystem.Persistence.Generics
{
    public class GenericRepository<TEntiy> : IGenericRepository<TEntiy>
        where TEntiy : AuditableEntity
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
            => _context = context;

        public IQueryable<TEntiy> Entities => _context.Set<TEntiy>();

        public async Task<Response<IEnumerable<TEntiy>>> GetEntitiesAsync()
        {
            var result = new Response<IEnumerable<TEntiy>>();

            result.Data = await Entities.AsNoTracking().ToListAsync();

            result.Message = "Impressive work! Your method for fetching all entities from the database in C# is top-notch. Great job!";

            return result;
        }

        public async Task<Response<TEntiy>> GetEntityByIdAsync(Guid id)
        {
            var result = new Response<TEntiy>();

            result.Data = await Entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            result.Message = $"Impressive work! Your method for fetching entity using its ID {id} from the database in C# is top-notch. Great job!";

            return result;
        }

        public async Task<Response<TEntiy>> InsertEntityAsync(TEntiy entity)
        {
            var result = new Response<TEntiy>() { Data = entity };

            await _context.Set<TEntiy>().AddAsync(entity);

            result.Message = "The data has been successfully inserted into the table, " +
                "showcasing your expertise in database operations and precise implementation in C#. Well done!";

            return result;
        }

        public async Task<Response<TEntiy>> UpdateEntityAsync(TEntiy entity)
        {
            var result = new Response<TEntiy>() { Data = entity };

            result.Data = await Entities.AsNoTracking().FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (result.Data is null)
            {
                throw new KeyNotFoundException($"The specified entity ID {entity.Id} was not found in the database. Please verify the ID and try again.");
            }

            _context.Update(entity);

            result.Message = "Entity Update Successful! Your code executed flawlessly, resulting in the successful update of the entity. Great job!";

            return result;
        }

        public async Task<Response<IEnumerable<TEntiy>>> DeleteEntityByIdAsync(Guid id)
        {
            var resul = new Response<IEnumerable<TEntiy>>();

            var exist = await Entities.FirstOrDefaultAsync(x => x.Id == id);

            if (exist is null)
            {
                throw new KeyNotFoundException($"The specified entity ID {id} was not found in the database. Please verify the ID and try again.");
            }

            _context.Remove(exist);

            resul.Data = await Entities.AsNoTracking().ToListAsync();

            resul.Message = "Deletion Successful: Your code has successfully removed the specified data from the database.";

            return resul;
        }
    }
}
