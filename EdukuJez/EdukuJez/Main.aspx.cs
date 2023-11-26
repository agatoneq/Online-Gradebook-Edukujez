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
                    PanelFactory.MakePanel("Ogłoszenia", "#D2691E", "Main.aspx", this));

                AddTableRow(PanelFactory.MakePanel("Plan Zajęć", "#996515", "Main.aspx", this),
                    PanelFactory.MakePanel("Zarządzanie Kontami", "#DAA520", "Main.aspx", this));

                AddTableRow(PanelFactory.MakePanel("Grupy i uprawnienia", "#F88158", "Main.aspx", this),
                     PanelFactory.MakePanel("Zarządzanie Lekcjami", "#Ddff50f", "EditClasses.aspx", this));
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
