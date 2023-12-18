using System;
using System.Linq;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using System.Collections.Generic;

namespace EdukuJez
{
    public partial class AccountsManagement : System.Web.UI.Page
    {
        private User newUser = new User();
        private UsersRepository usersRepository = new UsersRepository();
        private GroupUsersRepository groupsUsersRepository = new GroupUsersRepository();
        private GroupsRepository groupsRepository = new GroupsRepository();

        protected void Page_Load(object sender, EventArgs e) {
            GroupBox.Items.Clear();
            var ddList = groupsRepository.Table.Select(x => x.Name).ToList();
            foreach (var gr in ddList)
                GroupBox.Items.Add(gr);
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
            usersRepository.Delete(usersRepository.Table.First(x => x.UserLogin == LoginBox.Text));
            MainInfoLabel.Text = "Usunąłeś z bazy danych użytkownika o loginie " + LoginBox.Text + ". <br> Kliknij poniższy przycisk, aby dodać lub usunąć kolejnego użytkownika.";
            ConfirmDeleteButton.Visible = false;
            LoginBox.Visible = false;
            LoginLabel.Visible = false;
            RestartButton.Visible = true;
        }

        protected void ConfirmAddClick(object sender, EventArgs e)
        {
            if (!newUser.IsNameValid(NameBox.Text))
            {
                InfoLabel.Text = "Niepoprawne imię.";
            }
            else if (!newUser.IsSurnameValid(SurnameBox.Text))
            {
                InfoLabel.Text = "Niepoprawne nazwisko.";
            }
            else if (!newUser.IsPasswordValid(PasswordBox.Text))
            {
                InfoLabel.Text = "Hasło musi się składać od 8 do 50 znaków, <br> co najmniej: jednej cyfry, jednej małej i jednej wielkiej litery <br> oraz co najmniej jednego ze znaków: . ! @ # $ % & ? <br> nie może także zawierać znaków polskich.";
            }
            else
            {
                InfoLabel.Visible = false;
                newUser.UserLogin = LoginBox.Text;
                newUser.UserName = NameBox.Text;
                newUser.UserSurname = SurnameBox.Text;
                newUser.UserPassword = PasswordBox.Text;

                Group g = groupsRepository.Table.FirstOrDefault(x=> x.Name==GroupBox.Text);
                groupsUsersRepository.Insert(new GroupUser() { User = newUser, Group = g });

                usersRepository.Insert(newUser);
                MainInfoLabel.Text = "Dodałeś do bazy danych użytkownika o loginie " + newUser.UserLogin +
                                     ". <br> Kliknij poniższy przycisk, aby dodać lub usunąć kolejnego użytkownika.";

                PasswordBox.Visible = false;
                GroupBox.Visible = false;
                ConfirmAddButton.Visible = false;
                NameLabel.Visible = false;
                NameBox.Visible = false;
                SurnameLabel.Visible = false;
                SurnameBox.Visible = false;
                PasswordLabel.Visible = false;
                GroupLabel.Visible = false;
                LoginBox.Visible = false;
                LoginLabel.Visible = false;
                RestartButton.Visible = true;
            }
        }

        protected void LoginBoxChanged(object sender, EventArgs e)
        {
            if (usersRepository.IsLoginInDatabase(LoginBox.Text))
            {
                DeleteUserButton.Enabled = true;
                AddUserButton.Enabled = false;
            }
            else if (newUser.IsLoginValid(LoginBox.Text, LoginBox.Text.Length) && !usersRepository.IsLoginInDatabase(LoginBox.Text))
            {
                AddUserButton.Enabled = true;
                DeleteUserButton.Enabled = false;
            }
            else
            { 
                AddUserButton.Enabled = false;
                DeleteUserButton.Enabled = false;
                InfoLabel.Text = "Login może się składać z 3-30 liter (nie polskich) oraz cyfr. Nie zaczynaj loginu od cyfry.";
            }
        }

        protected void ConfirmRestartClick(object sender, EventArgs e)
        {
            Response.Redirect("AccountsManagement.aspx");

        }
    }
}