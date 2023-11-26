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
            if (!IsPostBack)
            {
                TableRow row1 = new TableRow();
                row1.Controls.Add(PanelFactory.MakePanel("Kontami", "#808000", "Main.aspx", this).ConvertToCell());
                row1.Controls.Add(PanelFactory.MakePanel("Kontami dla Rodziców", "#D2691E", "Main.aspx", this).ConvertToCell());
                TableRow row2 = new TableRow();
                row2.Controls.Add(PanelFactory.MakePanel("Planem Zajęć", "#811B1B", "Main.aspx", this).ConvertToCell());
                row2.Controls.Add(PanelFactory.MakePanel("Kalendarzem", "#9E9A74", "Main.aspx", this).ConvertToCell());
                TableRow row3 = new TableRow();
                row3.Controls.Add(PanelFactory.MakePanel("Przedmiotami", "#996515", "Main.aspx", this).ConvertToCell());
                row3.Controls.Add(PanelFactory.MakePanel("Grupami Zajęciowymi", "#DAA520", "Main.aspx", this).ConvertToCell());


                // Dodajemy wiersz do tabeli
                MainAdminTable.Rows.Add(row1);
                MainAdminTable.Rows.Add(row2);
                MainAdminTable.Rows.Add(row3);
            }
        }
    }
}