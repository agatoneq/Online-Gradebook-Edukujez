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
            AddTableRow(PanelFactory.MakePanel("Przedmioty", "#808000", "Default.aspx", this),
                PanelFactory.MakePanel("Oceny", "#D2691E", "Grades.aspx", this));

            AddTableRow(PanelFactory.MakePanel("Plan Zajęć", "#996515", "LessonPlan.aspx", this), 
                PanelFactory.MakePanel("Poczta", "#DAF380", "PostOffice.aspx", this));


            if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == true)      //tylko dla administatorów
            {
                AddTableRow(PanelFactory.MakePanel("Grupy i uprawnienia", "#F88158", "Main.aspx", this),
                PanelFactory.MakePanel("Panel Administratora", "#DAA520", "AdminPanel.aspx", this));
            }
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
