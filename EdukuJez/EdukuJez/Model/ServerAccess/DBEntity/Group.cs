using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace EdukuJez.Repositories
{
    public class Group : EntityBase
    {
        [Required]
        public string Name { get; set; }
        public Group ParentGroup { get; set; }
        public User Educator { get; set; }
        public ICollection<Subject> SubjectsStudents { get; set; } = new List<Subject>();
        public ICollection<Subject> SubjectsTeachers { get; set; } = new List<Subject>();
        public ICollection<GroupUser> Users { get; set; } = new List<GroupUser>();
        public ICollection<ClassC> Classes { get; set; } = new List<ClassC>();
        public ICollection<MessageGroups> Messages { get; set; } = new List<MessageGroups>();

        public bool IsNameValid(string name)
        {
            Regex reg = new Regex(@"^[a-zA-Z][\w\s]{2,29}$");
            return reg.IsMatch(name);
        }
    }
}