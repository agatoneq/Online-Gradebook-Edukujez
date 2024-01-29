using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EdukuJez.Repositories
{
    public class UserParentsRepository : ARepository<UserParent>
    {
        public UserParentsRepository() : base()
        {
            Table = Context.UserParents;
        }

        public void AddNewEntry(UserParent entry)
        {
            Insert(entry);
        }
        public void RemoveEntry(UserParent entry)
        {
            Delete(entry);
        }

        public void EditEntry(UserParent entry)
        {
            UpdateRow(entry);
        }
    }
}