using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_APIs.Models.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private AppDbContext appDbContext;

        public EmployeeRepository(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task DeleteEmployee(int id)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmpId == id);
            if(result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await appDbContext.Employees.Include(e => e.Country).FirstOrDefaultAsync(e => e.EmpId == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await appDbContext.Employees.ToListAsync();   
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.FirstOrDefaultAsync(e => e.EmpId == employee.EmpId);
            if(result != null)
            {
                result.CountryId = employee.CountryId;
                result.EmpBirthDate = employee.EmpBirthDate;
                result.EmpEmail = employee.EmpEmail;
                result.EmpName = employee.EmpName;
                result.EmpPhoto = employee.EmpPhoto;
                result.EmpSalary = employee.EmpSalary;
                result.EmpTitle = employee.EmpTitle;

                await appDbContext.SaveChangesAsync();
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
