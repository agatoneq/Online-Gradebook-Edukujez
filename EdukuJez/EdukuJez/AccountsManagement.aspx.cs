using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;

namespace EdukuJez
{
    public partial class AccountsManagement : System.Web.UI.Page
    {
        private User newUser = new User();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddClick(object sender, EventArgs e)
        {
            MainInfoLabel.Text = "Wypełnij dane nowego użytkownika:";
            LoginBox.Enabled = false;
            AddUserButton.Visible = false;
            DeleteUserButton.Visible = false;
            PasswordBox.Visible = true;
            GroupBox.Visible = true;
            ConfirmAddButton.Visible = true;
            NameLabel.Visible = true;
            NameBox.Visible = true;
            SurnameLabel.Visible = true;
            SurnameBox.Visible = true;
            PasswordLabel.Visible = true;
            GroupLabel.Visible = true;
        }

        protected void DeleteClick(object sender, EventArgs e)
        {
            MainInfoLabel.Text = "Czy na pewno chcesz usunąć tego użytkownika? Ta operacja jest nieodwracalna!";
            LoginBox.Enabled = false;
            AddUserButton.Visible = false;
            DeleteUserButton.Visible = false;
            ConfirmDeleteButton.Visible = true;
        }

        protected void ConfirmDeleteClick(object sender, EventArgs e)
        {
            newUser.UserLogin = LoginBox.Text;
            UsersRepository usersRepository = new UsersRepository();
            usersRepository.Delete(newUser);
        }

        protected void ConfirmAddClick(object sender, EventArgs e)
        {
            newUser.UserLogin = LoginBox.Text;
            newUser.UserName = NameBox.Text;
            newUser.UserSurname = SurnameBox.Text;
            newUser.UserPassword = PasswordBox.Text;
            newUser.UserGroup = GroupBox.Text;
            UsersRepository usersRepository = new UsersRepository();
            usersRepository.Create(newUser);
        }

        protected void LoginBoxChanged(object sender, EventArgs e)
        {
            UsersRepository usersRepository = new UsersRepository();
            int loginLength = LoginBox.Text.Length;
            if (loginLength >= 3 && loginLength <= 10 && !usersRepository.IsLoginInDatabase(LoginBox.Text))
            {
                AddUserButton.Enabled = true;
                DeleteUserButton.Enabled = false;
            }
            else if (loginLength >= 3 && loginLength <= 10 && usersRepository.IsLoginInDatabase(LoginBox.Text))
            {
                DeleteUserButton.Enabled = true;
                AddUserButton.Enabled = false;
            }
            else
            { 
                AddUserButton.Enabled = false;
                DeleteUserButton.Enabled = false;
            }

        }
    }
}