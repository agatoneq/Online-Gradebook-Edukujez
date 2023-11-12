using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class _Default : Page
    {
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
            var response = ServerClient.SendRequestToSqlServer("Select * from Uzytkownicy;");
            response.Wait();
            Login1.FailureText = response.Result.Count.ToString();
        }
    }
}