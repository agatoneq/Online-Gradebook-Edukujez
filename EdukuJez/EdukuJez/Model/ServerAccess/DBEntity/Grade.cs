using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Grade : EntityBase
    {
        public int GradeValue { get; set; }
        public string GradeType { get; set; } //czy ocena punktowa czy nominalna
        public int GradeWeight { get; set; }
        public int TeacherId { get; set; }
        public int StudentId { get; set; }
        public Subject Subject { get; set; }
        public Activity Activity { get; set; }
        public User Users { get; set; }
        public User Teacher { get; set; }
    }
}