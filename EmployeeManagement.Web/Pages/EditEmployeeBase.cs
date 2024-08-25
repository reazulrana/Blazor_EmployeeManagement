using EmployeeManagement.Model;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase:ComponentBase
    {

        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public Employee Employee { get; set; }=new Employee();

        [Parameter]
        public string Id { get; set; }

        protected async override  Task OnInitializedAsync()
        {

            Employee=await EmployeeService.GetEmployee(int.Parse(Id));

            //return base.OnInitializedAsync();
        }
    }
}
