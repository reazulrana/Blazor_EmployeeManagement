using EmployeeManagement.Api.Model;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controller
{

    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController:ControllerBase
    {
        private readonly IDepartmentRepository departmentRepository;

        public DepartmentsController(IDepartmentRepository departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }


        [HttpGet]
        public async Task<ActionResult> GetDepartments()
        {


            try
            {
                return Ok(await departmentRepository.GetDepartments());

            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error On Data Retrieve");
            }
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Department>> GetDepartment(int id)
        {

            try
            {
            var result = await departmentRepository.GetDepartment(id);
                if (result == null)
                {
                    return NotFound();

                }
                else
                {

                return result;
                }

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error On Data Retrieve");
            }
        }

    }
}
