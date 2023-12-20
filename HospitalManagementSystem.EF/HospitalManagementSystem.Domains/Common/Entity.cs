using HospitalManagementSystem.Domains.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domains.Common
{
    public class Entity : IEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? UpdatedDateTime { get; set; }

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedDateTime = DateTime.Now;
            UpdatedDateTime = DateTime.Now;
        }
    }
}
