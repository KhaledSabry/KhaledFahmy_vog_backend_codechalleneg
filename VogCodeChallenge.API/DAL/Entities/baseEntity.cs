using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VogCodeChallenge.API.DAL.Entities
{
    public class baseEntity
    {
        [Key]
        public Guid token { get; set; }
    }
}
