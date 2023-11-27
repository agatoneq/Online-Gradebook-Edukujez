using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EdukuJez.Repositories
{
    public class ScheduleRepository : IRepository<ClassC>
    {
        List<ClassC> ClassCList;
        const string CREATE_QUARY = "Select * from LessonsPlan";
        public ScheduleRepository()
        {
            ClassCList = new List<ClassC>();
            var response = ServerClient.StartConnection().ReturnDataReader(CREATE_QUARY);
            response.Wait();
            MapEntities(response.Result);
        }

        //implementacja interfejsu
        public ClassC GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<ClassC> GetAll()
        {
            return ClassCList;
        }
        public void Create(ClassC entity)
        {
            throw new NotImplementedException();
        }
        public void Update(ClassC entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(ClassC entity)
        {
            throw new NotImplementedException();
        }
        //Mapowanie
        private void MapEntities(SqlDataReader reader)
        {
            while (reader.Read())
            {
                ClassC ClassC = new ClassC();

                ClassC.Subject = reader.GetString(0);
                ClassC.Name = reader.GetString(1);
                ClassC.Surname = reader.GetString(2);
                ClassC.Class= reader.GetInt32(3);
                ClassC.Hour = reader.GetString(4);
                ClassC.Day = reader.GetString(5);

                ClassCList.Add(ClassC);
            }
        }
        //Wyszukiwanie linq na kolekcji repozytorium
        
    }
}