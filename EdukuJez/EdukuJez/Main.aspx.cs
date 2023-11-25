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
            if (!IsPostBack)
            {
                TableRow row1 = new TableRow();
                row1.Controls.Add(PanelFactory.MakePanel("Przedmioty", "#808000", "Main.aspx", this).ConvertToCell());
                row1.Controls.Add(PanelFactory.MakePanel("Ogłoszenia", "#D2691E", "Main.aspx", this).ConvertToCell());
                TableRow row2 = new TableRow();
                row2.Controls.Add(PanelFactory.MakePanel("Plan Zajęć", "#996515", "Main.aspx", this).ConvertToCell());
                row2.Controls.Add(PanelFactory.MakePanel("Zarządzanie Kontami", "#DAA520", "Main.aspx", this).ConvertToCell());


                // Dodajemy wiersz do tabeli
                MainTable.Rows.Add(row1);
                MainTable.Rows.Add(row2);
            }
        }
        public void MainRedirect()
        { 
        }
    }
}