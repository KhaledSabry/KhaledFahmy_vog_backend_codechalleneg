using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VogCodeChallenge.API.DAL;
using VogCodeChallenge.API.DAL.Entities;
using VogCodeChallenge.API.DAL.Repositories;

namespace VogCodeChallenge.API.Service
{
    public class EmployeeService
    {
        readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            this._context = context;
        }
        public IEnumerable<Employee> GetAll()
        {
            EmployeeRepository empRepository = new EmployeeRepository(this._context);
            var emloyees = empRepository.GetAll();
            return emloyees;

            // in the real world: this layer should convert IEnumerable<Employee> to IEnumerable<EmployeeModel> like that
            //var employeeModels = emloyees.Select(a => EmployeeMapper.toModel(a));
            //return employeeModels;
        }
        public IList<Employee> ListAll()
        {
            EmployeeRepository empRepository = new EmployeeRepository(this._context);
            var emloyees = empRepository.ListAll();
            return emloyees;

            // in the real world: this layer should convert IEnumerable<Employee> to IList<EmployeeModel>  like that
            //var employeeModels = emloyees.Select(a => EmployeeMapper.toModel(a)).ToList();
            //return employeeModels;
        }

    }
}
