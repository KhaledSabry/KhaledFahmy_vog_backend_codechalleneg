using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API.DAL.Entities
{
    public class Department : baseEntity
    {
        public Department()
        {
            this.Employees = new List<Employee>();
        } 
        public string DepartmentName { get; set; } 
        public string Address { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
