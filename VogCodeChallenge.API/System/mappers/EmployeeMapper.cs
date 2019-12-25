using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VogCodeChallenge.API.DAL.Entities;
using VogCodeChallenge.API.modules;

namespace VogCodeChallenge.API.System.mappers
{
    public class EmployeeMapper
    {
        public static EmployeeModel toModel(Employee entity)
        {
            EmployeeModel model = new EmployeeModel();
            if (entity != null)
            { 
                model.token = entity.token;
                model.FirstName = entity.FirstName;
                model.LastName = entity.LastName;
                model.JobTitle = entity.JobTitle;
                model.MailingAddress = entity.MailingAddress;
            }
            return model;
        }
        public static Employee toEntity(Employee entity, EmployeeModel model )
        {
            if (model != null)
            {  
                entity.token = model.token;
                entity.FirstName = model.FirstName;
                entity.LastName = model.LastName;
                entity.JobTitle = model.JobTitle;
                entity.MailingAddress = model.MailingAddress;
            }
            return entity;
        }
        public static List<Employee> toEntity(List<Employee> entities//original entities
            , List<EmployeeModel> models)
        {
            foreach(var model in models)
            {
                if(entities.Exists(a=>a.token==model.token))
                { //update exited entities
                    var entity = entities.Find(a => a.token == model.token);
                    entity = toEntity(entity, model);
                }
                else
                { //add new add models to entities 
                    var entity = new Employee();  
                    entity = toEntity(entity, model);
                    entities.Add(entity);
                }

            }
            for(int i= entities.Count-1;i>=0;--i)
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
