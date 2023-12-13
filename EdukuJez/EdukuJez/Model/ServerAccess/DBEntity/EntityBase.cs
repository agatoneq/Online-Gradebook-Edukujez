using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EdukuJez.Repositories
{
    public abstract class EntityBase
    {
        [Key]
        public int Id { get; set; }
    }
}