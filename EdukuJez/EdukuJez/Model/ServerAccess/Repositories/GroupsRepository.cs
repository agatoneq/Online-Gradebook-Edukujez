using EdukuJez.Repositories;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class GroupsRepository : ARepository<Group>
    {
        public GroupsRepository()
        {
            Table = Context.Groups;
        }

        public Group GetById(int id)
        {
            foreach (var row in Table)      
            {
                if (row.Id==id) return row;
            }
            return null;
        }
    }
}