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
    public partial class _Default : Page
    {
        const string FAILURE_MSG = "Błędne dane logowania,\n spróbuj jeszcze raz";
        const string MAIN_SITE = "Main.aspx";
        const bool debug = false;
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {


        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string login = Login1.UserName;
            string password = Login1.Password;

            //Repozytorium


            var repo = new UsersRepository();
            if (repo.CheckLogin(login, password))
            {
                UserSession.EnterNewSession(repo.GetByLogin(login));
                Response.Redirect(MAIN_SITE);
            }
            else
            {
                Login1.FailureText = FAILURE_MSG;
            }
        }
    }
}