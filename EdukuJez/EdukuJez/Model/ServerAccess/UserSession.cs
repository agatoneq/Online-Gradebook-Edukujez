using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public class UserSession
    {
        const String LOGIN_SITE = "Default.aspx";
        static UserSession _instance;
        public readonly String Login;
        UserSession(String login)
        {
            this.Login = login;
        }

        public static void ChangeSitePermissionCheck(Page sender)
        {
            if (_instance == null)
            {
                sender.Response.Redirect(LOGIN_SITE);
            }
        }

        public static bool EnterNewSession(string login)
        {
           _instance = new UserSession(login);

            return true;
        }
        public static void EndSession()
        {
            _instance = null;
        }
    }
}