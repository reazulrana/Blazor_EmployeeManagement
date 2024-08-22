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

              return  StatusCode(StatusCodes.Status500InternalServerError, "Error Retrieving Data From Database");
                
                
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

                    if(emp != null)
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



        //[HttpGet]
        //public async Task<ActionResult<Employee>> GetEmployeeByEmail(string email)
        //{

        //    return await employeeRepository.GetEmployeeByEmail(email);


        //}



        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id, Employee emp)
        {

            try
            {

            
            if(id != emp.EmployeeId)
            {
                return BadRequest("Employee id Not Matched");
            }

            var employeeupdate=employeeRepository.GetEmployee(id);
            if(employeeupdate == null)
            {
                return NotFound($"Employee id {id} Not Found");
            }

            return await employeeRepository.UpdateEmployee(emp);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,"Error Update Data");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id) 
        {

            try
            {
                var deleteemployee = employeeRepository.GetEmployee(id);
                if(deleteemployee == null)
                {
                    return NotFound($"Employee Id {id} Not Found");
                }

                return await employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Deleting Data");

            }


        }


        [HttpGet("{search}")]
        public async Task<ActionResult<Employee>> Search(string name, Gender? gender)
        {

            try
            {
                var result = await employeeRepository.Search(name, gender);
                if (result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Search Data");
            }


        }
    }
}
