using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VogCodeChallenge.API.DAL.Entities;
using VogCodeChallenge.API.modules;

namespace VogCodeChallenge.API.Service.mappers
{
    public class CompanyMapper
    {
        public static CompanyModel toModel(Company entity)
        {
            CompanyModel model = new CompanyModel();
            if (entity != null)
            {
                model.token = entity.token;
                model.CompanyName = entity.CompanyName;
                model.Departments = entity.Departments.Select(a => DepartmentMapper.toModel(a)).ToList();
            }
            return model;
        }
        public static Company toEntity(Company entity, CompanyModel model)
        {
            if (model != null)
            {
                entity.token = model.token;
                entity.CompanyName = model.CompanyName;
                entity.Departments = DepartmentMapper.toEntity(entity.Departments, model.Departments);
            }
            else
                entity = new Company();

            return entity;
        }
    }
}
