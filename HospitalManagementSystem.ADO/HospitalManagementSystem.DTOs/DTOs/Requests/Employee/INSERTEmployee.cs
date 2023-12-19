namespace HospitalManagementSystem.DTOs.DTOs.Requests.Employee
{
    public class INSERTEmployee
    {
        public Guid Id { get; set; }

        public string FistName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;
    }
}
