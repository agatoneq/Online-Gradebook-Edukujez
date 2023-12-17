using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace EdukuJez.Repositories
{
    public class SubjViewRepository //nie wolno używać do modyfikacji
    {
        public List<Subject> SubjViewList = new List<Subject>();
        public SubjViewRepository(String text)
        {
            var Subjects = new SubjectsRepository();

            var SubjViewList = Subjects.Table
        .Where(subject => subject.Grades.Any(grade => grade.Users.UserName == text))
        .ToList();

        }

        public List<Subject> GetAll()
        {
            return SubjViewList;
        }

       
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