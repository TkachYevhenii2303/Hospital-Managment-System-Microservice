using Hospital_Management_System_Applications.Common.Mapping.Interfaces;
using HospitalManagementSystem.Domains.Entities;
using System.Text.Json.Serialization;
using AutoMapper;

namespace Hospital_Management_System_Applications.Features.Employee.Queries.Return_all_Employee
{
    public class GETPatientsDTO : IMappingFrom<Patient>
    {
        [JsonPropertyName("Patient's ID:")]
        public Guid ID { get; set; } 

        [JsonPropertyName("Patient's title:")]
        public string FullName { get; set; } = string.Empty;

        [JsonPropertyName("Email:")]
        public string Email { get; set; } = string.Empty;

        [JsonPropertyName("Locale mobile:")]
        public string Mobile { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Patient, GETPatientsDTO>()
                .ForMember(destination => destination.FullName, 
                options => options.MapFrom(source => $"{source.FirstName} {source.LastName}"));
        }
    }
}
