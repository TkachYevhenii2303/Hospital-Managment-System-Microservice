using HospitalManagementSystem.Domains.Common;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Shedules : Entity
    {
        public DateTime TimeStart { get; set; }
        
        public DateTime TimeEnd { get; set; }

        public Guid InDepartmentsId { get; set; }
    }
}
