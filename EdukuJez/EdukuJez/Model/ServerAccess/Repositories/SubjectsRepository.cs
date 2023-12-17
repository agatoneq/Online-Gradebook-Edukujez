using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Xml;

namespace EdukuJez.Repositories 
{
    public class SubjectsRepository : ARepository<Subject>
    {
        public SubjectsRepository()
        {
            Table = Context.Subjects;
        }

        public SubjectsRepository(String sqlText)
        {
        }

        public List<Subject> GetAll()
        {
            return Table.ToList();
        }
    }
}