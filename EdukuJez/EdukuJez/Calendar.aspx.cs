using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EdukuJez
{
    public partial class Calendar : System.Web.UI.Page
    {
        CalendarRepository Calend = new CalendarRepository();

        protected void Page_Load(object sender, EventArgs e)
        {
            var calendarE = Calend.Table.OrderBy(a => a.Date).ToList();
            PopulateCalendar(calendarE);
        }

        private void PopulateCalendar(List<Repositories.Calendar> calendarE)
        {
            var l = calendarE.Select(a => new
            {
                Date = a.Date.ToString("yyyy-MM-dd"), // Użyj właściwości Date, aby uzyskać tylko datę
                Desc = a.Desc,
            });

            myRepeater.DataSource = l.ToList();
            myRepeater.DataBind();
        }
    }
}
