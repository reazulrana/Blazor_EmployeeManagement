using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Pages
{
    public class DatabindingDemoBase:ComponentBase
    {
        public string Name { get; set; } = "Tom";
        public string Gender { get; set; } = "Male";
        public string bgcolor { get; set; } = "background-color:white";


    }
}
