using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Xml;

namespace EdukuJez.Repositories
{
    public class AttendancesRepository : ARepository<Attendance>
    {
        public AttendancesRepository() : base()
        {
            Table = Context.Attendances;
        }

        public void AddNewEntry(Attendance entry)
        {
            Insert(entry);
        }
        public void RemoveEntry(Attendance entry)
        {
            Delete(entry);
        }

        public void EditEntry(Attendance entry)
        {
            UpdateRow(entry);
        }
    }
}