using HospitalManagementSystem.Domains.Common;
using HospitalManagementSystem.DTOs.DTOs.Requests.Employee;
using HospitalManagementSystem.DTOs.DTOs.Responses.Employee;
using HospitalManagementSystem.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.Controllers.Controllers
{
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
        /// <returns>An ActionResult containing a Response object with a list of EmployeeResponse objects.</returns>
        /// <remarks>
        /// This method fetches all employees from the database and returns them in a list.
        /// Successful responses will have a status code of 200 (OK).
        /// </remarks>
        /// <response code="200">Returns a list of EmployeeResponse objects.</response>
        [HttpGet("Return-Employee")]
        public async Task<ActionResult<Response<IEnumerable<EmployeeResponse>>>> GetEmployeesAsync()
        {
            var employee = await _employeesService.GetEmployeesAsync();

            return Ok(employee);
        }


        /// <summary>
        /// Retrieves an employee by their unique identifier asynchronously.
        /// </summary>
        /// <param name="Id">The unique identifier of the employee.</param>
        /// <returns>
        /// A <see cref="Task{ActionResult{Response{EmployeeResponse}}}"/> representing the asynchronous operation.
        /// The result contains information about the employee.
        /// </returns>
        /// <remarks>
        /// This endpoint is accessible via HTTP GET request at the route "Return-Employee-ID".
        /// </remarks>
        [HttpGet("Return-Employee-ID")]
        public async Task<ActionResult<Response<EmployeeResponse>>> GetEmployeeByIdAsync(Guid Id)
        {
            var employee = await _employeesService.GetEmployeeByIdAsync(Id);

            return Ok(employee);
        }

        /// <summary>
        /// Inserts a new employee asynchronously.
        /// </summary>
        /// <param name="employee">The employee details to be inserted.</param>
        /// <returns>
        /// A <see cref="Task{ActionResult{Response{EmployeeResponse}}}"/> representing the asynchronous operation.
        /// The result contains information about the inserted employee.
        /// </returns>
        /// <remarks>
        /// This endpoint is accessible via HTTP POST request at the route "Insert-Employee".
        /// </remarks>
        [HttpPost("Insert-Employee")]
        public async Task<ActionResult<Response<EmployeeResponse>>> InsertEmployeeAsync(EmployeeRequest employee)
        {
            var employees = await _employeesService.InsertEmployeeAsync(employee);

            return Ok(employees);
        }

        /// <summary>
        /// Deletes an employee by their unique identifier asynchronously.
        /// </summary>
        /// <param name="Id">The unique identifier of the employee to be deleted.</param>
        /// <returns>
        /// A <see cref="Task{ActionResult{IEnumerable{EmployeeResponse}}}"/> representing the asynchronous operation.
        /// The result contains information about the deleted employee.
        /// </returns>
        /// <remarks>
        /// This endpoint is accessible via HTTP DELETE request at the route "Delete-Employee-ID".
        /// </remarks>
        [HttpDelete("Delete-Employee-ID")]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> DeleteEmployeeAsync(Guid Id)
        {
            var employee = await _employeesService.DeleteEmployeeAsync(Id);

            return Ok(employee);
        }

        /// <summary>
        /// Updates an existing employee asynchronously.
        /// </summary>
        /// <param name="employee">The updated employee details.</param>
        /// <returns>
        /// A <see cref="Task{ActionResult{IEnumerable{EmployeeResponse}}}"/> representing the asynchronous operation.
        /// The result contains information about the updated employee.
        /// </returns>
        /// <remarks>
        /// This endpoint is accessible via HTTP PUT request at the route "Update-Employee".
        /// </remarks>
        [HttpPut("Update-Employee")]
        public async Task<ActionResult<IEnumerable<EmployeeResponse>>> UpdateEmployeeAsync(EmployeeUpdateRequest employee)
        {
            var employees = await _employeesService.UpdateEmployeeAsync(employee);

            return Ok(employees);
        }
    }
}
