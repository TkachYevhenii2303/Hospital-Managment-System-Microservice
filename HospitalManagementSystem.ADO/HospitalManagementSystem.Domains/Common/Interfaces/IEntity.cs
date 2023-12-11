using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domains.Common.Interfaces
{
    public interface IEntity
    {
        Guid Id { get; set; }

        DateTime CreatedDateTime { get; set; }

        DateTime? UpdatedDateTime { get; set; }
    }
}
