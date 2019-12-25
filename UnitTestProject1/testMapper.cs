using FakeItEasy;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using VogCodeChallenge.API.DAL;
using VogCodeChallenge.API.DAL.Entities;
using VogCodeChallenge.API.modules;
using VogCodeChallenge.API.Service.mappers;
using Xunit;

namespace UnitTestProject1
{
    [TestClass]
    public class testMapper
    {
        public testMapper()
        { 
        }
        [Fact]
        public void testEmployeeMapper()
        {

            Company compEntity = new Company{token = System.Guid.NewGuid(),CompanyName = "Company1"};
            Department deptEntity = new Department{token = System.Guid.NewGuid(),DepartmentName = "Department1",Address = "Dep1-Address1"};

            Employee empEntity = new Employee { token = System.Guid.NewGuid(), FirstName = "FName1", LastName = "LName1", JobTitle = "Comp1-Dep1-Title1", MailingAddress = "Comp1-Dep1-Address1",department= deptEntity, departmentToken= deptEntity.token,company=compEntity,companyToken=compEntity.token };
            EmployeeModel empModel = EmployeeMapper.toModel(empEntity); // convert from Model to Entity
            Employee empEntity2 = EmployeeMapper.toEntity(new Employee(), empModel); // convert it back from Entity to Model

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(empEntity.ByProperties(), empEntity2);
        }
        [Fact]
        public void testDepartmentMapper()
        {
            Department deptEntity = new Department
            {
                token = System.Guid.NewGuid(),
                DepartmentName = "Department1",
                Address = "Dep1-Address1",
                Employees = new List<Employee>() {
                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Dep1-FName1",LastName="Dep1-LName1",JobTitle="Title1",MailingAddress= "Address1" },
                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Dep1-FName2",LastName="Dep1-LName2",JobTitle="Title2",MailingAddress= "Address2" },
                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Dep1-FName3",LastName="Dep1-LName3",JobTitle="Title3",MailingAddress= "Address3" },
                }
            };
            DepartmentModel deptModel = DepartmentMapper.toModel(deptEntity);
            Department deptEntity2 = DepartmentMapper.toEntity(new Department(), deptModel); // convert it back from Entity to Model

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(deptEntity.ByProperties(), deptEntity2);
        }
        [Fact]  
        public void testCompanyMapper()
        {
            Company compEntity=new Company
            {
                token = System.Guid.NewGuid(),
                CompanyName = "Company1",
                Departments =
                        new List<Department>() {
                            new Department() { token=System.Guid.NewGuid(),DepartmentName= "Comp1-Department1",Address= "Comp1-Dep1-Address1"
                                ,Employees= new List<Employee>() {
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Comp1-Dep1-FName1",LastName="Comp1-Dep1-LName1",JobTitle="Comp1-Dep1-Title1",MailingAddress= "Comp1-Dep1-Address1" },
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Comp1-Dep1-FName2",LastName="Comp1-Dep1-LName2",JobTitle="Comp1-Dep1-Title2",MailingAddress= "Comp1-Dep1-Address2" },
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Comp1-Dep1-FName3",LastName="Comp1-Dep1-LName3",JobTitle="Comp1-Dep1-Title3",MailingAddress= "Comp1-Dep1-Address3" },
                                }
                            },
                            new Department() { token=System.Guid.NewGuid(),DepartmentName= "Comp1-Department2",Address= "Comp1-Dep2-Address2"
                                ,Employees= new List<Employee>() {
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Comp1-Dep2-FName1",LastName="Comp1-Dep2-LName1",JobTitle="Comp1-Dep2-Title1",MailingAddress= "Comp1-Dep2-Address1" },
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Comp1-Dep2-FName2",LastName="Comp1-Dep2-LName2",JobTitle="Comp1-Dep2-Title2",MailingAddress= "Comp1-Dep2-Address2" },
                                }
                            }
                        }
            };
            CompanyModel compModel = CompanyMapper.toModel(compEntity);
            Company compEntity2 = CompanyMapper.toEntity(new Company(), compModel); // convert it back from Entity to Model

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(compEntity.ByProperties(), compEntity2);
        }
    }

}
