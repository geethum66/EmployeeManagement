using System;
using System.Collections.Generic;

namespace EmployeeManagement.EmployeeManagement.Common.Models.Dto;

public partial class EmployeeDetail
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public int? DepartmentId { get; set; }
}
