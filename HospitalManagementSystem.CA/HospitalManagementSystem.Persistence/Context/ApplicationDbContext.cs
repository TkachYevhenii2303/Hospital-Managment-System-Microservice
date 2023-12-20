using HospitalManagementSystem.Domains.Entities;
using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.Domains.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Hospital_Management_System_Persistence.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IDomainEventDispatcher _dispatcher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options,  IDomainEventDispatcher dispatcher)
            : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<InDepartment> InDepartments => Set<InDepartment>();

        public DbSet<Patient> Patients => Set<Patient>();
        
        public DbSet<PatientCase> PatientsCases => Set<PatientCase>();
        
        public DbSet<Appointment> Appointments => Set<Appointment>();
        
        public DbSet<DocumentType> DocumentsTypes => Set<DocumentType>();
        
        public DbSet<Document> Documents => Set<Document>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            if (_dispatcher is null) { return result; }

            var entitiesWithEvent = ChangeTracker.Entries<Entity>()
                .Select(ent => ent.Entity)
                .Where(ent => ent.DomainEvents.Any())
                .ToArray();

            await _dispatcher.DispatchAndClearEventsAsync(entitiesWithEvent);

            return result;
        }
    }
}
