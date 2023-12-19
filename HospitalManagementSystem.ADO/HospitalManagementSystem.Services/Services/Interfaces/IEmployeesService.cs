using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.DTOs.DTOs.Requests.Employee;
using HospitalManagementSystem.DTOs.DTOs.Responses.Employee;
using HospitalManagementSystem.Entities;

namespace HospitalManagementSystem.Services.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<Response<IEnumerable<GETEmployee>>> GetEmployeesAsync();

        Task<Response<GETEmployee>> GetEmployeeByIdAsync(Guid ID);

        Task<Response<IEnumerable<GETEmployee>>> InsertEmployeeAsync(INSERTEmployee employee);

        Task<Response<IEnumerable<GETEmployee>>> UpdateEmployeeAsync(INSERTEmployee employee);

        Task<Response<IEnumerable<GETEmployee>>> DeleteEmployeeAsync(Guid Id);

        Task<Response<IEnumerable<GETEmployee>>> GetEmployeesByRoleAsync(string roleName);
    }
}
