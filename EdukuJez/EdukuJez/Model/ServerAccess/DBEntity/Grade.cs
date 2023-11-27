using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Grade : EntityBase
    {
        public int GradeValue { get; set; }
        public int GradeWeight { get; set; }
        public int GradeIDSubject { get; set; }
    }
}