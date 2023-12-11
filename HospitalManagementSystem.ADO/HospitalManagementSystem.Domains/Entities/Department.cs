using HospitalManagementSystem.Domains.Common;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Department : Entity
    {
        public string Title { get; set; } = string.Empty;
       
        public Guid HospitalId { get; set; }
    }
}
