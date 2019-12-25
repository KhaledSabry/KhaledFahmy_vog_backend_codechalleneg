using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using VogCodeChallenge.API.DAL;
using VogCodeChallenge.API.DAL.Entities;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var mock = new Mock<IDbContext>();
            mock.Setup(x => x.Set<Company>())
                .Returns(new FakeDbSet<Company>
                {
                    new Company {token=System.Guid.NewGuid() ,CompanyName = "Company1",Departments=
                        new List<Department>() {
                            new Department() { token=System.Guid.NewGuid(),DepartmentName= "Comp1-Department1",Address= "Comp1-Dep1-Address1"
                                ,Employees= new List<Employee>() {
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Comp1-Dep1-FName1",LastName="Comp1-Dep1-Name1",JobTitle="Comp1-Dep1-Title1",MailingAddress= "Comp1-Dep1-Address1" },
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Comp1-Dep1-FName2",LastName="Comp1-Dep1-Name2",JobTitle="Comp1-Dep1-Title2",MailingAddress= "Comp1-Dep1-Address2" },
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Comp1-Dep1-FName3",LastName="Comp1-Dep1-Name3",JobTitle="Comp1-Dep1-Title3",MailingAddress= "Comp1-Dep1-Address3" },
                                }
                            },
                            new Department() { token=System.Guid.NewGuid(),DepartmentName= "Comp1-Department2",Address= "Comp1-Dep2-Address2"
                                ,Employees= new List<Employee>() {
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Comp1-Dep2-FName1",LastName="Comp1-Dep2-Name1",JobTitle="Comp1-Dep2-Title1",MailingAddress= "Comp1-Dep2-Address1" },
                                    new Employee() { token=System.Guid.NewGuid(),FirstName= "Comp1-Dep2-FName2",LastName="Comp1-Dep2-Name2",JobTitle="Comp1-Dep2-Title2",MailingAddress= "Comp1-Dep2-Address2" },
                                }
                            }
                        }
                    }
                });
            mock.Employees

            // Act
            var allUsers = userService.GetAllUsers();

            // Assert
            Assert.AreEqual(1, allUsers.Count());
        }
    }
}
