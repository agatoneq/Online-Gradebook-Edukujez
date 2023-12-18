using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class ActivitiesRepository : ARepository<Activity>
    {
        public ActivitiesRepository()
        {
            Table = Context.Activities;
        }
    }
}