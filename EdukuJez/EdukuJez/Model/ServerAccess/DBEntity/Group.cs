using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Group : EntityBase
    {
        public string Name { get; set; }
        public Group ParentGroup { get; set; }
        public ICollection<Group>  ChildGroups { get; set; }
        public ICollection<GroupUser> Users { get; set; }
        public ICollection<ClassC> Classes { get; set; }
        public ICollection<MessageGroups> Messages { get; set; }
    }
}