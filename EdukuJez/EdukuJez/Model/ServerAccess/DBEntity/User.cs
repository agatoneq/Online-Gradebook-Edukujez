using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserLogin { get; set; }
        public string UserPassword { get; set; }

        public ICollection<GroupUser> Groups { get; set; }
        public ICollection<Grade> Grades { get; set; }
        public ICollection<ClassUsers> Clasess { get; set; }
    }
}