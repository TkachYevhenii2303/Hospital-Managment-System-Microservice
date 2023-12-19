using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.DTOs.DTOs.Responses.Employee;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers.Controllers
{
    [Route("employee")]
    public class EmployeeController : ApplicationController
    {
        private readonly IEmployeesService _employeesService;

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IEmployeesService employeesService, ILogger<EmployeeController> logger)
        {
            _employeesService = employeesService;

            _logger = logger;
        }

        /// <summary>
        /// Retrieves a list of employees from the database.
        /// </summary>
        /// <returns>An ActionResult containing a Response object with a list of GETEmployee objects.</returns>
        /// <remarks>
        /// This method fetches all employees from the database and returns them in a list.
        /// Successful responses will have a status code of 200 (OK).
        /// </remarks>
        /// <response code="200">Returns a list of GETEmployee objects.</response>
        [HttpGet("get-all")]
        public async Task<ActionResult<Response<IEnumerable<GETEmployee>>>> GetEmployeesAsync()
        {
            var result = await _employeesService.GetEmployeesAsync();

            _logger.LogInformation($"Successfully read data from the database: \nMethod: {this.GetType().FullName}" +
                $"\nResult: {result.Data}" +
                $"\nTime: {DateTime.UtcNow.ToLocalTime()}");

            return Ok(result);
        }
        [HttpGet("get-by-role")]
        public async Task<ActionResult<Response<IEnumerable<GETEmployee>>>> GetEmployeesByRoleAsync(string role)
        {
            var result = await _employeesService.GetEmployeesByRoleAsync(role);

            _logger.LogInformation($"Successfully read data from the database: \nMethod: {this.GetType().FullName}" +
                $"\nResult: {result.Data}" +
                $"\nTime: {DateTime.UtcNow.ToLocalTime()}");

            return Ok(result);
        }

    }
}
