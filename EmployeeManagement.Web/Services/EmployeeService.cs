using EmployeeManagement.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient) 
        {
            this.httpClient = httpClient;
        }

        public async Task<Employee> GetEmployee(int id)
        {
            string url = $"api/employee/{id}";
            var e = await httpClient.GetFromJsonAsync<Employee>(url);
            return e;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            return await httpClient.GetFromJsonAsync<List<Employee>>("api/employee");
        }
    }
}
