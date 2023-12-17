using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class GroupUser : EntityBase
    {
        public Group Group { get; set; }
        public User User { get; set; }
    }
}