using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez.Repositories { 
    public class GradesRepository : ARepository<Grade>
    {

        string CREATE_QUARY = "Select * from Grades";

        public GradesRepository()
        {
            Table = Context.Grades;
        }
        public GradesRepository(String text)
        {

            CREATE_QUARY = "select * from Grades where " + text;
            var response = ServerClient.StartConnection().ReturnDataReader(CREATE_QUARY);
            response.Wait();
            //nie rozumiem po co to jest rozdzielone,
            //użycie wyłącznie jednego z tych konstruktorów byłoby dużo lepsze

        }

        //Wyszukiwanie
        public List<int> getGrades(int id)
        {
            var GradesList = new List<Grade>();
            List<int> gradesList = new List<int>();

            for (int i = 0; i < GradesList.Count(); ++i) {
                if (GradesList[i].Id == id) {
                    gradesList.Add(GradesList[i].GradeValue);
                }
            }
            // jeżeli dobrze rozumiem, zwracane są oceny o podanym Id,
            // jako że Id jest unikalne zawsze zostanie zwrócona tylko jedna ocena
            // czemu jest zwracana lista?
            return gradesList;
        }
       
    }
}