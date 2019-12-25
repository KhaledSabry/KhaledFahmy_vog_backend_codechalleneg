using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API.DAL.Entities
{
    public class Company: baseEntity
    {
        public string CompanyName { get; set; }
        public List<Department> Departments { get; set; }
        public Company()
        {
            this.Departments = new List<Department>();
        }
    }
}
