using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;

namespace EdukuJez
{
    public class UserSession
    {
        const String LOGIN_SITE = "Default.aspx";
        static UserSession _instance;
        User user;
        public string UserName { get { return user.UserName; }}
        public string UserSurname { get { return user.UserSurname; } }
        public string UserGroup { get { return user.UserGroup; } }
        public string UserLogin { get { return user.UserLogin; } }
        public string UserPassword { get { return user.UserPassword; } }
        UserSession(User user)
        {
            this.user = user;
        }
        public static UserSession GetSession()
        {
            return _instance;
        }
        public static bool  CheckPermission(String PermissionSubject, String PermissionType)
        {
            return true;
        }
        public void ChangeSitePermissionCheck(Page sender)
        {
              //tu dać sprawdzanie dostępu do strony
        }
        public static bool EnterNewSession(User user)
        {
           _instance = new UserSession(user);
            return true;
        }
        public static bool IsInSession()
        {
            if (_instance == null)
                return false;
            else
                return true;
        }
        public static void EndSession(Page sender)
        {
            _instance = null;
        }
    }
}