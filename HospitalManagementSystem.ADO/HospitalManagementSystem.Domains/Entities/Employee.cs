﻿using HospitalManagementSystem.Domains.Common;

namespace HospitalManagementSystem.Entities
{
    public class Employee : Entity
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        
        public string Password { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Mobile { get; set; } = string.Empty;

        public bool ActiveIs { get; set; } = true;
    }
}
