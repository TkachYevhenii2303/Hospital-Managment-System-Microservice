using HospitalManagementSystem.Domains.Common;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Hospital : Entity
    {
        public string Title { get; set; } = string.Empty;
        
        public string Address { get; set; } = string.Empty;
        
        public string Details { get; set; } = string.Empty; 
    }
}
