using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class ClassUsers: EntityBase
    {
        public ClassC Class { get; set; }
        public User User { get; set; }
    }
}