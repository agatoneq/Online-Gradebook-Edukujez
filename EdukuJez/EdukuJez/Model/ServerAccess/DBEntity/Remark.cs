using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Remark : EntityBase
    {
        public int StudentId { get; set; }
        public int SubmitterId { get; set; }
        public User Student { get; set; }
        public User Submitter { get; set; }
        public string Contents { get; set; }
    }
}