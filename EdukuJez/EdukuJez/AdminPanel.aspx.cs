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
            if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == false)
                UserSession.ChangeSiteNoPermission(this, "Main.aspx");

            AddTableRow(PanelFactory.MakePanel("Kontami", "#808000", "AccountsManagement.aspx", this),
                PanelFactory.MakePanel("Kontami dla Rodziców", "#D2691E", "ChildForParent.aspx", this)); //dodać strone

            AddTableRow(PanelFactory.MakePanel("Członkami Grup", "#811B1B", "AdminPanel.aspx", this), //dodać strone                      
                PanelFactory.MakePanel("Grupami Użytkowników", "#9E9A74", "GroupsManagement.aspx", this));

                AddTableRow(PanelFactory.MakePanel("Kalendarzem", "#996515", "CalendarAdminPanel.aspx", this),
                    PanelFactory.MakePanel("Planem Zajęć", "#DAA520", "EditClasses.aspx", this));

                AddTableRow(PanelFactory.MakePanel("Przedmiotami", "#F88158", "SubjectAdminPanel.aspx", this),
                    PanelFactory.MakePanel("PlaceHolder", "#DAF380", "AdminPanel.aspx", this)); //dodać strone
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