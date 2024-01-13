using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace EdukuJez.Repositories
{
    public class Group : EntityBase
    {
        public string Name { get; set; }
        public Group ParentGroup { get; set; }
        public User Educator { get; set; }
        public ICollection<Group>  ChildGroups { get; set; } = new List<Group>();
        public ICollection<GroupUser> Users { get; set; } = new List<GroupUser>();
        public ICollection<ClassC> Classes { get; set; } = new List<ClassC>();
        public ICollection<MessageGroups> Messages { get; set; } = new List<MessageGroups>();
        
        public bool IsNameValid(string name)
        {
            Regex reg = new Regex(@"^[a-zA-Z]\w{2,29}$");
            return reg.IsMatch(name);
        }
    }
}