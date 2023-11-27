using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace EdukuJez.Repositories
{
    public class SubjView : EntityBase
    {
        public int ID_User { get; set; }
        public String Login { get; set; }
        public int ID_Subject { get; set; }
        public String Subject{ get; set; }
        
    }
}