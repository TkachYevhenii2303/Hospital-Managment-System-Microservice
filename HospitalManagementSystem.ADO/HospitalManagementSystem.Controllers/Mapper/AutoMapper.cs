using AutoMapper;
using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.DTOs.DTOs.Requests.Employee;
using HospitalManagementSystem.DTOs.DTOs.Responses.Employee;
using HospitalManagementSystem.Entities;

namespace HospitalManagementSystem.Mapping
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            EmployeesConfigurationsMapping();
            ResponseConfigurationsMapping();
        }

        private void EmployeesConfigurationsMapping()
        {
            CreateMap<Employee, EmployeeResponse>()
                .ForMember(destination => destination.FullName, option => option.MapFrom(source => $"{source.FirstName} {source.LastName}"))
                .ReverseMap();
            
            CreateMap<EmployeeRequest, Employee>();

            CreateMap<EmployeeUpdateRequest,  Employee>();

            CreateMap<EmployeeUpdateRequest, EmployeeResponse>()
                .ReverseMap();
        }

        private void ResponseConfigurationsMapping()
            => CreateMap(typeof(Response<>), typeof(Response<>));
    }
}
