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
        BaseContext Context = BaseContext.GetContext();
        public SubjViewRepository()      
        {
            

        }

        public List<Subject> GetSubjects(int id)
        {
            var SubjViewList = from Subject in Context.Subjects
                               join ClassC in Context.Classes on Subject.Id equals ClassC.Subject.Id
                               join ClassUsers in Context.ClassUsers on ClassC.Id equals ClassUsers.Class.Id
                               join User in Context.Users on ClassUsers.User.Id equals User.Id
                               where User.Id == id
                               select  Subject;
            return SubjViewList.Distinct().ToList();
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