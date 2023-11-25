using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EdukuJez.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        List<User> UserList;
        const string CREATE_QUARY = "Select * from Users";
        public UsersRepository()
        {
            UserList = new List<User>();
            var response = ServerClient.StartConnection().ReturnDataReader(CREATE_QUARY);
            response.Wait();
            MapEntities(response.Result);
        }

        //implementacja interfejsu
        public User GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<User> GetAll()
        {
            return UserList;
        }
        public void Create(User entity)
        {
            throw new NotImplementedException();
        }
        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(User entity)
        {
            throw new NotImplementedException();
        }
        //Mapowanie
        private void MapEntities(SqlDataReader reader)
        {
            while (reader.Read())
            {
                User user = new User();
                
                user.Id = reader.GetInt32(0);
                user.UserName = reader.GetString(1);
                user.UserSurname = reader.GetString(2);
                //user.UserGroup= reader.GetString(3);
                user.UserLogin = reader.GetString(4);
                user.UserPassword = reader.GetString(5);

                UserList.Add(user);
            }
        }
        //Wyszukiwanie linq na kolekcji repozytorium
        public bool CheckLogin(string login, string password)
        {
            return UserList.Any(x => x.UserLogin == login || x.UserPassword == password);
        }
        public User GetByLogin(string login)
        {
            return UserList.First(x => x.UserLogin == login);
        }
    }
}