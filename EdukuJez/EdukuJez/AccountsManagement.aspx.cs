using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class AccountsManagement : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddClick(object sender, EventArgs e)
        {
            MainInfoLabel.Text = "Przypisz do nowego użytkownika hasło i grupę:";
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

        }

        protected void ConfirmAddClick(object sender, EventArgs e)
        {

        }
    }
}