using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EdukuJez.Model.ServerAccess.Repositories
{
    public class ClassesAdminReposytory : ARepository<ClassC>
    {
        public ClassesAdminReposytory()
        {
            Table = Context.Classes;
        }
    }
}