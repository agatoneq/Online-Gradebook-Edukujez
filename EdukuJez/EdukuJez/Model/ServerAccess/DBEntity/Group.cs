using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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
    }
}