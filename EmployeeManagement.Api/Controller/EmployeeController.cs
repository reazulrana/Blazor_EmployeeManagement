using EmployeeManagement.Api.Model;
using EmployeeManagement.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                
                var result= await employeeRepository.GetEmployee(id);
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

                return StatusCode(StatusCodes.Status500InternalServerError
                      , "Error Retrieving Data From Database");


            }

        }









        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {

                if (employee == null)
                {
                    return BadRequest();

                }
                else
                {

                    var emp = employeeRepository.GetEmployeeByEmail(employee.Email);

                    if(emp == null)
                    {

                        ModelState.AddModelError("email", "Email Is Exist in");
                        return BadRequest(ModelState);
                           
                    }

                    var result = await employeeRepository.AddEmployee(employee);

                    return CreatedAtAction(nameof(GetEmployee), new {id=result.EmployeeId } ,result);
                }



            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError
                      , "Error Retrieving Data From Database");


            }

        }



        [HttpGet]
        public async Task<ActionResult<Employee>> GetEmployeeByEmail(string email)
        {

            return await employeeRepository.GetEmployeeByEmail(email);


        }


    }
}
