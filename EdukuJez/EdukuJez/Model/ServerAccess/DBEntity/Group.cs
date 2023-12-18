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
        public ICollection<Group>  ChildGroups { get; set; } = new List<Group>();
        public ICollection<GroupUser> Users { get; set; } = new List<GroupUser>();
        public ICollection<ClassC> Classes { get; set; } = new List<ClassC>();
        public ICollection<MessageGroups> Messages { get; set; } = new List<MessageGroups>();
    }
}