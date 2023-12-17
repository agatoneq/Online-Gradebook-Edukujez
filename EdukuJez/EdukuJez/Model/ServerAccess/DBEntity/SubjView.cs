using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace EdukuJez.Repositories
{
    [NotMapped]
    public class SubjView 
    {
        public int ID_User { get; set; }
        public string Login { get; set; }
        public int ID_Subject { get; set; }
        public string Subject{ get; set; }
        
    }
}