using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using EdukuJez.Repositories;
using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace EdukuJez
{
    public partial class GroupsManagement : System.Web.UI.Page
    {
        private Group newGroup = new Group();
        readonly GroupsRepository groupRepo = new GroupsRepository();
        readonly UsersRepository userRepo = new UsersRepository();
        readonly GroupUsersRepository groupUserRepo = new GroupUsersRepository();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (UserSession.CheckPermission(UserSession.ADMIN_GROUP) == false)
                UserSession.ChangeSiteNoPermission(this, "Main.aspx");

            if (!IsPostBack)
            {
                //List<Group> groups = groupRepo.Table.ToList();
                List<Group> groups = groupRepo.Table.Include(g => g.Educator).ToList();
                myRepeater.DataSource = groups;
                myRepeater.DataBind();


                MainGroupList.DataSource = groups.Where(x => x.ParentGroup == null).Select(x => x.Name);
                MainGroupList.DataBind();

                List<User> users = userRepo.Table.ToList();
                List<GroupUser> groupUserList = groupUserRepo.Table.Include(u => u.User).Include(g => g.Group).ToList();
                List<int> teachersId = groupUserList.Where(x => x.Group != null && x.Group.Name == UserSession.TEACHER_GROUP && x.User != null).Select(x => x.User.Id).ToList();
                

                TeachersList.DataSource = users.Where(x => teachersId.Contains(x.Id)).Select(user => $"{user.UserName} {user.UserSurname}");
                TeachersList.DataBind();
            }
        }

        protected void AddNewGroupButton_Click(object sender, EventArgs e)
        {
            var ng = new Group();
            ng.Name = NewGroupTextBox.Text;

            var parentName = MainGroupList.SelectedValue;
            ng.ParentGroup = groupRepo.Table.First(x => x.Name == parentName);

            groupRepo.Insert(ng);

            if (parentName == "Uczeń")
            {
                var educatorFullName = TeachersList.SelectedValue;
                string[] parts = educatorFullName.Split(' ');
                ng.Educator = userRepo.Table.First(x => (x.UserName + " " + x.UserSurname) == educatorFullName);
                userRepo.Table.First(x => x.UserName == parts[0] && x.UserSurname == parts[1]).Educates.Add(ng);
                userRepo.Update();
                groupRepo.Update();
            }

            MainInfoLabel.Text = "Dodałeś do bazy danych grupę o nazwie " + ng.Name +
                                     ". <br> Kliknij poniższy przycisk, aby dodać lub usunąć kolejną grupę.";

            MainGroupLabel.Visible = false;
            NewGroupTextBox.Visible = false;
            MainGroupList.Visible = false;
            TeachersList.Visible = false;
            EducatorLabel.Visible = false;
            NameLabel.Visible = false;
            DeleteGroupButton.Visible = false;
            AddNewGroupButton.Visible = false;
            RestartButton.Visible = true;
            EditGroupButton.Visible = false;
            myRepeater.DataBind();
        }

        protected void DeleteGroupButton_Click(object sender, EventArgs e)
        {
            MainInfoLabel.Text = "Czy na pewno chcesz usunąć tę grupę? Ta operacja jest nieodwracalna!";
            NewGroupTextBox.Enabled = false;
            TeachersList.Visible = false;
            EducatorLabel.Visible = false;
            MainGroupList.Visible = false;
            MainGroupLabel.Visible = false;
            DeleteGroupButton.Visible = false;
            AddNewGroupButton.Visible = false;
            EditGroupButton.Visible = false;
            ConfirmDeleteButton.Visible = true;
        }

        protected void ConfirmDeleteClick(object sender, EventArgs e)
        {
            groupRepo.Delete(groupRepo.Table.First(x => x.Name == NewGroupTextBox.Text));
            MainInfoLabel.Text = "Usunąłeś z bazy danych grupę o nazwie " + NewGroupTextBox.Text + ". <br> Kliknij poniższy przycisk, aby dodać, edytować lub usunąć kolejną grupę.";
            MainGroupLabel.Visible = false;
            NewGroupTextBox.Visible = false;
            ConfirmDeleteButton.Visible = false;
            NameLabel.Visible = false;
            RestartButton.Visible = true;
            EditGroupButton.Visible = false;
            myRepeater.DataBind();
        }

        protected void EditGroupButton_Click(object sender, EventArgs e)
        {
            List<Group> groupList = groupRepo.Table.ToList();
            var parentName = groupList.Where(x => x.Name == NewGroupTextBox.Text).Select(g => g.ParentGroup.Name);
            string pn = parentName.FirstOrDefault();

            Group groupToUpdate = groupRepo.Table.FirstOrDefault(x => x.Name == NewGroupTextBox.Text);
            string educatorName = groupToUpdate.Educator?.UserName;
            string educatorSurname = groupToUpdate.Educator?.UserSurname;

            MainInfoLabel.Text = "Edytowałeś w bazie danych grupę o nazwie " + groupToUpdate.Name +
                                     ". <br> Kliknij poniższy przycisk, aby dodać, edytować lub usunąć kolejną grupę.";
            NameLabel.Visible = false;
            NewGroupTextBox.Visible = false;
            TeachersList.Visible = false;
            EducatorLabel.Visible = false;
            MainGroupList.Visible = false;
            MainGroupLabel.Visible = false;
            DeleteGroupButton.Visible = false;
            AddNewGroupButton.Visible = false;
            EditGroupButton.Visible = false;
            
            if (pn == "Uczeń")
            {
                string educatorFullName = TeachersList.SelectedValue;
                string[] parts = educatorFullName.Split(' ');
                groupToUpdate.Educator = userRepo.Table.First(x => (x.UserName + " " + x.UserSurname) == educatorFullName);
                userRepo.Table.First(x => x.UserName == parts[0] && x.UserSurname == parts[1]).Educates.Add(groupToUpdate);
                userRepo.Update();
                groupRepo.Update();
            }

            RestartButton.Visible = true;
            myRepeater.DataBind();
        }

        protected void NameGroupBoxChanged(object sender, EventArgs e)
        {
            if (groupRepo.IsGroupInDatabase(NewGroupTextBox.Text))
            {
                EditGroupButton.Enabled = true;
                DeleteGroupButton.Enabled = true;
                AddNewGroupButton.Enabled = false;
                TeachersList.Visible = true;
                EducatorLabel.Visible = true;

                List<Group> groupList = groupRepo.Table.ToList();
                var parentName = groupList.Where(x => x.Name == NewGroupTextBox.Text).Select(g => g.ParentGroup.Name);
                string pn = parentName.FirstOrDefault();


                if (pn != "Uczeń")
                {
                    EditGroupButton.Enabled = false;
                    TeachersList.Visible = false;
                    EducatorLabel.Visible = false;
                }

            }
            else if (newGroup.IsNameValid(NewGroupTextBox.Text) && !groupRepo.IsGroupInDatabase(NewGroupTextBox.Text))
            {
                AddNewGroupButton.Enabled = true;
                DeleteGroupButton.Enabled = false;
                EditGroupButton.Enabled = false;
                TeachersList.Visible = true;
                EducatorLabel.Visible = true;
                MainGroupList.Visible = true;
                MainGroupLabel.Visible = true;
            }
            else
            {
                DeleteGroupButton.Enabled = false;
                AddNewGroupButton.Enabled = false;
                EditGroupButton.Enabled = false;
                // InfoLabel.Text = "Login może się składać z 3-30 liter (nie polskich) oraz cyfr. Nie zaczynaj loginu od cyfry.";
            }
        }
        
        protected void ConfirmRestartClick(object sender, EventArgs e)
        {
            Response.Redirect("GroupsManagement.aspx");
        }

        protected void MainGroupListSelectedIndexChanged(object sender, EventArgs e)
        {
            if(MainGroupList.SelectedIndex != 0)
            {
                EducatorLabel.Visible = false;
                TeachersList.Visible = false;
            }
            else
            {
                EducatorLabel.Visible = true;
                TeachersList.Visible = true;
            }
        }

        protected void GoBackButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminPanel.aspx");
        }

    }
}
