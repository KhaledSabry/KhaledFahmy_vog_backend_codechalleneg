using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API.modules
{
    public class DepartmentModel : baseModel
    {
        [Key]
        public Guid token { get; set; }
        public string DepartmentName { get; set; }
        public string Address { get; set; }
        public List<EmployeeModel> Employees { get; set; }
    }
}
