using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Model.Main;

namespace EdukuJez
{
    public partial class Main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddTableRow(PanelFactory.MakePanel("Przedmioty", "#808000", "SubjectPage.aspx", this),
                PanelFactory.MakePanel("Oceny", "#D2691E", "Grades.aspx", this));

            AddTableRow(PanelFactory.MakePanel("Uwagi", "#811B1B", "Remarks.aspx", this), 
                PanelFactory.MakePanel("Poczta", "#9E9A74", "PostOffice.aspx", this));

            AddTableRow(PanelFactory.MakePanel("Kalendarz", "#996515", "Calendars.aspx", this),
           PanelFactory.MakePanel("Plan Zajęć", "#DAA520", "LessonPlan.aspx", this));
            

            if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == true)      //tylko dla administatorów
            {
                AddTableRow(PanelFactory.MakePanel("Grupy i uprawnienia", "#F88158", "Main.aspx", this),  //dodać strone
                PanelFactory.MakePanel("Panel Administratora", "#DAF380", "AdminPanel.aspx", this));
            }
            AddTableRow(PanelFactory.MakePanel("Obecności", "#8B4513", "Attendances.aspx", this));
        }
        private void AddTableRow(params TablePanel[] cells)
        {
            TableRow row = new TableRow();
            foreach (var t in cells)
            {
                row.Controls.Add(t.ConvertToCell());
            }
            MainTable.Rows.Add(row);
        }
    }
}
