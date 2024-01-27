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
            
            AddTableRow(PanelFactory.MakePanel("Plan Zajęć", "#811B1B", "LessonPlan.aspx", this),
                PanelFactory.MakePanel("Panel Administratora", "#9E9A74", "AdminPanel.aspx", this));
            
            AddTableRow(PanelFactory.MakePanel("Uwagi", "#996515", "Remarks.aspx", this));
            //, (PanelFactory.MakePanel("Grupy i uprawnienia", "#DAA520", "Main.aspx", this));
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
