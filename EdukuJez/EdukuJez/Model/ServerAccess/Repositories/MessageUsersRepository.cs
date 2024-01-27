using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace EdukuJez.Model.ServerAccess.Repositories
{
    public class MessageUsersRepository : ARepository<MessageUsers>
    {
        public MessageUsersRepository()
    {
        Table = Context.MessageUsers;
    }



    public List<MessageUsers> GetAll()
    {
        return Table.ToList();
    }
}
}