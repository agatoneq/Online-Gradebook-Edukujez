using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Xml;

namespace EdukuJez.Repositories
{
    public class CalendarRepository : ARepository<Calendar>
    {
        public CalendarRepository() : base()
        {
            Table = Context.Calendar;
        }

        public void AddNewEntry(Calendar entry)
        {
            Insert(entry);
        }
        public void RemoveEntry(Calendar entry)
        {
            Delete(entry);
        }

        public void EditEntry(Calendar entry)
        {
            UpdateRow(entry);
        }
    }
}