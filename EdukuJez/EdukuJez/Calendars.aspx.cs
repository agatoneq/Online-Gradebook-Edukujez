using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez
{
    public partial class Calendars : System.Web.UI.Page
    {
        CalendarRepository Calend = new CalendarRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            var calendarE = Calend.Table.OrderBy(a => a.Date).ToList();
            PopulateCalendar(calendarE);
        }

        private void PopulateCalendar(List<Repositories.Calendar> calendarE)
        {
            // Filtrowanie wydarzeń, które są równa lub późniejsze niż obecna data
            var currentDate = DateTime.Now.Date;
            var filteredCalendar = calendarE.Where(a => a.Date >= currentDate).ToList();

            var l = filteredCalendar.Select(a => new
            {
                Date = a.Date.ToString("dd-MM-yyyy"), // Użyj właściwości Date, aby uzyskać tylko datę
                Desc = a.Desc,
            });

            myRepeater.DataSource = l.ToList();
            myRepeater.DataBind();
        }
    }
}
