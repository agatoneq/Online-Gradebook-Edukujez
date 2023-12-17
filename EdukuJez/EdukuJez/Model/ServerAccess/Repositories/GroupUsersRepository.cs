using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class GroupUsersRepository : ARepository<GroupUser>
    {
        public GroupUsersRepository()
        {
            Table = Context.GroupUsers;
        }
    }
}