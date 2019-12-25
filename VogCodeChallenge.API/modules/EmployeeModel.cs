using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API.modules
{
    public class EmployeeModel: baseModel
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string MailingAddress { get; set; } 
        public DepartmentModel department { get; set; }
         public CompanyModel company { get; set; }
    }
}
