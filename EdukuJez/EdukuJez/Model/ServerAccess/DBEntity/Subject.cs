using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Subject : EntityBase
    {
        public string SubjectName { get; set; }
        public ICollection<ClassC> Classes { get; set; }
        public ICollection<Grade> Grades { get; set; }
    }
}