using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EdukuJez.Repositories
{
    public class SubmissionsRepository : ARepository<Submission>
    {
        public SubmissionsRepository()
        {
            Table = Context.Submissions;
        }

    }
}