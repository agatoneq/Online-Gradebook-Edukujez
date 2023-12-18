using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EdukuJez.Repositories
{
    public class Subject : EntityBase
    {
        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string SubjectDesc { get; set; }
        public ICollection<ClassC> Classes { get; set; } = new List<ClassC>();
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
    }
}