using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;


namespace EdukuJez.Repositories { 
    public class GradesRepository : IRepository<Grade>
    {
        List<Grade> GradesList;
        
        string CREATE_QUARY = "Select * from Grades";

        public GradesRepository()
        {
            GradesList = new List<Grade>();
            var response = ServerClient.StartConnection().ReturnDataReader(CREATE_QUARY);
            response.Wait();
            MapEntities(response.Result);
        }
        public GradesRepository(String text)
        {
            CREATE_QUARY = "select * from Grades where " + text;
            GradesList = new List<Grade>();
            var response = ServerClient.StartConnection().ReturnDataReader(CREATE_QUARY);
            response.Wait();
            MapEntities(response.Result);
        }
        public Grade GetById(int id) { 
            throw new NotImplementedException(); 
        }
        public List<Grade> GetAll() {
            return GradesList;
        }
        public void Create(Grade entity) {
            throw new NotImplementedException(); 
        }
        public void Update(Grade entity) {
            throw new NotImplementedException(); 
        }
        public void Delete(Grade entity) {
            throw new NotImplementedException();
        }

        //Mapowanie
        private void MapEntities(SqlDataReader reader)
        {
            if (reader != null)
                while (reader.Read())
            {
                Grade grade = new Grade();

                grade.Id = reader.GetInt32(0);
                grade.GradeValue = reader.GetInt32(1);
                grade.GradeWeight = reader.GetInt32(2);
                grade.GradeIDSubject = reader.GetInt32(3);
       
                GradesList.Add(grade);
            }
        }

        //Wyszukiwanie
        public List<int> getGrades(int id)
        {
            List<int> gradesList = new List<int>();
            for (int i = 0; i < GradesList.Count(); ++i) {
                if (GradesList[i].Id == id) {
                    gradesList.Add(GradesList[i].GradeValue);
                }
            }
            return gradesList;
        }
       
    }
}