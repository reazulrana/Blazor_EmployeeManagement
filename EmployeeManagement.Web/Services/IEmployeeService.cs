﻿using EmployeeManagement.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {

        Task<List<Employee>> GetEmployees();
    }
}
