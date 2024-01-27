using EdukuJez.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class ChangingPassword : System.Web.UI.Page
    {
        private User newUser = new User();
        private UsersRepository usersRepository = new UsersRepository();

        protected void Page_Load(object sender, EventArgs e) { }

        protected void ConfirmPasswordClick(object sender, EventArgs e)
        {
            var Session = UserSession.GetSession();

            var repo = new UsersRepository();
            if (OldPasswordBox.Text != Session.UserPassword)
            {
                InfoLabel.Text = "Wpisz poprawne stare hasło!";
            }
            else
            {
                InfoLabel.Text = "";
                InfoPassword.Text = "Podaj nowe hasło:";
                OldPasswordBox.Visible = false;
                NewPasswordBox.Visible = true;
                ConfirmPasswordButton.Visible = false;
                ChangePasswordButton.Visible = true;
            }

        }

        protected void ChangePasswordClick(object sender, EventArgs e)
        {
            var Session = UserSession.GetSession();

            if (!newUser.IsPasswordValid(NewPasswordBox.Text))
            {
                InfoLabel.Visible = true;
                InfoLabel.Text = "Hasło musi się składać od 8 do 50 znaków, <br> co najmniej: jednej cyfry, jednej małej i jednej wielkiej litery <br> oraz co najmniej jednego ze znaków: . ! @ # $ % & ? <br> nie może także zawierać znaków polskich.";
            }
            else if (NewPasswordBox.Text == Session.UserPassword)
            {
                InfoLabel.Visible = true;
                InfoLabel.Text = "Nowe hasło musi być inne niż stare hasło.";
            }
            else
            {
                User userToUpdate = usersRepository.Table.FirstOrDefault(x => x.UserLogin == Session.UserLogin);
                userToUpdate.UserPassword = NewPasswordBox.Text;
                usersRepository.UpdateRow(userToUpdate);

                InfoLabel.Visible = false;
                InfoPassword.Visible = false;
                NewPasswordBox.Visible = false;
                ChangePasswordButton.Visible = false;
                MainInfoLabel.Visible = true;
                ReturnButton.Visible = true;
            }
        }

        protected void ReturnClick(object sender, EventArgs e)
        {
            Response.Redirect("Main.aspx");
        }
    }
}