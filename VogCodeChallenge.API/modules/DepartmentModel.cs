using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API.modules
{
    public class DepartmentModel : baseModel
    { 
        public string DepartmentName { get; set; }
        public string Address { get; set; }
        public List<EmployeeModel> Employees { get; set; }
    }
}
