using System.Text.Json.Serialization;

namespace HospitalManagementSystem.DTOs.DTOs.Responses.Employee
{
    [Serializable]
    public class EmployeeResponse
    {
        [JsonPropertyName("ID:")]
        public Guid Id { get; set; }

        [JsonPropertyName("Employee's title:")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("Email:")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Mobile:")]
        public string Mobile { get; set; } = string.Empty;
    }
}
