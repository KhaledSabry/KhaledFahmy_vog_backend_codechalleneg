using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VogCodeChallenge.API.DAL;
using VogCodeChallenge.API.DAL.Entities;
using VogCodeChallenge.API.Service;
using System.Linq;
using Xunit;

namespace UnitTestProject1.services
{
    public class testEmployeeServices
    {
         ApplicationDbContext _context;

        public testEmployeeServices()
        {
            Company company = new Company() { token = System.Guid.NewGuid(), CompanyName = "Company1" };
            Department department = new Department(){token = System.Guid.NewGuid(),DepartmentName = "Comp1-Department1",Address = "Comp1-Dep1-Address1"};
            List<Employee> employees =new List<Employee>() {
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "FName1",LastName="Name1",JobTitle="Title1",MailingAddress= "Address1",company=company,companyToken=company.token,department=department,departmentToken=department.token },
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "FName2",LastName="Name2",JobTitle="Title2",MailingAddress= "Address2" ,company=company,companyToken=company.token,department=department,departmentToken=department.token },
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "FName3",LastName="Name3",JobTitle="Title3",MailingAddress= "Address3" ,company=company,companyToken=company.token,department=department,departmentToken=department.token }
                    };


            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString());
            this._context = new VogCodeChallenge.API.DAL.ApplicationDbContext(builder.Options);
            this._context.employees.AddRange( // adding test data
                    employees);
            this._context.SaveChanges();


        }
        [Fact]
        public void Employee_GetAll()
        {
            EmployeeService empService = new EmployeeService(this._context);
            IEnumerable<Employee> result = empService.GetAll();

            foreach (var emp in result)
                Console.WriteLine(emp.FirstName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result.ToList().Count, 3);
        }
        [Fact]
        public void Employee_ListAll()
        {
            EmployeeService empService = new EmployeeService(this._context);
            var result = empService.ListAll();
            foreach (var emp in result)
                Console.WriteLine(emp.FirstName);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(result.Count,3);
        }
    }
}
