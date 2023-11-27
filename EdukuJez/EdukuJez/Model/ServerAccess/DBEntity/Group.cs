using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Group : EntityBase
    {
        public string Name { get; set; }
        public string ParentGroup { get; set; }
        public int ParentGroupID { get; set; }
    }
}