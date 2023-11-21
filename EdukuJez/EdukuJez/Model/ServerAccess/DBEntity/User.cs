using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class User : EntityBase
    {
        public string UserPassword { get; set; }
        public string UserLogin { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
    }
}