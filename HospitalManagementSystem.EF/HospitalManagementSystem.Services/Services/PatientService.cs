using AutoMapper;
using HospitalManagementSystem.Domains.Generics.Interfaces;
using HospitalManagementSystem.Services.Services.Interfaces;

namespace HospitalManagementSystem.Services.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnit_of_Work _unit_of_Work;

        private readonly IMapper _mapper;

        public PatientService(IUnit_of_Work unit_of_Work, IMapper mapper)
        {
            _unit_of_Work = unit_of_Work;

            _mapper = mapper;
        }
    }
}
