using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class GradeFormula : EntityBase
    {
        public string Formula { get; set; }
        public Activity Activity { get; set; }
    }
}