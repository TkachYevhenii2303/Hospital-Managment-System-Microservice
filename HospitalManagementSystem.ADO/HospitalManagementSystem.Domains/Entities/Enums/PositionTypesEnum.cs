using System.Text.Json.Serialization;

namespace HospitalManagementSystem.Domains.Entities.Structures
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PositionTypesEnum
    {
        Obstetrician = 0,

        Cardiologist = 1,

        Pharmacist = 2,

        Dermatologist = 3,

        Psychiatrist = 4,

        Surgeon = 5,
    }
}
