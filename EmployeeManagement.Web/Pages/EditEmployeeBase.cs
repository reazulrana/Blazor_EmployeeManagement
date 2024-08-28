using EmployeeManagement.Model;
using EmployeeManagement.Web.Services;
using EmployeeManagement.Web.Model;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Web.Model;
using AutoMapper;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {

        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        [Inject]
        public IMapper mapper { get; set; }

        private Employee Employee { get; set; } = new Employee();
        public EditEmployeeModel EditEmployee { get; set; } = new EditEmployeeModel();


        public List<Department> Departments { get; set; } = new List<Department>();
        //public string DepartmentId { get;set; }

        [Parameter]
        public string Id { get; set; }

        protected async override Task OnInitializedAsync()
        {

            Employee = await EmployeeService.GetEmployee(int.Parse(Id));
            Departments = (await DepartmentService.GetDepartments()).ToList();
            //DepartmentId=Employee.DepartmentId.ToString();

            mapper.Map(Employee, EditEmployee);


            //EditEmployee = new EditEmployeeModel()
            //{
            //    DepartmentId = Employee.DepartmentId,
            //    ConfirmEmail = Employee.Email,
            //    DateofBirth = Employee.DateofBirth,
            //    Email = Employee.Email,
            //    EmployeeId = Employee.EmployeeId,
            //    FirstName = Employee.FirstName,
            //    Gender = Employee.Gender,
            //    LastName = Employee.LastName,
            //    PhotoPath = Employee.PhotoPath,


            //};


            //return base.OnInitializedAsync();
        }


        protected void HandleValidSubmit()
        {

        }
    }
}
