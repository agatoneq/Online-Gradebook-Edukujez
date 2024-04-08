using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Substitution : EntityBase
    {
        public string Desc { get; set; }
        public ClassC Class { get; set; }
        public User SubTeacher { get; set; }

    }
}