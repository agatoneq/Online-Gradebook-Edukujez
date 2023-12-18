using EdukuJez.Repositories;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Windows;


namespace EdukuJez.Model.ServerAccess.Repositories
{
    public class ClassesAdminRepository : ARepository<ClassC>
    {
        public ClassesAdminRepository()
        {
            Table = Context.Classes;
        }

    }
}
