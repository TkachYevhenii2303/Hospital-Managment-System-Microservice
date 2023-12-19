using HospitalManagementSystem.Domains.Repositories.Interfaces;

namespace HospitalManagementSystem.Domains.Generics.Interfaces
{
    public interface IUnit_of_Work : IDisposable
    {
        void Configurations();

        IEmployeesRepository EmployeesRepository { get; }
    }
}
