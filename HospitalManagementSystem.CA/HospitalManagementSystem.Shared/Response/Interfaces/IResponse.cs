using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Shared.Response.Interfaces
{
    public interface IResponse<TData>
    {
        TData? Data { get; set; }

        string Message { get; set; }

        bool Succeeded { get; set; }

        int StatusCode { get; set; }
    }
}
