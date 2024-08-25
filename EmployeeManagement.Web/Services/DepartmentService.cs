using EmployeeManagement.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly HttpClient httpClient;

        public DepartmentService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }
        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await httpClient.GetFromJsonAsync<Department[]>($"api/departments");
                 
        
        }

        public async Task<Department> GetDepartment(int id)
        {
            return await httpClient.GetFromJsonAsync<Department>($"api/departments/{id}");
        }
    }
}
