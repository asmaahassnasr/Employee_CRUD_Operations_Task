using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_APIs.Models.Repositories;
using CRUD_APIs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CRUD_APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        private readonly IHostingEnvironment _env;


        public EmployeesController(IEmployeeRepository _employeeRepository , IHostingEnvironment env)
        {
            employeeRepository = _employeeRepository;
            _env = env;
        }

        [HttpGet]
        public async Task<ActionResult> GetEmployees()
        {
            try
            {
                // Ok : status code => 200 
                return Ok(await employeeRepository.GetEmployees());

            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the server");
            }
        }
    
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var result =await employeeRepository.GetEmployeeById(id);
                if(result == null)
                {
                    return NotFound();
                }
                return result;

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error Retreiving data from the server");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee(Employee employee )
        {
            try
            {
                
                if(employee == null)
                         return BadRequest();
                //if(employee.EmpPhoto != null)
                //{
                    //Checks for Image exctension
                    //if (!(employee.EmpPhoto.EndsWith(".png") || employee.EmpPhoto.EndsWith(".jpg") || employee.EmpPhoto.EndsWith(".jpeg")))
                    //    return BadRequest("Image limit to png and jpeg/jpg ");

                    ////Creat image ptah to upload photo in wwwroot/images
                    //string pathImg = Path.Combine(_env.WebRootPath, "images");
                    //string fullPath = Path.Combine(pathImg,employee.EmpPhoto);
                    //f.CopyTo(new FileStream(fullPath, FileMode.Append));
               // }

                var newEmp = await employeeRepository.AddEmployee(employee);
               return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmp.EmpId }, newEmp);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Errorr Creating new Employee record");

            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee(int id,Employee employee)
        {
            try
            {
                if (id != employee.EmpId)
                    return BadRequest("Employee Id Dismatch");

                var employeeToUpdate = await employeeRepository.GetEmployeeById(id);
                if (employeeToUpdate == null)
                    return NotFound($"Employee with Id {id} not found");


                return await employeeRepository.UpdateEmployee(employee);

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Errorr Updating Employee record");

            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelet = await employeeRepository.GetEmployeeById(id);
                if (employeeToDelet == null)
                    return NotFound($"Employee with Id {id} not found");


                 await employeeRepository.DeleteEmployee(id);
                return Ok($"Employee with Id {id} Deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Errorr Deleting Employee record");

            }
        }
    }
}
