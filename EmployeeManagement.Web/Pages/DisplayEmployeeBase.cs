using EmployeeManagement.Model;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class DisplayEmployeeBase:ComponentBase
    {

        [Parameter]
        public Employee Employee { get; set; }
        [Parameter]
        public bool ShowFooter { get; set; }
        [Parameter]
        public EventCallback<bool> OnEmployeeSelection { get; set; }

        public async Task CheckBoxChanged(ChangeEventArgs e)
        {
            await OnEmployeeSelection.InvokeAsync((bool)e.Value);
        }


        [Parameter]
        public EventCallback<string> TextChanged { get; set; }
        public async Task TextChaned(ChangeEventArgs e)
        {

            await TextChanged.InvokeAsync((string)e.Value);

        }

    }
}
