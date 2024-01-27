using EdukuJez.Model.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddTableRow(PanelFactory.MakePanel("Przeglądaj Widomości", "#808000", "ReadMessage.aspx", this),
            PanelFactory.MakePanel("Napisz Wiadomość", "#D2691E", "WriteMessage.aspx", this));

        }

        private void AddTableRow(params TablePanel[] cells)
        {
            TableRow row = new TableRow();
            foreach (var t in cells)
            {
                row.Controls.Add(t.ConvertToCell());
            }
            PostOfficeTable.Rows.Add(row);
        }
    }
}