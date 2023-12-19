using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class SiteMaster : MasterPage
    {
        const String LOGIN_SITE = "Default.aspx";
        protected void Page_Load(object sender, EventArgs e)
        {

            if (UserSession.IsInSession())
            {
                var Session = UserSession.GetSession();
                ProfilePanel.Visible = true;
                ProfileNameLabel.Text = Session.UserName;
                ProfileSurnameLabel.Text = Session.UserSurname;
            }
            else
            {
                //Response.Redirect(LOGIN_SITE);
                ProfilePanel.Visible = false;
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            UserSession.EndSession(new Page());
            Response.Redirect(LOGIN_SITE);
        }

        protected void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangingPassword.aspx");
        }
    }
}