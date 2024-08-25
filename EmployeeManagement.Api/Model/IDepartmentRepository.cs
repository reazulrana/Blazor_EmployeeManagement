using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Model
{
   public interface IDepartmentRepository
    {
      Task<IEnumerable<Department>> GetDepartments();
        Task<Department> GetDepartment(int id);


    }
}
