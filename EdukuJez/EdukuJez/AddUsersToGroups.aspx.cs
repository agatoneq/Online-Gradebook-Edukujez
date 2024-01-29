using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EdukuJez
{
    public partial class AddUsersToGroups : System.Web.UI.Page
    {
        private Group newGroup = new Group();
        private string firstName, lastName, login = null;
        readonly GroupsRepository groupRepo = new GroupsRepository();
        readonly UsersRepository userRepo = new UsersRepository();
        readonly GroupUsersRepository groupUserRepo = new GroupUsersRepository();
        List<User> users = new List<User>();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == false)
                UserSession.ChangeSiteNoPermission(this, "Main.aspx");

            if (!IsPostBack)
            {
                users = userRepo.Table.ToList();
                UsersBox.DataSource = users.Select(u => $"{u.UserName} {u.UserSurname} ({u.UserLogin})");
                UsersBox.DataBind();

                UploadGroupsLists(users);
            }
        }

        protected void UploadGroupsLists(List<User> usersList)
        {
            string userBoxFullName = UsersBox.Text;
            string[] parts = userBoxFullName.Split(' ');
            firstName = parts[0];
            lastName = parts[1];
            login = parts[2].Trim('(', ')');

            var usersId = usersList.Where(x => x.UserLogin == login).Select(x => x.Id);
            var userId = usersId.FirstOrDefault();

            List<Group> groups = groupRepo.Table.ToList();
            List<GroupUser> groupUserList = groupUserRepo.Table.Include(u => u.User).Include(g => g.Group).ToList();

            List<int> currentGroupsId = groupUserList.Where(x => x.Group != null && x.User.Id == userId).Select(x => x.Group.Id).ToList();

            var parentGroupName = groupUserList.Where(x => x.Group != null && x.User.Id == userId).Select(x => x.Group.Name).ToList().FirstOrDefault();

            CurrentGroupsBox.DataSource = groups.Where(x => currentGroupsId.Contains(x.Id) && x.ParentGroup != null).Select(g => g.Name);
            CurrentGroupsBox.DataBind();

            PossibleGroupsBox.DataSource = groups.Where(x => !currentGroupsId.Contains(x.Id) && x.ParentGroup != null && x.ParentGroup.Name == parentGroupName).Select(g => g.Name);
            PossibleGroupsBox.DataBind();
        }

        protected void AddClick(object sender, EventArgs e)
        {
            ConfirmInfoLabel.Text = "Czy na pewno chcesz dodać " + UsersBox.Text + " do grupy o nazwie " + PossibleGroupsBox.Text + "?";
            ConfirmInfoLabel.Visible = true;
            CancelButton.Visible = true;
            ConfirmAddButton.Visible = true;
        }

        protected void DeleteClick(object sender, EventArgs e)
        {
            ConfirmInfoLabel.Text = "Czy na pewno chcesz usunąć " + UsersBox.Text + " z grupy o nazwie " + CurrentGroupsBox.Text + "?";
            ConfirmInfoLabel.Visible = true;
            CancelButton.Visible = true;
            ConfirmDeleteButton.Visible = true;
        }

        protected void ConfirmAddClick(object sender, EventArgs e)
        {
            string userBoxFullName = UsersBox.Text;
            string[] parts = userBoxFullName.Split(' ');
            firstName = parts[0];
            lastName = parts[1];
            login = parts[2].Trim('(', ')');

            User userToEdit = new User();
            Group g = groupRepo.Table.FirstOrDefault(x => x.Name == PossibleGroupsBox.Text);
            var gu = new GroupUser();
            g.Users = new List<GroupUser>() { gu };
            userToEdit = userRepo.Table.FirstOrDefault(x => x.UserLogin == login);
            userToEdit.Groups = new List<GroupUser>() { gu };

            userRepo.Update();
            groupRepo.Update();

            ConfirmInfoLabel.Text = "Dodałeś " + UsersBox.Text + " do grupy o nazwie " + PossibleGroupsBox.Text + " Możesz kontynuować.";
            CancelButton.Visible = false;
            ConfirmAddButton.Visible = false;
            CurrentGroupsBox.DataBind();
            PossibleGroupsBox.DataBind();
        }

        protected void ConfirmDeleteClick(object sender, EventArgs e)
        {
            string userBoxFullName = UsersBox.Text;
            string[] parts = userBoxFullName.Split(' ');
            firstName = parts[0];
            lastName = parts[1];
            login = parts[2].Trim('(', ')');

            /*            User userToDelete = userRepo.Table.FirstOrDefault(x => x.UserLogin == login);

                        Group groupToDeleteFrom = groupRepo.Table.FirstOrDefault(x => x.Name == CurrentGroupsBox.Text);
                        var groupUserToDelete = groupToDeleteFrom.Users.FirstOrDefault(gu => gu.UserId == userToDelete.Id);
                        groupToDeleteFrom.Users.Remove(groupUserToDelete);*/


            User userToEdit = new User();
            Group g = groupRepo.Table.FirstOrDefault(x => x.Name == CurrentGroupsBox.Text);
            var gu = new GroupUser();
            userToEdit = userRepo.Table.FirstOrDefault(x => x.UserLogin == login);
            gu = groupUserRepo.Table.FirstOrDefault(x => x.Group == g && x.User == userToEdit);
            g.Users.Remove(gu);
            userToEdit.Groups.Remove(gu);

            userRepo.Update();
            groupRepo.Update();

            ConfirmInfoLabel.Text = "Usunąłeś " + UsersBox.Text + " z grupy o nazwie " + CurrentGroupsBox.Text + " Możesz kontynuować.";
            CancelButton.Visible = false;
            ConfirmDeleteButton.Visible = false;
            CurrentGroupsBox.DataBind();
            PossibleGroupsBox.DataBind();
        }

        protected void CancelClick(object sender, EventArgs e)
        {
            ConfirmInfoLabel.Text = "Anulowałeś operację. Możesz kontynuować.";
            ConfirmInfoLabel.Visible = false;
            CancelButton.Visible = false;
            ConfirmDeleteButton.Visible = false;
            ConfirmAddButton.Visible = false;
        }

        protected void UsersGroupsListSelectedIndexChanged(object sender, EventArgs e)
        {
            users = userRepo.Table.ToList();
            UploadGroupsLists(users);
        }

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPanel.aspx");
        }

    }
}