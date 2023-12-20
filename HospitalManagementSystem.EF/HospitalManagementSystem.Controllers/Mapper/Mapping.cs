using AutoMapper;
using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.DTOs.DTOs.Responses.Patients;
using HospitalManagementSystem.Entities;

namespace HospitalManagementSystem.Controllers.Mapper
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            EmployeeConfigurationsMapping();
            ResponseConfigurationsMapping();
        }

        private void EmployeeConfigurationsMapping()
            => CreateMap<Patient, PatientResponse>()
                .ForMember(dest => dest.FullName, options => options.MapFrom(source => $"{source.FirstName} {source.LastName}"));

        private void ResponseConfigurationsMapping()
            => CreateMap(typeof(Response<>), typeof(Response<>));
    }
}
