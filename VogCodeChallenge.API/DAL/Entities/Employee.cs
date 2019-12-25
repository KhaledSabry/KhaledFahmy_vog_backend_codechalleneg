﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API.DAL.Entities
{
    public class Employee : baseEntity
    { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; } 
        public string MailingAddress { get; set; }
    }
}
