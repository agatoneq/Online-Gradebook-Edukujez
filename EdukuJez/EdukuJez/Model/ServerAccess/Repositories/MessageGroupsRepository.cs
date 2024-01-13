using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Model.ServerAccess.Repositories
{
    public class MessageGroupsRepository : ARepository<MessageGroups>
    {
        public MessageGroupsRepository()
        {
            Table = Context.MessageGroups;
        }



        public List<MessageGroups> GetAll()
        {
            return Table.ToList();
        }
    }
}