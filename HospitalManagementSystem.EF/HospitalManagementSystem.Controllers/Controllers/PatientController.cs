using HospitalManagementSystem.Services.Services.Interfaces;

namespace HospitalManagementSystem.Controllers.Controllers
{
    public class PatientController : ApplicationController
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
    }
}
