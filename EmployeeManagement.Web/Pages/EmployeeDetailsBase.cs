using EmployeeManagement.Api.Model;
using EmployeeManagement.Model;
using EmployeeManagement.Web.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeDetailsBase:ComponentBase
    {

        [Inject]
        public IEmployeeService employeeRepository { get;set; }
        public Employee Employee { get;set; }= new Employee();
        protected string Cordinate { get;set; }

        [Parameter]
        public string Id { get; set; }


       

        protected override async Task OnInitializedAsync()
        {
            Employee=await employeeRepository.GetEmployee(int.Parse(Id));

        }

        protected void mouse_move(MouseEventArgs e)
        {
            Cordinate = $"X={e.ClientX} Y={e.ClientY}";
        }

    }
}
