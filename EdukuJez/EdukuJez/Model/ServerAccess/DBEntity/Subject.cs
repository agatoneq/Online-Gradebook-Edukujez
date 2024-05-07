using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdukuJez.Repositories
{
    public class Subject : EntityBase
    {

        [Required]
        public string SubjectName { get; set; }
        [Required]
        public string SubjectDesc { get; set; }
        public bool Deactivated { get; set; } = false;
        public int TeacherGroupId { get; set; }
        public int StudentGroupId { get; set; }
        [Required]
        public Group TeacherGroup { get; set; }
        [Required]
        public Group StudentGroup { get; set; }
        public ICollection<ClassC> Classes { get; set; } = new List<ClassC>();
        public ICollection<Activity> Activites { get; set; } = new List<Activity>();
        public ICollection<Attachment> Attachments { get; set; } = new List<Attachment>();
        public ICollection<GradeFormula> Formulas { get; set; } = new List<GradeFormula>();
    }
}