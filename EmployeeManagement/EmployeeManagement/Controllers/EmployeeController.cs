using EmployeeManagement.Common.Models.Dto;
using EmployeeManagement.Services;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

namespace EmployeeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly EmployeeDbContext _employeeDbContext;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IEmployeeServices _employeeServices ;
        public EmployeeController(ILogger<EmployeeController> logger, EmployeeDbContext employeeDbContext, IEmployeeServices employeeServices )
        {
            _logger = logger;
            _employeeDbContext = employeeDbContext;
            _employeeServices = employeeServices;
        }
        
        [HttpGet, Route("{id:int}")]
        public async Task<ActionResult<EmployeeDetail>> GetEmployeeById(int id)
        {
            _logger.LogInformation("get employee by ID");
            
            var employee = await _employeeServices.GetEmployeeById(id);
            return employee;

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetEmployeesList()
        {
            _logger.LogInformation("get employee all employees");
            
            return await _employeeServices.GetEmployeesList();


        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDetail>> CreateEmployee(EmployeeDetail employee)
        {
            _logger.LogInformation("add employees"); 
            try 
            { 

            return await _employeeServices.CreateEmployee(employee);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }  
        [HttpPut]
        public async Task<ActionResult> UpdateEmployee(int id, EmployeeDetail employee)
        {
            _logger.LogInformation("update employee");
           
             try
            {
                await _employeeServices.UpdateEmployee(id,employee);
            }
            catch(Exception ex)
            {
                throw (ex);
            }
            return Ok();

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            _logger.LogInformation("delete employee by ID");
            try
            {
                await _employeeServices.DeleteEmployee(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return Ok();
        }           
        
    }
}

