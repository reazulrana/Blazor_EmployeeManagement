using EmployeeManagement.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Model
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
           var result= await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;

        }

        public async Task<Employee> DeleteEmployee(int employeeId)
        {

            var result = await appDbContext.Employees.FirstOrDefaultAsync(x=>x.EmployeeId==employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
               await appDbContext.SaveChangesAsync();
                return result;
            }
            return null;

        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
           return await appDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employeeId);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await appDbContext.Employees.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {

            return await appDbContext.Employees.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> Search(string name, Gender? gender)
        {
            IQueryable<Employee> query = appDbContext.Employees;

            if (!string.IsNullOrEmpty(name))
            {

                query = query.Where(x => x.FirstName.ToLower().Contains(name)
                ||
                x.LastName.ToLower().Contains(name));
            }

            if (gender != null) 
            {
                query = query.Where(x => x.Gender == gender);
    
            }


            return await query.ToListAsync();


        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(x => x.EmployeeId == employee.EmployeeId);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.DateofBirth = employee.DateofBirth;
                result.Gender = employee.Gender;
                result.Email = employee.Email;
                result.DepartmentId = employee.DepartmentId;
                result.PhotoPath = employee.PhotoPath;

                await appDbContext.SaveChangesAsync();
            }

            return null;

                 
        }
    }
}
