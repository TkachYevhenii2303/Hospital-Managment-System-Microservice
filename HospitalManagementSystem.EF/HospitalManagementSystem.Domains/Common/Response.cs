using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Domains.Common
{
    public class Response<TData>
    {
        public TData? Data { get; set; }

        public string Message { get; set; } = string.Empty;

        public bool Success { get; set; } = true;
    }
}
