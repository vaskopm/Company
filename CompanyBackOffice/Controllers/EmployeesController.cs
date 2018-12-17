using CompanyBackOffice.Models;
using CompanyBackOffice.Repositories;
using CompanyBackOffice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CompanyBackOffice.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        internal readonly EmployeeRepository _employeeRepository;
        internal readonly CompanyDbContext db;

        public EmployeesController(CompanyDbContext context)
        {
            db = context;
            _employeeRepository = new EmployeeRepository(db);
        }

        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns>A list of employees</returns>
        /// <response code="200">If returns a list of employees</response>
        /// <response code="500">If there was an error</response>
        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<EmployeeVM>> Get()
        {
            try
            {
                var employees = _employeeRepository.GetEmployees();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
                  
        }

        /// <summary>
        /// Get an employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>A specific employee</returns>
        /// <response code="400">If id is null</response>
        /// <response code="200">If returns an employee</response>
        /// <response code="500">If there was an error</response>
        [HttpGet("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<EmployeeVM> Get(Guid id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            try
            {
                var employee = _employeeRepository.GetEmployee(id);

                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Add a new employee
        /// </summary>
        /// <param name="vm">Data model (CreateEmployeeVM)</param>
        /// <returns>Http status code</returns>
        /// <response code="400">If model is not valid</response>
        /// <response code="200">If a new employee was created</response>
        /// <response code="500">If there was an error</response>
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Post([FromBody] CreateEmployeeVM vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                _employeeRepository.CreateEmployee(vm);

                return Ok(new { vm.Name });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Removes a specific employee
        /// </summary>
        /// <param name="id">Employee id</param>
        /// <returns>Http status code</returns>
        /// <response code="400">If id is null</response>
        /// <response code="200">If an employee was removed</response>
        /// <response code="500">If there was an error</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public IActionResult Delete(Guid id)
        {
            if(id == null)
            {
                return BadRequest();
            }

            try
            {
                _employeeRepository.RemoveEmployee(id);

                return Ok(new { message = "Employee removed successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}