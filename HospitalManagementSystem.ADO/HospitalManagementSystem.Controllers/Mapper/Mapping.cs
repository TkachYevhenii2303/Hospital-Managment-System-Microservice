using AutoMapper;
using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.Domains.Generics.Interfaces;
using HospitalManagementSystem.DTOs.DTOs.Requests.Employee;
using HospitalManagementSystem.DTOs.DTOs.Responses.Employee;
using HospitalManagementSystem.Entities;

namespace HospitalManagementSystem.Mapping
{
    public class Mapping : Profile
    {
        private readonly IUnit_of_Work _unit_of_Work;

        public Mapping(IUnit_of_Work unit_of_Work)
        {
            _unit_of_Work = unit_of_Work;

            EmployeesConfigurationsMapping();
            ResponseConfigurationsMapping();
        }

        private void EmployeesConfigurationsMapping()
        {
            CreateMap<Employees, GETEmployee>().ReverseMap();
            CreateMap<INSERTEmployee, Employees>();
        }

        private void ResponseConfigurationsMapping()
            => CreateMap(typeof(Response<>), typeof(Response<>));
    }
}
