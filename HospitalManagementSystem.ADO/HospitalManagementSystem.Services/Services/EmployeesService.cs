using AutoMapper;
using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.Domains.Entities.Structures;
using HospitalManagementSystem.Domains.Generics.Interfaces;
using HospitalManagementSystem.DTOs.DTOs.Requests.Employee;
using HospitalManagementSystem.DTOs.DTOs.Responses.Employee;
using HospitalManagementSystem.Entities;
using HospitalManagementSystem.Services.Services.Interfaces;

namespace HospitalManagementSystem.Services.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IUnit_of_Work _unit_of_Work;

        private readonly IMapper _mapper;

        public EmployeesService(IUnit_of_Work unit_of_Work, IMapper mapper)
        {
            _unit_of_Work = unit_of_Work;

            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<EmployeeResponse>>> GetEmployeesAsync()
        {
            var result = await _unit_of_Work.EmployeesRepository.GetEntitiesAsync();

            return _mapper.Map<Response<IEnumerable<Employee>>, Response<IEnumerable<EmployeeResponse>>>(result);
        }

        public async Task<Response<EmployeeResponse>> GetEmployeeByIdAsync(Guid Id)
        {
            var result = await _unit_of_Work.EmployeesRepository.GetEntityByIdAsync(Id);

            return _mapper.Map<Response<Employee>, Response<EmployeeResponse>>(result);
        }

        public async Task<Response<IEnumerable<EmployeeResponse>>> InsertEmployeeAsync(EmployeeRequest employee)
        {
            var result = await _unit_of_Work.EmployeesRepository.InsertEntityAsync(_mapper.Map<Employee>(employee));

            _unit_of_Work.Configurations();

            return _mapper.Map<Response<IEnumerable<Employee>>, Response<IEnumerable<EmployeeResponse>>>(result);
        }

        public async Task<Response<IEnumerable<EmployeeResponse>>> UpdateEmployeeAsync(EmployeeUpdateRequest employee)
        {
            var result = await _unit_of_Work.EmployeesRepository.UpdateEntityAsync(_mapper.Map<Employee>(employee));

            _unit_of_Work.Configurations();

            return _mapper.Map<Response<IEnumerable<Employee>>, Response<IEnumerable<EmployeeResponse>>>(result);
        }

        public async Task<Response<IEnumerable<EmployeeResponse>>> DeleteEmployeeAsync(Guid Id)
        {
            var result = await _unit_of_Work.EmployeesRepository.DeleteEntityAsync(Id);

            _unit_of_Work.Configurations();

            return _mapper.Map<Response<IEnumerable<Employee>>, Response<IEnumerable<EmployeeResponse>>>(result);
        }
    }
}
