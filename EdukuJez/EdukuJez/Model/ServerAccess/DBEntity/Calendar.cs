using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class Calendar : EntityBase
    {
        public DateTime Date { get; set; }
        public string Desc { get; set; }
    }
}