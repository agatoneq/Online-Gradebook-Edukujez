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
            string insertQuery = $"INSERT INTO Users (Name, Surname, [Group], Login, Password) " +
                                       $"VALUES ('{entity.UserName}', '{entity.UserSurname}', '{entity.UserGroup}', '{entity.UserLogin}', '{entity.UserPassword}')";

            var response = ServerClient.StartConnection().SendRequestToSqlServer(insertQuery);
            response.Wait();
        }
        public void Update(User entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(User entity)
        {
            string deleteQuery = $"DELETE FROM Users WHERE Login = '{entity.UserLogin}'";

            var response = ServerClient.StartConnection().SendRequestToSqlServer(deleteQuery);
            response.Wait();
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

        public bool IsLoginInDatabase(string login)
        {
            string checkQuery = $"SELECT COUNT(*) FROM Users WHERE Login = '{login}'";

            var response = ServerClient.StartConnection().SendRequestToSqlServer(checkQuery);
            response.Wait();

            int count = response.Result?.FirstOrDefault()?.Values.FirstOrDefault() as int? ?? 0;

            return count > 0;
            
        }
    }
}