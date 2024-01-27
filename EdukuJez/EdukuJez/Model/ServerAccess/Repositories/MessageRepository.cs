using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Model.ServerAccess.Repositories
{
    public class MessageRepository : ARepository<Message>
    {
        public MessageRepository()
        {
            Table = Context.Messages;
        }

        public List<Message> GetAll()
        {
            return Table.ToList();
        }
    }
}