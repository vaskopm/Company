using CompanyBackOffice.Models;
using CompanyBackOffice.Repositories;
using CompanyBackOffice.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CompanyBackOffice.Controllers
{
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

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost]
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

        [HttpDelete("{id}")]
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