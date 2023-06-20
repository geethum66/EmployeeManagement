using EmployeeManagement.Common.Models.Dto;
using EmployeeManagement.Repository.Interfaces;
using EmployeeManagement.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Services
{
    public class EmployeeServices : IEmployeeServices
    {
        private readonly IEmployeeRepository _employeeRepository ;

        public EmployeeServices(IEmployeeRepository employeeRepository)
        {
          _employeeRepository = employeeRepository;
        }

        public async Task<ActionResult<EmployeeDetail>> GetEmployeeById(int id)
        {
            if(id < 0)
                throw new Exception("Employee Id cannot be less than zero");

            return await _employeeRepository.GetEmployeeById(id);
        }
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetEmployeesList()
        {
            return  await _employeeRepository.GetEmployeesList();
           
        }
        public async Task<ActionResult<EmployeeDetail>> CreateEmployee(EmployeeDetail employee)
        {
            if (string.IsNullOrEmpty(employee.FirstName))
                throw new Exception("Employee First Name is empty!");
            if (string.IsNullOrEmpty(employee.Email))
                throw new Exception("Employee Email is empty!");

            return await _employeeRepository.CreateEmployee(employee);
        }
        public async Task<ActionResult> UpdateEmployee(int id, EmployeeDetail employee)
        {
            if (id < 0)
                throw new Exception("Employee Id cannot be less than zero");
            if (string.IsNullOrEmpty(employee.FirstName))
                throw new Exception("Employee First Name is empty!");
            if (string.IsNullOrEmpty(employee.Email))
                throw new Exception("Employee Email is empty!");
            var emp = await _employeeRepository.GetEmployeeById(id);
            if (emp == null)
                throw new Exception("Employee not found");

            return await _employeeRepository.UpdateEmployee(id, employee);
        }
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            if (id < 0)
                throw new Exception("Employee Id cannot be less than zero");
            var emp = await _employeeRepository.GetEmployeeById(id);
            if (emp == null)
                throw new Exception("Employee not found");
            return (ActionResult)await _employeeRepository.DeleteEmployee(id);
        }
    }

}