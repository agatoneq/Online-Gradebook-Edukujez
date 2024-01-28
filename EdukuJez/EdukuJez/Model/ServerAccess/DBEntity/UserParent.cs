using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class UserParent : EntityBase
    {
        public int StudentId { get; set; }
        public int ParentId { get; set; }
        public User Student { get; set; }
        public User Parent { get; set; }
    }
}