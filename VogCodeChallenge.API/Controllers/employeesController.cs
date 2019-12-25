using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VogCodeChallenge.API.DAL;
using VogCodeChallenge.API.DAL.Entities;
using VogCodeChallenge.API.Service;

namespace VogCodeChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class employeesController : Controller
    {
        private ApplicationDbContext _context;
        public employeesController()
        {
            Company company1 = new Company() { token = System.Guid.NewGuid(), CompanyName = "Company1" };
            Department department1 = new Department() { token = Guid.Parse("75520E56-3033-444D-9214-B614CD1987DB"), DepartmentName = "Comp1-Department1", Address = "Comp1-Dep1-Address1",company=company1,companyToken=company1.token };
            Department department2= new Department() { token = Guid.Parse("B1E6B562-1B4B-41DD-AAE8-FF740394E3BF"), DepartmentName = "Comp1-Department2", Address = "Comp1-Dep2-Address2", company = company1, companyToken = company1.token };
            List<Employee> employees = new List<Employee>() {
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "FName1",LastName="Name1",JobTitle="Title1",MailingAddress= "Address1",company=company1,companyToken=company1.token,department=department1,departmentToken=department1.token },
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "FName2",LastName="Name2",JobTitle="Title2",MailingAddress= "Address2" ,company=company1,companyToken=company1.token,department=department1,departmentToken=department1.token },
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "FName3",LastName="Name3",JobTitle="Title3",MailingAddress= "Address3" ,company=company1,companyToken=company1.token,department=department1,departmentToken=department1.token },

                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "FName1 -department2",LastName="Name1 -department2",JobTitle="Title1-department2",MailingAddress= "Address1",company=company1,companyToken=company1.token,department=department2,departmentToken=department2.token },
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "FName2 -department2",LastName="Name2 -department2",JobTitle="Title2-department2",MailingAddress= "Address2" ,company=company1,companyToken=company1.token,department=department2,departmentToken=department2.token },
            };

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString());
            this._context = new VogCodeChallenge.API.DAL.ApplicationDbContext(builder.Options);
            this._context.employees.AddRange( // adding test data
                    employees);
            this._context.SaveChanges();


        }
        // GET api/employees
        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {// in real world it should return EmployeeModel insted of the entities 
            EmployeeService empService = new EmployeeService(this._context);
            IEnumerable<Employee> result = empService.GetAll();
            return Ok(result);
        }

        // GET api/employees/department/75520E56-3033-444D-9214-B614CD1987DB
        [HttpGet("department/{departmentId}")]
        public ActionResult<IEnumerable<Employee>> Get(Guid departmentId)
        {
            EmployeeService empService = new EmployeeService(this._context);
            IEnumerable<Employee> result = empService.GetByDepartment(departmentId);
            return Ok(result);
        }
    }
}