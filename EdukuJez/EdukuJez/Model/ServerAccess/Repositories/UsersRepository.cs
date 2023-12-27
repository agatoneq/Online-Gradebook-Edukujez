using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EdukuJez.Repositories
{
    public class UsersRepository : ARepository<User>
    {

        public UsersRepository()
        {
            Table = Context.Users;
        }
        //Wyszukiwanie linq na kolekcji repozytorium
        public bool CheckLogin(string login, string password)
        {
            return Table.Any(x => x.UserLogin == login && x.UserPassword == password);
        }
        public User GetByLogin(string login)
        {
            return Table.First(x => x.UserLogin == login);
        }

        public bool IsLoginInDatabase(string login) 
        {
            return Table.Any(x => x.UserLogin == login);
            
        }
    }
}