using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VogCodeChallenge.API.DAL.Entities;
using VogCodeChallenge.API.modules;

namespace VogCodeChallenge.API.System.mappers
{
    public class DepartmentMapper
    {
        public static DepartmentModel toModel(Department entity)
        {
            DepartmentModel model = new DepartmentModel();
            if (entity != null)
            { 
                model.token = entity.token;
                model.DepartmentName = entity.DepartmentName;
                model.Address = entity.Address;
                model.Employees = entity.Employees.Select(a=>EmployeeMapper.toModel( a)).ToList(); 
            }
            return model;
        }
        public static Department toEntity(Department entity, DepartmentModel model)
        {
            if (model != null)
            {
                entity.token = model.token;
                entity.DepartmentName = model.DepartmentName;
                entity.Address = model.Address;
                entity.Employees =  EmployeeMapper.toEntity( entity.Employees, model.Employees) ;
            }
            else
                entity = new Department();
            return entity;
        }

        public static List<Department> toEntity(List<Department> entities//original entities
           , List<DepartmentModel> models)
        {
            foreach (var model in models)
            {
                if (entities.Exists(a => a.token == model.token))
                { //update exited entities
                    var entity = entities.Find(a => a.token == model.token);
                    entity = toEntity(entity, model);
                }
                else
                { //add new add models to entities 
                    var entity = new Department();
                    entity = toEntity(entity, model);
                    entities.Add(entity);
                }

            }
            for (int i = entities.Count - 1; i >= 0; --i)
            {
                if (!models.Exists(a => a.token == entities[i].token))
                { //find the deleted models
                    entities.RemoveAt(i);
                }
            }

            return entities;
        }
    }
}
