using System;
using System.Linq;
using System.Web.UI.WebControls;
using EdukuJez.Repositories;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens;
using System.Configuration;

namespace EdukuJez
{
    public partial class AccountsManagement : System.Web.UI.Page
    {
        private User newUser = new User();
        private User userToEdit = new User();
        private UsersRepository usersRepository = new UsersRepository();
        private GroupUsersRepository groupsUsersRepository = new GroupUsersRepository();
        private GroupsRepository groupsRepo = new GroupsRepository();

        protected void Page_Load(object sender, EventArgs e) {
            if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == false)
                UserSession.ChangeSiteNoPermission(this, "Main.aspx");
            if (!IsPostBack)
            {
                List<User> users = usersRepository.Table.ToList();
                List<GroupUser> groupUserList = groupsUsersRepository.Table.Include(u => u.User).Include(g => g.Group).ToList();

                var mergedData = users.Select(user => new
                {
                    UserId = user.Id,
                    UserLogin = user.UserLogin,
                    UserName = user.UserName,
                    UserSurname = user.UserSurname,
                    ParentGroup = returnGroup(user)
                }) ;

                myRepeater.DataSource = mergedData;
                myRepeater.DataBind();

                List<Group> groups = groupsRepo.Table.ToList();
                GroupBox.DataSource = groups.Where(x => x.ParentGroup == null).Select(x => x.Name);
                GroupBox.DataBind();
            }
        }
        
        protected string returnGroup(User user)
        {
            string groupName = null;
            
            User userWithGroups = usersRepository.Table
                .Include(u => u.Groups)
                .ThenInclude(gu => gu.Group)
                .FirstOrDefault(x => x.Id == user.Id);
            
            if (userWithGroups != null)
            {
                List<GroupUser> userGroups = userWithGroups.Groups.ToList();
                
                foreach (var groupUser in userGroups)
                {
                    Group group = groupUser.Group;
                    groupName = group.Name;
                }
            }
            return groupName;
        }



        protected void AddClick(object sender, EventArgs e)
        {
            MainInfoLabel.Text = "Wypełnij dane nowego użytkownika:";
            LoginBox.Enabled = false;
            EditUserButton.Visible = false;
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
            EditUserButton.Visible = false;
            AddUserButton.Visible = false;
            DeleteUserButton.Visible = false;
            ConfirmDeleteButton.Visible = true;
        }

        protected void EditClick(object sender, EventArgs e)
        {
            MainInfoLabel.Text = "Wpisz nowe dane wybranego użytkownika:";
            LoginBox.Enabled = false;
            AddUserButton.Visible = false;
            EditUserButton.Visible = false;
            DeleteUserButton.Visible = false;
            PasswordBox.Visible = true;
            ConfirmEditButton.Visible = true;
            NameLabel.Visible = true;
            NameBox.Visible = true;
            SurnameLabel.Visible = true;
            SurnameBox.Visible = true;
            PasswordLabel.Visible = true;

            userToEdit = usersRepository.Table.FirstOrDefault(x => x.UserLogin == LoginBox.Text);
            NameBox.Text = userToEdit.UserName;
            SurnameBox.Text = userToEdit.UserSurname;


        }

        protected void ConfirmDeleteClick(object sender, EventArgs e)
        {
            usersRepository.Delete(usersRepository.Table.First(x => x.UserLogin == LoginBox.Text));
            MainInfoLabel.Text = "Usunąłeś z bazy danych użytkownika o loginie " + LoginBox.Text + ". <br> Kliknij poniższy przycisk, aby dodać, edytować lub usunąć kolejnego użytkownika.";
            ConfirmDeleteButton.Visible = false;
            LoginBox.Visible = false;
            LoginLabel.Visible = false;
            RestartButton.Visible = true;
            myRepeater.DataBind();
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


                Group g = groupsRepo.Table.FirstOrDefault(x => x.Name == GroupBox.SelectedValue.ToString());
                var gu = new GroupUser();
                g.Users = new List<GroupUser>() { gu };
                newUser.Groups = new List<GroupUser>() { gu };
                usersRepository.Insert(newUser);
                groupsRepo.Update();



                MainInfoLabel.Text = "Dodałeś do bazy danych użytkownika o loginie " + newUser.UserLogin +
                                     ". <br> Kliknij poniższy przycisk, aby dodać, edytować lub usunąć kolejnego użytkownika.";

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
                myRepeater.DataBind();
            }
        }

        protected void ConfirmEditClick(object sender, EventArgs e)
        {
            userToEdit = usersRepository.Table.FirstOrDefault(x => x.UserLogin == LoginBox.Text);
            if (!userToEdit.IsNameValid(NameBox.Text))
            {
                InfoLabel.Text = "Niepoprawne imię.";
            }
            else if (!userToEdit.IsSurnameValid(SurnameBox.Text))
            {
                InfoLabel.Text = "Niepoprawne nazwisko.";
            }
            else if (!string.IsNullOrEmpty(PasswordBox.Text))
            {
                if (!userToEdit.IsPasswordValid(PasswordBox.Text))
                {
                    InfoLabel.Text = "Hasło musi się składać od 8 do 50 znaków, <br> co najmniej: jednej cyfry, jednej małej i jednej wielkiej litery <br> oraz co najmniej jednego ze znaków: . ! @ # $ % & ? <br> nie może także zawierać znaków polskich.";
                }
            }
            else
            {
                InfoLabel.Visible = false;

                userToEdit.UserName = NameBox.Text;
                userToEdit.UserSurname = SurnameBox.Text;
                if (PasswordBox.Text != null)
                {
                    userToEdit.UserPassword = PasswordBox.Text;
                }
                usersRepository.UpdateRow(userToEdit);



                MainInfoLabel.Text = "Edytowałeś dane użytkownika o loginie " + userToEdit.UserLogin +
                                     ". <br> Kliknij poniższy przycisk, aby dodać, edytować lub usunąć kolejnego użytkownika.";

                PasswordBox.Visible = false;
                GroupBox.Visible = false;
                ConfirmEditButton.Visible = false;
                NameLabel.Visible = false;
                NameBox.Visible = false;
                SurnameLabel.Visible = false;
                SurnameBox.Visible = false;
                PasswordLabel.Visible = false;
                GroupLabel.Visible = false;
                LoginBox.Visible = false;
                LoginLabel.Visible = false;
                RestartButton.Visible = true;
                myRepeater.DataBind();
            }
        }

        protected void LoginBoxChanged(object sender, EventArgs e)
        {
            if (usersRepository.IsLoginInDatabase(LoginBox.Text))
            {
                DeleteUserButton.Enabled = true;
                AddUserButton.Enabled = false;
                EditUserButton.Enabled = true;
            }
            else if (newUser.IsLoginValid(LoginBox.Text, LoginBox.Text.Length) && !usersRepository.IsLoginInDatabase(LoginBox.Text))
            {
                AddUserButton.Enabled = true;
                EditUserButton.Enabled = false;
                DeleteUserButton.Enabled = false;
            }
            else
            { 
                AddUserButton.Enabled = false;
                EditUserButton.Enabled = false;
                DeleteUserButton.Enabled = false;
                InfoLabel.Text = "Login może się składać z 3-30 liter (nie polskich) oraz cyfr. Nie zaczynaj loginu od cyfry.";
            }
        }

        protected void ConfirmRestartClick(object sender, EventArgs e)
        {
            Response.Redirect("AccountsManagement.aspx");

        }

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPanel.aspx");
        }
    }
}