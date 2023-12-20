using System.Text.Json;

namespace Hospital_Management_System_Applications.Exceptions.Handling
{
    public class Error
    {
        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; }

        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
