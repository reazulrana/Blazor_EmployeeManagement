using EmployeeManagement.Model;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase:ComponentBase
    {

        public IEnumerable<Employee> Employees { get; set; }


        protected override async Task OnInitializedAsync()
        {

            await Task.Run(LoadEmployees);
            



        }

        private void LoadEmployees()
        {
            Task.Delay(3000).Wait();

            Employees = new List<Employee>()
            {
                new Employee()
                {
                      FirstName="first name 1",
                       LastName="last name 1",
                        DateofBirth=System.DateTime.Now,
                         Email="first1@gmail.com",
                          Gender=Gender.Male,
                           PhotoPath="Images/img10.jpg",
                           DepartmentId=1,
                },

                new Employee()
                {
                      FirstName="first name 2",
                       LastName="last name 2",
                        DateofBirth=System.DateTime.Now,
                         Email="first2@gmail.com",
                          Gender=Gender.Male,
                           PhotoPath="Images/img11.jpg",
                           DepartmentId=1,
                },
                        new Employee()
                {
                      FirstName="first name 3",
                       LastName="last name 3",
                        DateofBirth=System.DateTime.Now,
                         Email="first3@gmail.com",
                          Gender=Gender.Male,
                           PhotoPath="Images/img12.jpg",
                           DepartmentId=1,
                },
                                     new Employee()
                {
                      FirstName="first name 4",
                       LastName="last name 4",
                        DateofBirth=System.DateTime.Now,
                         Email="first4@gmail.com",
                          Gender=Gender.Male,
                           PhotoPath="Images/img9.jpg",
                           DepartmentId=1,
                },


            };

        }
    }
}
