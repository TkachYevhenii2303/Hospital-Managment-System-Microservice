using HospitalManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HospitalManagementSystem.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) 
            : base(options) { }

        public DbSet<InDepartment> InDepartments { get; set; }

        public DbSet<Patient> Patients { get; set; }
        
        public DbSet<PatientCase> PatientsCases { get; set; }
        
        public DbSet<AppointmentStatuse> AppointmentsStatuses { get; set; }
        
        public DbSet<Appointment> Appointments { get; set; }
        
        public DbSet<StatusHistory> StatusHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
