using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Web;

namespace EdukuJez.Model.ServerAccess.Repositories
{
    public class ClassUsersRepository : ARepository<ClassUsers>
    {
        public ClassUsersRepository() : base()
        {
            Table = Context.ClassUsers;
        }
        public List<ClassUsers> GetAll()
        {
            return Table.ToList();
        }


    }
}