using System.Text.Json;

namespace HospitalManagementSystem.Controllers.Middleware.Handling
{
    public class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
