using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.DTOs.DTOs.Requests.Employee;
using HospitalManagementSystem.DTOs.DTOs.Responses.Employee;

namespace HospitalManagementSystem.Services.Services.Interfaces
{
    public interface IEmployeesService
    {
        Task<Response<IEnumerable<EmployeeResponse>>> GetEmployeesAsync();

        Task<Response<EmployeeResponse>> GetEmployeeByIdAsync(Guid ID);

        Task<Response<IEnumerable<EmployeeResponse>>> InsertEmployeeAsync(EmployeeRequest employee);

        Task<Response<IEnumerable<EmployeeResponse>>> UpdateEmployeeAsync(EmployeeUpdateRequest employee);

        Task<Response<IEnumerable<EmployeeResponse>>> DeleteEmployeeAsync(Guid Id);
    }
}
