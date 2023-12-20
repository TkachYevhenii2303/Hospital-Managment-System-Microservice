using System.Text.Json.Serialization;

namespace HospitalManagementSystem.DTOs.DTOs.Requests.Employee
{
    public class EmployeeUpdateRequest
    {
        [JsonPropertyName("ID:")]
        public Guid Id { get; set; }

        [JsonPropertyName("Employee's title 1:")]
        public string FistName { get; set; } = string.Empty;

        [JsonPropertyName("Employee's title 2:")]
        public string LastName { get; set; } = string.Empty;

        [JsonPropertyName("Password:")]
        public string Password { get; set; } = string.Empty;

        [JsonPropertyName("Email:")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Mobile:")]
        public string Mobile { get; set; } = string.Empty;
    }
}
