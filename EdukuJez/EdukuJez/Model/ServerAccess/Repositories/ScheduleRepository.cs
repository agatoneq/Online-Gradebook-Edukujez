using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EdukuJez.Repositories
{
    public class ScheduleRepository : ARepository<ClassC>
    {
        public ScheduleRepository()
        {
            Table = Context.Classes;
        }

    }
}