using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class ClassC : EntityBase
    {
        public Subject Subject { get; set; }
        public ICollection<ClassUsers> Users { get; set; } = new List<ClassUsers>();
        public Group Group { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Class { get; set; }
        public string Hour { get; set; }
        public string Day { get; set; }
        public string Test { get; }
    }
}