using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Activity : EntityBase
    {
        public string Name { get; set; }
        public bool IsFinalGrade { get; set; }
        public int? FormulaId { get; set; }
        public ICollection<Grade> Grades { get; set; } = new List<Grade>();
        public GradeFormula formula { get; set; }
        public Subject Subject { get; set; }
    }
}