using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using CRUD_APIs.Models;
using CRUD_APIs.Models.Repositories;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace CRUD_UnitTest
{
    [TestClass]
    class EmployeeTest
    {
        AppDbContext dbContext;
        EmployeeRepository employeeRepository;
        [SetUp]
        public void SetUp()
        {
            employeeRepository = new EmployeeRepository(dbContext);
        }

        [TestMethod]
        public async void GetEmployeeById_Works()
        {
            //Arrange
            Employee employee = new Employee() {
                 EmpName="Tested Emp", EmpTitle="title test" , EmpEmail="test@gmail.com"};

            //Act
            await employeeRepository.AddEmployee(employee);
            Employee expected = await employeeRepository.GetEmployeeById(employee.EmpId);
            //Assert
            NUnit.Framework.Assert.That(expected, Is.EqualTo(employee));
        }
    }
}
