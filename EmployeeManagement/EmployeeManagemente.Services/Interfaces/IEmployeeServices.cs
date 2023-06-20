using EmployeeManagement.Common.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Services.Interfaces
{
    public interface IEmployeeServices
    {
        Task<ActionResult<EmployeeDetail>> GetEmployeeById(int id);
        Task<ActionResult<IEnumerable<EmployeeDetail>>> GetEmployeesList();
        Task<ActionResult<EmployeeDetail>> CreateEmployee(EmployeeDetail employee);
        Task<ActionResult> UpdateEmployee(int id, EmployeeDetail employee);
        Task<ActionResult> DeleteEmployee(int id);


    }
}
