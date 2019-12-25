using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API.modules
{
    public class CompanyModel : baseModel
    {
        
        public string CompanyName { get; set; }
        public List<DepartmentModel> Departments { get; set; }
    }
}
