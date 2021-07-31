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
        private readonly IWebHostEnvironment _env;


        public EmployeesController(IEmployeeRepository _employeeRepository , IWebHostEnvironment env)
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
        public async Task<ActionResult<Employee>> CreateEmployee([FromForm] Employee employee )
        {
            try
            {
                
                if(employee == null)
                         return BadRequest();

                if(employee.ImageFile !=null)
                    employee.EmpPhoto = await SaveImage(employee.ImageFile);

                if (   !((employee.EmpPhoto.ToUpper().EndsWith(".PNG")) || (employee.EmpPhoto.ToUpper().EndsWith(".JPG")) || (employee.EmpPhoto.ToUpper().EndsWith(".JPEG"))))
                      return BadRequest("Image Must be .png or .jpg/jpeg");


                var newEmp = await employeeRepository.AddEmployee(employee);
               return CreatedAtAction(nameof(GetEmployeeById), new { id = newEmp.EmpId }, newEmp);
                
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Errorr Creating new Employee record");

            }
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> UpdateEmployee([FromForm] Employee employee , int id)
        {
            try
            {
                if (id != employee.EmpId)
                    return BadRequest("Employee Id Dismatch");

                var employeeToUpdate = await employeeRepository.GetEmployeeById(id);
               

                if (employeeToUpdate == null)
                    return NotFound($"Employee with Id {id} not found");

                if (employee.ImageFile != null)
                {
                    DeletImage(employeeToUpdate.EmpPhoto);
                    employee.EmpPhoto = await SaveImage(employee.ImageFile);
                    employeeToUpdate.EmpPhoto = employee.EmpPhoto;
                }

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

                DeletImage(employeeToDelet.EmpPhoto);

                 await employeeRepository.DeleteEmployee(id);

                return Ok($"Employee with Id {id} Deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Errorr Deleting Employee record");

            }
        }

        [NonAction]
        public async Task<string> SaveImage(IFormFile imageFile)
        {
            string ImageName = new string(Path.GetFileNameWithoutExtension(imageFile.FileName)
                .Take(10).ToArray()).Replace(" ","-");

            ImageName = ImageName + DateTime.Now.ToString("yymmssff")+Path.GetExtension(imageFile.FileName);

            var ImagePath = Path.Combine(_env.ContentRootPath, "Images",ImageName);

            using (var FileStream = new FileStream(ImagePath,FileMode.Create))
            {
                await imageFile.CopyToAsync(FileStream);
            }
            return ImageName;
        }
        [NonAction]
        public void DeletImage(string ImageName)
        {
            var ImagePath = Path.Combine(_env.ContentRootPath, "Images", ImageName);
            if(System.IO.File.Exists(ImagePath))
            {
                System.IO.File.Delete(ImagePath);
            }
        }
    }
}
