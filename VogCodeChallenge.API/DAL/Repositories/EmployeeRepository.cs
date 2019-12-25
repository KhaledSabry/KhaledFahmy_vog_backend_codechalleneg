using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VogCodeChallenge.API.DAL.Entities;

namespace VogCodeChallenge.API.DAL.Repositories
{
    public class EmployeeRepository: baseRepository
    {
        readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            IEnumerable<Employee> employees = this._context.employees;
            return employees;
        }
        public IList<Employee> ListAll()
        {
            IList<Employee> employees = this._context.employees.ToList();
            return employees;
        }
    }
}
