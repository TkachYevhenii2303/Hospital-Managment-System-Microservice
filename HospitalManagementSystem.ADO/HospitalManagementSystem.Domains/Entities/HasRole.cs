using HospitalManagementSystem.Domains.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dapper_Data_Access_Layer.Entities
{
    public class HasRole : Entity
    {
        public Guid EmployeesId { get; set; }

        public Guid RolesId { get; set; }
    }
}
