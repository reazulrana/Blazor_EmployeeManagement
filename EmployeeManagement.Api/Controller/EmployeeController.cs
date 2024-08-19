using EmployeeManagement.Api.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Controller
{



    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController:ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            this.employeeRepository = _employeeRepository;
        }



        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            try
            {
            return Ok(await  employeeRepository.GetEmployees());

            }
            catch (Exception)
            {

              return  StatusCode(StatusCodes.Status500InternalServerError
                    , "Error Retrieving Data From Database");
                
                
            }
            
        }


    }
}
