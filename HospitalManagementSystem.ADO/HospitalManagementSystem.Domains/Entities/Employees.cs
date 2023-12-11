using HospitalManagementSystem.Domains.Common;

namespace Dapper_Data_Access_Layer.Entities
{
    public class Employees : Entity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        
        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public bool ActiveIs { get; set; } = true;
    }
}
