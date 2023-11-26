using EdukuJez.Model.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class AdminPanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                AddTableRow(PanelFactory.MakePanel("Kontami", "#808000", "AccountsManagement.aspx", this),
                    PanelFactory.MakePanel("Kontami dla Rodziców", "#D2691E", "AdminPanel.aspx", this));

                AddTableRow(PanelFactory.MakePanel("Planem Zajęć", "#811B1B", "Main.aspx", this),
                    PanelFactory.MakePanel("Kalendarzem", "#9E9A74", "AdminPanel.aspx", this));

                AddTableRow(PanelFactory.MakePanel("Przedmiotami", "#996515", "AdminPanel.aspx", this),
                    PanelFactory.MakePanel("Grupami Zajęciowymi", "#DAA520", "AdminPanel.aspx", this));
        }
        private void AddTableRow(params TablePanel[] cells)
        {
            TableRow row = new TableRow();
            foreach (var t in cells)
            {
                row.Controls.Add(t.ConvertToCell());
            }
            MainAdminTable.Rows.Add(row);
        }
    }
}