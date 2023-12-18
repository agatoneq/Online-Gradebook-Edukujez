using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Activity : EntityBase
    {
        public string Name { get; set; }
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}