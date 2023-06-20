using EmployeeManagement.Common.Models.Dto;
using EmployeeManagement.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Repository.Repository
{
    public class EmployeeRepository :IEmployeeRepository
    {
        private readonly EmployeeDbContext _employeeDbContext;
        public EmployeeRepository(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }
        public async Task<ActionResult<EmployeeDetail>> GetEmployeeById(int id)
        {
            var employee = await _employeeDbContext.EmployeeDetails.FindAsync(id);
            return employee;
        }
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetEmployeesList()
        {
            var employee = await _employeeDbContext.EmployeeDetails.ToListAsync();
            return employee;
        }
        public async Task<ActionResult<EmployeeDetail>> CreateEmployee(EmployeeDetail employee)
        {
            _employeeDbContext.EmployeeDetails.Add(employee);
            await _employeeDbContext.SaveChangesAsync();
            return employee;
        }
        public async Task<ActionResult> UpdateEmployee(int id, EmployeeDetail employee)
        {
            _employeeDbContext.Entry(employee).State = EntityState.Modified;
            await _employeeDbContext.SaveChangesAsync();
            return null;
        }
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            
            var emp = await _employeeDbContext.EmployeeDetails.FindAsync(id);
            
            _employeeDbContext.EmployeeDetails.Remove(emp);
            await _employeeDbContext.SaveChangesAsync();
            return null;
        }
    }
}
