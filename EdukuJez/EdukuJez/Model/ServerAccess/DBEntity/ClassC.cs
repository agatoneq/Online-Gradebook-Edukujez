using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class ClassC : EntityBase
    {
        public Subject Subject { get; set; }
        public ICollection<ClassUsers> Users { get; set; } = new List<ClassUsers>();
        public ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();
        public Group Group { get; set; }
        public User Warden { get; set; }
        public int Class { get; set; }
        public string Hour { get; set; }
        public string Day { get; set; }
        public string Cyclicality { get; set; }
        public ICollection<Frequency> Frequency { get; set; } = new List<Frequency>();

        public int? SubstitutionId { get; set; }
        public Substitution Substitution { get; set; } 
    }
}