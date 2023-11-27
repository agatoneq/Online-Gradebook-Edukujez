using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EdukuJez.Repositories
{
    public class SubjViewRepository : IRepository<SubjView>
    {
        List<SubjView> SubjViewList;
        const string CREATE_QUARY = "Select * from SubjView";
        public SubjViewRepository()
        {
            SubjViewList = new List<SubjView>();
            var response = ServerClient.StartConnection().ReturnDataReader(CREATE_QUARY);
            response.Wait();
            MapEntities(response.Result);
        }
        public SubjViewRepository(String text)
        {
            SubjViewList = new List<SubjView>();
            var response = ServerClient.StartConnection().ReturnDataReader("select * from SubjView where "+ text);
            response.Wait();
            MapEntities(response.Result);
        }

        //implementacja interfejsu
        public SubjView GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<SubjView> GetAll()
        {
            return SubjViewList;
        }
        public void Create(SubjView entity)
        {
            throw new NotImplementedException();
        }
        public void Update(SubjView entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(SubjView entity)
        {
            throw new NotImplementedException();
        }
        //Mapowanie
        private void MapEntities(SqlDataReader reader)
        {
            if(reader != null)
            while (reader.Read())
            {
                SubjView subjView = new SubjView();

                subjView.ID_User = reader.GetInt32(0);
                subjView.Login = reader.GetString(1);
                subjView.ID_Subject = reader.GetInt32(2);
                subjView.Subject = reader.GetString(3);

                SubjViewList.Add(subjView);
            }
        }
        //Wyszukiwanie linq na kolekcji repozytorium
       
    }
}
/*
CREATE VIEW SubjView AS
SELECT u.ID_User, us.Login, s.ID_Subject, s.Subject
FROM User_Group u
Inner join Users us on u.ID_User = us.ID_User
INNER JOIN Groups g ON u.ID_Group = g.ID_Group
Inner JOIN Classes c on g.ID_Group = c.ID_Group
inner JOIN Subjects s on c.ID_Subject = s.ID_Subject
 */