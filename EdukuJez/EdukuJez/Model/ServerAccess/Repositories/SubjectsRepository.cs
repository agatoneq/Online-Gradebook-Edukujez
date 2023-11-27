using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Xml;

namespace EdukuJez.Repositories 
{
    public class SubjectsRepository : IRepository<Subject>
    {
        List<Subject> SubjectList;
        static string CREATE_QUARY = "Select * from Subjects";
        public SubjectsRepository()
        {
            SubjectList = new List<Subject>();
            var response = ServerClient.StartConnection().ReturnDataReader(CREATE_QUARY);
            response.Wait();
            MapEntities(response.Result);
        }

        public SubjectsRepository(String sqlText)
        {
            SubjectList = new List<Subject>();
            var response = ServerClient.StartConnection().ReturnDataReader("select * from User where " + sqlText);
            response.Wait();
            MapEntities(response.Result);
        }
        //implementacja interfejsu
        public Subject GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Subject> GetAll()
        {
            return SubjectList;
        }
        public void Create(Subject entity)
        {
            CREATE_QUARY = "insert into Subjects values ('"+entity.SubjectName+"')";
            var response = ServerClient.StartConnection().ReturnDataReader(CREATE_QUARY);
        }
        public void Update(Subject entity)
        {
            throw new NotImplementedException();
        }
        public void Delete(Subject entity)
        {
            throw new NotImplementedException();
        }
        //Mapowanie
        private void MapEntities(SqlDataReader reader)
        {
            if(reader != null)
            while (reader.Read())
            {
                Subject subject = new Subject();

                subject.Id = reader.GetInt32(0);
                subject.SubjectName = reader.GetString(1);

                SubjectList.Add(subject);
            }
        }
    }
}